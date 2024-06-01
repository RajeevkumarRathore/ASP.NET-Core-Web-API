using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Helpers;
using Application.Handler.Header.Dtos.GoogleApi.Address;
using Application.Handler.Header.Dtos.GoogleApi;
using Domain.Entities;
using DTO.Response;
using Mapster;
using System.Text.RegularExpressions;
using DTO.Response.Header;
using DTO.Response.Dashboard;
using Helper;
using Application.Common.Response;
using DTO.Response.Hospitals;
using Application.Common.Dtos;
using DTO.Request.Hospitals;

namespace Infrastructure.Implementation.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _hospitalRepository ;
        
        private readonly IDispatcherNotificationsRepository _dispatcherNotificationsRepository;
        public HospitalService(IHospitalRepository hospitalRepository,IDispatcherNotificationsRepository dispatcherNotificationsRepository)
        {
            _hospitalRepository = hospitalRepository;
            _dispatcherNotificationsRepository = dispatcherNotificationsRepository;
        }
        #region dashboard

      
        public async Task<CommonResultResponseDto<IList<GetHospitalDetailsResponseDto>>> GetHospitalDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            var result = await _hospitalRepository.GetHospitalDetails(startDate, endDate, isViewAll ,searchText);
            return CommonResultResponseDto<IList<GetHospitalDetailsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result.Adapt<IList<GetHospitalDetailsResponseDto>>());

        }
        public async Task<CommonResultResponseDto<List<HospitalResponseDto>>> GetHospitals(string searchText)
        {
            List<HospitalResponseDto> appendedHospitalDto = new List<HospitalResponseDto>();
            List<Hospital> hospitals = await _hospitalRepository.GetHospitals(searchText);
            List<DispatchNotificationResponseDto> brcDispatchNotifications = await _dispatcherNotificationsRepository.GetEffectiveDispatchNotifications();
            if (hospitals.Count > 0)
            {
                foreach (var hospital in hospitals)
                {
                    DispatchNotificationResponseDto appendedHospital = brcDispatchNotifications?.Where(x => x.HospitalId == hospital.Id)?.FirstOrDefault();
                    HospitalResponseDto hospitalDto = new HospitalResponseDto
                    {
                        Hospital = hospital,
                        DispatchNotificationResponse = appendedHospital

                    };
                    appendedHospitalDto.Add(hospitalDto);
                }
            }
            else
            {
                var results = await Utilities.SearchHospitals(searchText);
                foreach (var item in results.predictions)
                {
                    CallLocation callLocation = await FillCallLocation(new CallLocation { fullAddress = item.description }, true);
                    HospitalResponseDto hospitalDto = new HospitalResponseDto
                    {
                        Hospital = new Hospital
                        {
                            Name = item.structured_formatting?.main_text,
                            Address = callLocation.street ?? "",
                            City = callLocation.city ?? "",
                            State = callLocation.state ?? "",
                            Zip = callLocation.zip ?? "",
                            Latitude = callLocation.latitude ?? new decimal(),
                            Longitude = callLocation.longitude ?? new decimal()
                        },
                        fromGoogle = true
                    };
                    appendedHospitalDto.Add(hospitalDto);
                };
            }


            return CommonResultResponseDto<List<HospitalResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, appendedHospitalDto);
        }


        #endregion

        public async Task<CommonResultResponseDto<PaginatedList<HospitalsResponseDto>>> GetAllHospitals(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (hospitals, total) = await _hospitalRepository.GetAllHospitals(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<HospitalsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<HospitalsResponseDto>(hospitals, total), 0);
        }

        public async Task<CommonResultResponseDto<CreateUpdateHospitalResponseDto>> CreateUpdateHospital(CreateUpdateHospitalRequestDto createUpdateHospitalRequestDto)
        {
            var returnvalue = await _hospitalRepository.IsExistHospital(createUpdateHospitalRequestDto.HospitalName, createUpdateHospitalRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateHospitalResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
               var hospital =  await _hospitalRepository.CreateUpdateHospital(createUpdateHospitalRequestDto);

                if (hospital == 0)
                {
                    return CommonResultResponseDto<CreateUpdateHospitalResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<CreateUpdateHospitalResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteHospital(int id)
        {
            bool result = await _hospitalRepository.DeleteHospital(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }



        #region private

        private async Task<CallLocation> FillCallLocation(CallLocation callLocation, bool isAddressFirst = false, bool? fromGoogle = false, bool? isHwy = false)
        {
            var infoCard = ConvertToInfoCard(callLocation);
            var peopleInfo = await GetPeopleInfo(infoCard, isAddressFirst, fromGoogle, isHwy);
            callLocation = await ConvertToCallLocationAsync(peopleInfo, callLocation);

            return callLocation;
        }

        PeopleInfoCard ConvertToInfoCard(CallLocation callLocation)
        {
            PeopleInfoCard peopleInfoCard = new PeopleInfoCard();
            if (callLocation != null)
            {
                double? lat = null;
                double? lng = null;
                if (callLocation.latitude != null)
                {
                    lat = Convert.ToDouble(callLocation.latitude);
                }
                if (callLocation.longitude != null)
                {
                    lng = Convert.ToDouble(callLocation.longitude);
                }

                peopleInfoCard.PeopleAddressCard = new PeopleAddressCard
                {
                    FullAddress = callLocation.fullAddress,
                    OriginalAddress = callLocation.fullAddress,
                    State = callLocation.state,
                    City = callLocation.city,
                    Zip = callLocation.zip,
                    Street = callLocation.street,
                    Cross = callLocation.cross,
                    Apt = callLocation.apt,
                    Floor = callLocation.floor,
                    Room = callLocation.room,
                    Township = callLocation.township
                };
                peopleInfoCard.PeopleLocationCard = new PeopleLocationCard
                {
                    Latitude = lat,
                    Longitude = lng
                };
            }
            return peopleInfoCard;
        }

        private async Task<PeopleInfoCard> GetPeopleInfo(PeopleInfoCard peopleInfo, bool isAddressFirst = false, bool? fromGoogle = false, bool? isHwy = null)
        {
            if (peopleInfo != null)
            {
                if (!isAddressFirst && peopleInfo.PeopleLocationCard != null
                    && peopleInfo.PeopleLocationCard.Latitude != null && peopleInfo.PeopleLocationCard.Longitude != null
                        && peopleInfo.PeopleLocationCard.Latitude != 0 && peopleInfo.PeopleLocationCard.Longitude != 0)
                {
                    GeoContent geoContent = await Utilities.GetAddress(Utilities.CreateLatLng(peopleInfo.PeopleLocationCard.Latitude ?? 0, peopleInfo.PeopleLocationCard.Longitude ?? 0));
                    if (geoContent != null)
                    {
                        peopleInfo.PeopleAddressCard = peopleInfo.PeopleAddressCard ?? new PeopleAddressCard();

                        ResultGeo resultGeo = geoContent.results.FirstOrDefault();
                        if (resultGeo != null)
                        {
                            List<AddressComponent> addressComponents = resultGeo.address_components ?? new List<AddressComponent>();

                            peopleInfo.PeopleAddressCard.FormattedAddress = resultGeo.formatted_address;
                            peopleInfo.PeopleAddressCard.FullAddress = resultGeo.formatted_address;
                            peopleInfo.PeopleAddressCard.Country = getAddressComponent(addressComponents, ConstantVariables.MAP_COUNTRY);
                            peopleInfo.PeopleAddressCard.State = getAddressComponent(addressComponents, ConstantVariables.MAP_ADMINISTRATIVE_AREA_LEVEL_1);
                            peopleInfo.PeopleAddressCard.City = getAddressComponent(addressComponents, ConstantVariables.MAP_CITY);
                            peopleInfo.PeopleAddressCard.Township = getAddressComponent(addressComponents, ConstantVariables.MAP_ADMINISTRATIVE_AREA_LEVEL_4);
                            peopleInfo.PeopleAddressCard.Street = getAddressComponent(addressComponents, ConstantVariables.MAP_STREET_ADDRESS);
                            peopleInfo.PeopleAddressCard.Cross = getAddressComponent(addressComponents, ConstantVariables.MAP_ROUTE);
                            peopleInfo.PeopleAddressCard.Apt = getAddressComponent(addressComponents, ConstantVariables.MAP_STREET_NUMBER);
                            peopleInfo.PeopleAddressCard.Floor = getAddressComponent(addressComponents, ConstantVariables.MAP_FLOOR);
                            peopleInfo.PeopleAddressCard.Room = getAddressComponent(addressComponents, ConstantVariables.MAP_ROOM);
                            peopleInfo.PeopleAddressCard.Zip = getAddressComponent(addressComponents, ConstantVariables.MAP_ZIP);

                            peopleInfo.PeopleAddressCard.GoogleStreet = peopleInfo.PeopleAddressCard.Street;
                            peopleInfo.PeopleAddressCard.GoogleCross = peopleInfo.PeopleAddressCard.Cross;
                            peopleInfo.PeopleAddressCard.GoogleApt = peopleInfo.PeopleAddressCard.Apt;
                        }
                    }
                }
                else if (peopleInfo.PeopleAddressCard != null)
                {
                    peopleInfo.PeopleAddressCard.FullAddress = peopleInfo.PeopleAddressCard.FullAddress ?? getDefaultAddress(peopleInfo.PeopleAddressCard);

                    if (!string.IsNullOrWhiteSpace(peopleInfo.PeopleAddressCard.FullAddress))
                    {
                        if (peopleInfo.PeopleAddressCard.FullAddress == ConstantVariables.DEFAULT_CALL_LOCATION) // default address does not need to go Google address
                        {
                            peopleInfo.PeopleAddressCard.FullAddress = ConstantVariables.DEFAULT_CALL_LOCATION_FORMATTED_ADDRESS;
                            peopleInfo.PeopleLocationCard.Latitude = ConstantVariables.DEFAULT_CALL_LOCATION_LATITUDE;
                            peopleInfo.PeopleLocationCard.Longitude = ConstantVariables.DEFAULT_CALL_LOCATION_LONGITUDE;
                        }
                        else
                        {
                            GeoContent geoContent = await Utilities.GetLocation(peopleInfo.PeopleAddressCard.FullAddress);
                            if (geoContent != null)
                            {
                                peopleInfo.PeopleAddressCard = peopleInfo.PeopleAddressCard ?? new PeopleAddressCard();
                                peopleInfo.PeopleLocationCard = peopleInfo.PeopleLocationCard ?? new PeopleLocationCard();

                                ResultGeo resultGeo = geoContent.results.FirstOrDefault(x => x.types.Contains("premise"))
                                                    ?? geoContent.results.FirstOrDefault();

                                if (resultGeo != null)
                                {
                                    peopleInfo.PeopleAddressCard.FormattedAddress = resultGeo.formatted_address;
                                    peopleInfo.PeopleAddressCard.address_components = resultGeo.address_components;
                                    peopleInfo.PeopleAddressCard.resultGeoType = resultGeo.types.FirstOrDefault(type => type == "point_of_interest") ?? resultGeo.types.FirstOrDefault();
                                    peopleInfo.PeopleAddressCard.placeId = resultGeo.place_id;
                                    GeometryGeo geometry = resultGeo.geometry ?? new GeometryGeo();

                                    peopleInfo.PeopleLocationCard.Latitude = geometry.location?.lat;
                                    peopleInfo.PeopleLocationCard.Longitude = geometry.location?.lng;

                                    List<AddressComponent> addressComponents = resultGeo.address_components ?? new List<AddressComponent>();


                                    peopleInfo.PeopleAddressCard.Country = peopleInfo.PeopleAddressCard.Country ?? getAddressComponent(addressComponents, ConstantVariables.MAP_COUNTRY);
                                    peopleInfo.PeopleAddressCard.State = peopleInfo.PeopleAddressCard.State ?? getAddressComponent(addressComponents, ConstantVariables.MAP_ADMINISTRATIVE_AREA_LEVEL_1);
                                    peopleInfo.PeopleAddressCard.StateShortName = addressComponents?.Where(x => x.types.Contains(ConstantVariables.MAP_ADMINISTRATIVE_AREA_LEVEL_1))?.FirstOrDefault()?.short_name;
                                    peopleInfo.PeopleAddressCard.City = peopleInfo.PeopleAddressCard.City ?? (getAddressComponent(addressComponents, ConstantVariables.MAP_CITY) ?? getAddressComponent(addressComponents, ConstantVariables.MAP_CITY2));
                                    peopleInfo.PeopleAddressCard.Township = peopleInfo.PeopleAddressCard.Township ?? getAddressComponent(addressComponents, ConstantVariables.MAP_ADMINISTRATIVE_AREA_LEVEL_4);
                                    peopleInfo.PeopleAddressCard.Street = peopleInfo.PeopleAddressCard.Street ?? getAddressComponent(addressComponents, ConstantVariables.MAP_STREET_ADDRESS);
                                    peopleInfo.PeopleAddressCard.Cross = peopleInfo.PeopleAddressCard.Cross ?? getAddressComponent(addressComponents, ConstantVariables.MAP_ROUTE);
                                    peopleInfo.PeopleAddressCard.Apt = peopleInfo.PeopleAddressCard.Apt ?? getAddressComponent(addressComponents, ConstantVariables.MAP_STREET_NUMBER);
                                    peopleInfo.PeopleAddressCard.Floor = peopleInfo.PeopleAddressCard.Floor ?? getAddressComponent(addressComponents, ConstantVariables.MAP_FLOOR);
                                    peopleInfo.PeopleAddressCard.Room = peopleInfo.PeopleAddressCard.Room ?? getAddressComponent(addressComponents, ConstantVariables.MAP_ROOM);
                                    peopleInfo.PeopleAddressCard.Zip = (peopleInfo.PeopleAddressCard.Zip == ConstantVariables.MAP_DEFAULT_ZIP && !string.IsNullOrWhiteSpace(getAddressComponent(addressComponents, ConstantVariables.MAP_ZIP))
                                        ? getAddressComponent(addressComponents, ConstantVariables.MAP_ZIP)
                                        : peopleInfo.PeopleAddressCard.Zip) ?? getAddressComponent(addressComponents, ConstantVariables.MAP_ZIP);


                                    string fullAddress = peopleInfo.PeopleAddressCard.FullAddress;
                                    var anyNumeric = !string.IsNullOrWhiteSpace(Utilities.OnlyNumeric(fullAddress));
                                    if (anyNumeric)
                                    {
                                        string zipPattern = @"\d\d\d\d\d";
                                        Match match = Regex.Match(peopleInfo.PeopleAddressCard.FullAddress, zipPattern);
                                        if (match.Success)
                                        {
                                            int position = fullAddress.IndexOf(match.Value);
                                            string zip = fullAddress.Substring(position, 5);

                                            string ziplessAddress = fullAddress.Replace(zip, "");

                                            if (string.IsNullOrWhiteSpace(Utilities.OnlyNumeric(ziplessAddress)))
                                            {
                                                peopleInfo.PeopleAddressCard.FullAddress = peopleInfo.PeopleAddressCard.FormattedAddress;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        peopleInfo.PeopleAddressCard.FullAddress = peopleInfo.PeopleAddressCard.FormattedAddress;
                                    }

                                    peopleInfo.PeopleAddressCard.GoogleStreet = peopleInfo.PeopleAddressCard.Street;
                                    peopleInfo.PeopleAddressCard.GoogleCross = peopleInfo.PeopleAddressCard.Cross;
                                    peopleInfo.PeopleAddressCard.GoogleApt = peopleInfo.PeopleAddressCard.Apt;
                                }
                            }
                        }
                    }
                }
            }

            if (isHwy != true)
            {
                peopleInfo = SetAptAndStreet(peopleInfo, fromGoogle);
            }
            return peopleInfo;
        }

        string getAddressComponent(List<AddressComponent> addressComponents, string type)
        {
            var result = addressComponents?.Where(x => x.types.Contains(type))?.FirstOrDefault()?.long_name;
            return result;
        }
        string getDefaultAddress(PeopleAddressCard peopleAddressCard)
        {
            string address = "";//peopleAddressCard.FullAddress;
                                //if (string.IsNullOrWhiteSpace(address) || address.Split(' ').Count() < 5)
            {
                peopleAddressCard.State = peopleAddressCard.State ?? ConstantVariables.MAP_DEFAULT_STATE;
                peopleAddressCard.City = peopleAddressCard.City ?? ConstantVariables.MAP_DEFAULT_CITY;
                peopleAddressCard.Zip = peopleAddressCard.Zip ?? ConstantVariables.MAP_DEFAULT_ZIP;

                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.Cross) ? " " + peopleAddressCard.Cross : peopleAddressCard.Cross;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.Street) ? " " + peopleAddressCard.Street : peopleAddressCard.Street;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.Apt) ? " " + peopleAddressCard.Apt : peopleAddressCard.Apt;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.Township) ? " " + peopleAddressCard.Township : peopleAddressCard.Township;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.City) ? " " + peopleAddressCard.City : peopleAddressCard.City;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.State) ? " " + peopleAddressCard.State : peopleAddressCard.State;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.Country) ? " " + peopleAddressCard.Country : peopleAddressCard.Country;
                address += !string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(peopleAddressCard.Zip) ? " " + peopleAddressCard.Zip : peopleAddressCard.Zip;
            }

            return address;
        }
        PeopleInfoCard SetAptAndStreet(PeopleInfoCard peopleInfoCard, bool? fromGoogle = false)
        {
            if (peopleInfoCard != null && peopleInfoCard.PeopleAddressCard != null)
            {
                SetAptAndStreetAccordingToAddressType(peopleInfoCard, fromGoogle);
            }
            return peopleInfoCard;
        }

        private static void SetAptAndStreetAccordingToAddressType(PeopleInfoCard peopleInfoCard, bool? fromGoogle = false)
        {
            if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard.FullAddress))
            {
                string apt = string.Empty;
                string street_number = string.Empty;

                string streetAddress = fromGoogle == true
                       ? peopleInfoCard.PeopleAddressCard.FormattedAddress
                       : (peopleInfoCard.PeopleAddressCard.resultGeoType != "intersection"
                          ? peopleInfoCard.PeopleAddressCard.FullAddress
                          : peopleInfoCard.PeopleAddressCard.FormattedAddress);
                bool isStreetFind = false;
                bool isAptFound = false;

                if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard?.Cross) && peopleInfoCard.PeopleAddressCard.Cross.IndexOf("Test", StringComparison.InvariantCulture) > -1)
                {
                    streetAddress = peopleInfoCard.PeopleAddressCard.FormattedAddress;
                }

                //Finding Street
                if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard?.City))
                {
                    int position = streetAddress.IndexOf(peopleInfoCard.PeopleAddressCard?.City, StringComparison.InvariantCultureIgnoreCase);
                    if (position > -1)
                    {
                        int position2 = streetAddress.LastIndexOf(peopleInfoCard.PeopleAddressCard?.City, StringComparison.InvariantCultureIgnoreCase);//igmo if city name is same with street name, we had an issue. so I edited like this. city name is always the last one, I think.
                        if (position == position2)
                        {
                            streetAddress = streetAddress.Substring(0, position).Trim().TrimEnd(',').TrimEnd('.');
                        }
                        else
                        {
                            streetAddress = streetAddress.Substring(0, position2).Trim().TrimEnd(',').TrimEnd('.');
                        }

                        #region
                        //added this to cover when Test exist in streetAddress but full address is different from formattedAddress  7 Test Blvd 101 Test New York
                        string[] streetAddressArr = streetAddress
                        .Split(new string[] { "\n", " ", ",", "." }, StringSplitOptions.RemoveEmptyEntries);

                        if (streetAddressArr.Length == 1 && streetAddressArr[0].All(char.IsDigit))
                        {
                            streetAddress = peopleInfoCard.PeopleAddressCard.FullAddress;

                            position = streetAddress.IndexOf(peopleInfoCard.PeopleAddressCard?.City, StringComparison.InvariantCultureIgnoreCase);
                            if (position > -1)
                            {
                                position2 = streetAddress.LastIndexOf(peopleInfoCard.PeopleAddressCard?.City, StringComparison.InvariantCultureIgnoreCase);//igmo if city name is same with street name, we had an issue. so I edited like this. city name is always the last one, I think.
                                if (position == position2)
                                {
                                    streetAddress = streetAddress.Substring(0, position).Trim().TrimEnd(',').TrimEnd('.');
                                }
                                else
                                {
                                    streetAddress = streetAddress.Substring(0, position2).Trim().TrimEnd(',').TrimEnd('.');
                                }

                                isStreetFind = true;
                            }
                        }
                        else
                        {
                            isStreetFind = true;
                        }

                        #endregion
                    }
                    else
                    {
                        position = streetAddress.IndexOf(peopleInfoCard.PeopleAddressCard?.State, StringComparison.InvariantCultureIgnoreCase);
                        if (position > -1)
                        {
                            int position2 = streetAddress.LastIndexOf(peopleInfoCard.PeopleAddressCard?.State, StringComparison.InvariantCultureIgnoreCase);//igmo if city name is same with street name, we had an issue. so I edited like this. city name is always the last one, I think.
                            if (position == position2)
                            {
                                streetAddress = streetAddress.Substring(0, position).Trim().TrimEnd(',').TrimEnd('.');
                            }
                            else
                            {
                                streetAddress = streetAddress.Substring(0, position2).Trim().TrimEnd(',').TrimEnd('.');
                            }
                            isStreetFind = true;
                        }
                        else
                        {
                            position = streetAddress.IndexOf("Test", StringComparison.OrdinalIgnoreCase);
                            if (position > -1)
                            {
                                streetAddress = streetAddress.Substring(0, position).Trim().TrimEnd(',').TrimEnd('.');
                                isStreetFind = true;
                            }
                        }

                    }
                }

                if (isStreetFind)
                {
                    //Finding Apt
                    string[] streetAddressArr = streetAddress
                        .Split(new string[] { "\n", " ", ",", "." }, StringSplitOptions.RemoveEmptyEntries);

                    if (streetAddressArr.Any(x => !x.All(char.IsDigit)))
                    {
                        if (streetAddressArr.Length > 1 && (streetAddressArr.LastOrDefault()?.All(char.IsDigit) ?? false))
                        {
                            apt = peopleInfoCard.PeopleAddressCard.Zip != streetAddressArr.LastOrDefault().ToString() ? streetAddressArr.LastOrDefault().ToString() : null;
                            isAptFound = true;
                        }

                        if (!string.IsNullOrWhiteSpace(apt))
                        {
                            var addressComponent = peopleInfoCard.PeopleAddressCard.address_components?.Where(x => x.long_name.Contains(apt) || x.short_name.Contains(apt))?.FirstOrDefault();
                            if (addressComponent?.types?.Contains("route") == true)
                            {
                                apt = "";
                            }
                            else if (addressComponent?.long_name?.Contains($"unit {apt}", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                var oldValue = streetAddress;
                                streetAddress = streetAddress.Replace(addressComponent.long_name, "").Trim();
                                if (oldValue == streetAddress)
                                {
                                    streetAddress = streetAddress.Replace($"# {apt}", "", StringComparison.OrdinalIgnoreCase).Trim();
                                }
                                if (oldValue == streetAddress)
                                {
                                    streetAddress = streetAddress.Replace($"apt {apt}", "", StringComparison.OrdinalIgnoreCase).Trim();
                                }
                                if (oldValue == streetAddress && streetAddress.Trim().EndsWith(apt, StringComparison.OrdinalIgnoreCase))//igmo added to prevent apt. number exists in street address
                                {
                                    int lastIndex = streetAddress.LastIndexOf(apt);//check last index to be sure removed apt from street address, not street number
                                    streetAddress = streetAddress.Remove(lastIndex, apt.Length);
                                }
                            }
                            else
                            {
                                //streetAddress = streetAddress.Replace(apt, "").Trim();
                                int lastIndex = streetAddress.LastIndexOf(apt);//check last index to be sure removed apt from street address, not street number
                                streetAddress = streetAddress.Remove(lastIndex, apt.Length);

                                if (streetAddress.EndsWith("unit", StringComparison.OrdinalIgnoreCase))
                                {
                                    streetAddress = streetAddress.Replace("unit", "", StringComparison.OrdinalIgnoreCase).Trim();
                                }
                            }
                        }

                        if (string.IsNullOrWhiteSpace(apt) && peopleInfoCard.PeopleAddressCard.FormattedAddress.Contains("#"))
                        {
                            apt = peopleInfoCard.PeopleAddressCard.FormattedAddress.Split('#', ',')[1];
                            isAptFound = true;

                            if (!string.IsNullOrWhiteSpace(apt))
                            {
                                streetAddress = streetAddress.Replace($"#{apt}", "").Replace($"# {apt}", "").Trim();
                                //if (streetAddress.EndsWith("#"))
                                //{
                                //    streetAddress = streetAddress.Remove(streetAddress.Length - 1).Trim();
                                //}
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(apt) && peopleInfoCard.PeopleAddressCard.FullAddress.Contains("#"))
                        {
                            streetAddress = peopleInfoCard.PeopleAddressCard.FullAddress.Split('#')[0];

                            int pFrom = peopleInfoCard.PeopleAddressCard.FullAddress.IndexOf("#") + 1;
                            int pTo = 0;
                            if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard?.City))
                            {
                                pTo = peopleInfoCard.PeopleAddressCard.FullAddress.LastIndexOf(peopleInfoCard.PeopleAddressCard?.City);
                            }
                            else
                            {
                                var secondPart = peopleInfoCard.PeopleAddressCard.FullAddress.Split('#')[1];
                                pTo = secondPart.IndexOf(" ") + streetAddress.Length;
                            }

                            apt = peopleInfoCard.PeopleAddressCard.FullAddress.Substring(pFrom, pTo - pFrom).Trim();
                            isAptFound = true;
                            streetAddress = streetAddress.Trim();
                        }
                    }
                }
                else if (peopleInfoCard.PeopleAddressCard.address_components?.FirstOrDefault()?.types?.FirstOrDefault() == "intersection")
                {
                    streetAddress = peopleInfoCard.PeopleAddressCard.address_components.FirstOrDefault().short_name;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard.Street))
                    {
                        streetAddress = peopleInfoCard.PeopleAddressCard.Street;
                    }
                    else if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard.Cross))
                    {
                        streetAddress = peopleInfoCard.PeopleAddressCard.Cross;
                    }


                    //Finding Street Number and Apt
                    string[] fullAddressArr = peopleInfoCard.PeopleAddressCard.FullAddress
                        .Split(new string[] { "\n", " ", ",", "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (fullAddressArr.Any(x => !x.All(char.IsDigit)))
                    {
                        List<string> onlyNumericStr = fullAddressArr
                        .Where(x =>
                        !string.IsNullOrWhiteSpace(x) &&
                        x.All(char.IsDigit) &&
                        x != peopleInfoCard.PeopleAddressCard.Zip &&
                        x.Length < 4)
                        .ToList();

                        if (onlyNumericStr != null && onlyNumericStr.Count() > 0)
                        {
                            if (fullAddressArr?[0] == onlyNumericStr.FirstOrDefault())
                            {
                                streetAddress = fullAddressArr?[0] + " " + streetAddress;
                            }

                            if (onlyNumericStr.Count() == 1 && fullAddressArr?[0] != onlyNumericStr.FirstOrDefault())
                            {
                                apt = onlyNumericStr.FirstOrDefault();
                                isAptFound = true;
                            }
                            else if (onlyNumericStr.Count() > 1)
                            {
                                apt = onlyNumericStr.LastOrDefault();
                                isAptFound = true;
                            }
                        }
                    }
                }

                if (!isAptFound)
                {
                    if (peopleInfoCard.PeopleAddressCard.address_components?.FirstOrDefault()?.types?.FirstOrDefault() == "subpremise")
                    {
                        apt = peopleInfoCard.PeopleAddressCard.address_components.FirstOrDefault().short_name;

                        if (streetAddress.EndsWith(apt, StringComparison.OrdinalIgnoreCase)) //added this condition for "6 HERITAGE DRIVE D". It was making it "6 HERITAGE RIVE", apt: D
                        {
                            streetAddress = streetAddress.Substring(0, streetAddress.Length - apt.Length).Trim();
                        }
                    }
                    else //added this condition for "38 Phyllis Terrace E", it was not able remove E from street name to apt.
                    {
                        string[] streetAddressArr = streetAddress
                        .Split(new string[] { "\n", " ", ",", "." }, StringSplitOptions.RemoveEmptyEntries);

                        if (streetAddressArr.Last().Length == 1)
                        {
                            apt = streetAddressArr.Last();
                            streetAddress = streetAddress.Substring(0, streetAddress.Length - apt.Length).Trim();
                        }
                    }
                }

                if (peopleInfoCard.PeopleAddressCard.address_components?.Any(x => x.types.Contains("point_of_interest")) == true)
                {
                    var addressComponent = peopleInfoCard.PeopleAddressCard.address_components?.Where(x => x.types.Contains("point_of_interest")).FirstOrDefault();
                    streetAddress = streetAddress.Replace(addressComponent.long_name, "");

                    if (streetAddress.StartsWith(","))
                    {
                        streetAddress = streetAddress.Replace(",", "").Trim();
                    }
                }

                peopleInfoCard.PeopleAddressCard.Street = streetAddress;
                peopleInfoCard.PeopleAddressCard.Apt = apt;
            }
        }

        async Task<CallLocation> ConvertToCallLocationAsync(PeopleInfoCard peopleInfoCard, CallLocation callLocation)
        {
            if (peopleInfoCard != null)
            {
                if (peopleInfoCard.PeopleAddressCard != null)
                {
                    callLocation.fullAddress = peopleInfoCard.PeopleAddressCard.FullAddress;
                    if (!string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard.OriginalAddress) &&
                        peopleInfoCard.PeopleAddressCard.OriginalAddress != peopleInfoCard.PeopleAddressCard.FullAddress)
                    {
                        callLocation.addressFromLocationName = peopleInfoCard.PeopleAddressCard.OriginalAddress; // get location name from poi
                    }
                    if (peopleInfoCard.PeopleAddressCard.address_components?.Any(x => x.types.Contains("point_of_interest")) == true)
                    {
                        var addressComponent = peopleInfoCard.PeopleAddressCard.address_components?.Where(x => x.types.Contains("point_of_interest")).FirstOrDefault();
                        callLocation.locationName = addressComponent.long_name;
                    }
                    else if (peopleInfoCard.PeopleAddressCard.resultGeoType?.Equals("point_of_interest") == true && !string.IsNullOrWhiteSpace(peopleInfoCard.PeopleAddressCard.placeId))
                    {
                        var details = await Utilities.GetLocationNameFromLocationDetails(peopleInfoCard.PeopleAddressCard.placeId);
                        if (details != null)
                        {
                            callLocation.locationName = details.result?.name;
                        }
                    }
                    callLocation.state = peopleInfoCard.PeopleAddressCard.State;
                    callLocation.city = peopleInfoCard.PeopleAddressCard.City;
                    callLocation.township = peopleInfoCard.PeopleAddressCard.Township;
                    callLocation.street = peopleInfoCard.PeopleAddressCard.Street;
                    callLocation.cross = peopleInfoCard.PeopleAddressCard.Cross;
                    callLocation.apt = peopleInfoCard.PeopleAddressCard.Apt;
                    callLocation.floor = peopleInfoCard.PeopleAddressCard.Floor;
                    callLocation.room = peopleInfoCard.PeopleAddressCard.Room;
                    callLocation.zip = peopleInfoCard.PeopleAddressCard.Zip;
                    callLocation.stateShortName = peopleInfoCard.PeopleAddressCard.StateShortName;

                    callLocation.google_street = peopleInfoCard.PeopleAddressCard.GoogleStreet;
                    callLocation.google_cross = peopleInfoCard.PeopleAddressCard.GoogleCross;
                    callLocation.google_apt = peopleInfoCard.PeopleAddressCard.GoogleApt;
                }
                if (peopleInfoCard.PeopleLocationCard != null)
                {
                    callLocation.latitude = Convert.ToDecimal(peopleInfoCard.PeopleLocationCard.Latitude);
                    callLocation.longitude = Convert.ToDecimal(peopleInfoCard.PeopleLocationCard.Longitude);
                }
            }
            return callLocation;
        }

        #endregion
    }
}
