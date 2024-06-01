using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Helpers;
using Domain.Entities;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using Helper;
using Helper.Enums;
using Mapster;
using Newtonsoft.Json;
using System.Xml;
namespace Infrastructure.Implementation.Services
{
    public class ShiftScheduleService : IShiftScheduleService
    {
        private readonly IShiftScheduleRepository _shiftRepository;
        private readonly IApplicationLogErrorRepository  _applicationLogErrorRepository;
        public ShiftScheduleService(IShiftScheduleRepository shiftScheduleRepository, IApplicationLogErrorRepository  applicationLogErrorRepository)
        {
            _shiftRepository = shiftScheduleRepository;
            _applicationLogErrorRepository = applicationLogErrorRepository;
        }

        public async Task<CommonResultResponseDto<IList<GridOptionRequestDto>>> GetAllColumnStates()
        {
            IList<GridOptionRequestDto> result = await _shiftRepository.GetAllColumnStates();
            return CommonResultResponseDto<IList<GridOptionRequestDto>>.Success(new string[] { ActionStatusHelper.Success }, result, 0);
        }

        public async Task<CommonResultResponseDto<AutoDismissCallRequestDto>> GetAutoDismissCallSettings()
        {

           AutoDismissCallRequestDto result = new AutoDismissCallRequestDto();
            Setting getSettingName = await _shiftRepository.GetSettingsByName(ConstantVariables.SETTINGS_AUTO_DISMISS_CALL);

            var setting = getSettingName;
            var callTextDto = JsonConvert.DeserializeObject<AutoDismissCallRequestDto>(setting.JsonProperties);

            result = callTextDto;

            return CommonResultResponseDto<AutoDismissCallRequestDto>.Success(new string[] { ActionStatusHelper.Success }, result);
        }

        public async Task<CommonResultResponseDto<IList<ShiftSchedulePlanDatasResponseDto>>> GetShiftSchedulePlanData(int shiftTypeId)
        {
            IList<ShiftSchedulePlanDataResponseDto> result = await _shiftRepository.GetShiftSchedulePlanData(shiftTypeId);
            IList<ShiftSchedulePlanDatasResponseDto> planDatas = result.GroupBy(x => new {
                x.shiftScheduleId,
                x.shiftScheduleName,
                x.shiftTypeId,
                x.startTime,
                x.endTime
            }).Select(x => new ShiftSchedulePlanDatasResponseDto()
            {
                shiftScheduleId = x.Key.shiftScheduleId,
                shiftScheduleName = x.Key.shiftScheduleName,
                shiftTypeId = x.Key.shiftTypeId,
                startTime = x.Key.startTime,
                endTime = x.Key.endTime,
                shiftSchedulePlans = x.Select(y => new ShiftSchedulePlanResponseDto
                {
                    dayOfWeek = y.dayOfWeek,
                    dayOfWeekName = y.dayOfWeekName,
                    shiftSchedulePlanId = y.shiftSchedulePlanId,
                    shiftSchedulePlanStatus = y.shiftSchedulePlanStatus
                }).ToList()
            }).ToList();
            return CommonResultResponseDto<IList<ShiftSchedulePlanDatasResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, planDatas, 0);
        }

        public async Task<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>> GetShiftScheduleTakeDataAdmin(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate)
        {
            var result = await _shiftRepository.GetShiftScheduleTakeDataAdmin(shiftTypeId, scheduleStartDate, scheduleEndDate);
            return CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>.Success(new string[] { ActionStatusHelper.Success }, result, 0);

        }
        public async Task<CommonResultResponseDto<AllMembersClassifiedForShiftResponseDto>> GetMembersForShiftSchedule()
        {
            var classifiedMembers = new AllMembersClassifiedForShiftResponseDto();
            var brc = await _shiftRepository.GetMembersForShiftSchedule();
            classifiedMembers.DispatcherMembers = brc.allMembersResponseForShiftViewModels.Where(x => x.isDispatcher == true).GroupBy(y => new { y.userId, y.badgeNumber })
                .Select(x => new RelatedMembersResponseDto { badgeNumber = x.Key.badgeNumber, userId = x.Key.userId }).ToList();
            classifiedMembers.EmsMembers = brc.allMembersResponseForShiftViewModels.Where(x => x.emergencyType == "EMS").GroupBy(y => new { y.userId, y.badgeNumber })
                .Select(x => new RelatedMembersResponseDto { badgeNumber = x.Key.badgeNumber, userId = x.Key.userId }).ToList();
            classifiedMembers.AlsMembers = brc.allMembersResponseForShiftViewModels.Where(x => x.expertise == "ALS").GroupBy(y => new { y.userId, y.badgeNumber })
                .Select(x => new RelatedMembersResponseDto { badgeNumber = x.Key.badgeNumber, userId = x.Key.userId }).ToList();
            classifiedMembers.FireMembers = brc.allMembersResponseForShiftViewModels.Where(x => x.emergencyType == "Fire").GroupBy(y => new { y.userId, y.badgeNumber })
                .Select(x => new RelatedMembersResponseDto { badgeNumber = x.Key.badgeNumber, userId = x.Key.userId }).ToList();

            return CommonResultResponseDto<AllMembersClassifiedForShiftResponseDto>.Success(new string[] { ActionStatusHelper.Success }, classifiedMembers, 0);
        }

        public async Task<CommonResultResponseDto<IList<ShiftTypesResponseDto>>> GetRequestShiftTypes()
        {
            var result = await _shiftRepository.GetRequestShiftTypes();
            return CommonResultResponseDto<IList<ShiftTypesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, result, 0);
        }

        public async Task<CommonResultResponseDto<CreateShiftScheduleRequestDto>> CreateShiftScheduleRequest(CreateShiftScheduleRequestDto shiftScheduleRequest)
        {
            await _shiftRepository.CreateShiftScheduleRequest(shiftScheduleRequest);
            return CommonResultResponseDto<CreateShiftScheduleRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateShiftSchedulePlanData(ShiftSchedulePlansRequestDto selectedShiftSchedules)
        {


            var currentPlans = await _shiftRepository.GetShiftSchedulePlansByShiftType(ShiftSchedulePlansByShiftTypeXml(selectedShiftSchedules), selectedShiftSchedules.ShiftSchedulesDto.FirstOrDefault()?.shiftTypeId ?? 0);


            if (currentPlans.Count > 0)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }

        }

        public async Task<CommonResultResponseDto<string>> SoftDeleteShiftSchedule(int shiftScheduleId)
        {
            string deleteShiftScheduleId = await _shiftRepository.SoftDeleteShiftSchedule(shiftScheduleId);
            if (!string.IsNullOrEmpty(deleteShiftScheduleId))
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<string>> EditShiftSchedule(EditShiftScheduleRequestDto editShiftScheduleRequest)
        {
            var editShiftScheduleId = await _shiftRepository.EditShiftSchedule(editShiftScheduleRequest.Adapt<EditShiftScheduleRequestDto>());
            if (editShiftScheduleId > 0)
            {

                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, editShiftScheduleId);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }

        }

        public async Task<CommonResultResponseDto<string>> AddShifts(ShiftScheduleDataRequestDto shiftScheduleData)
        {
            int response = 0;

            ShiftScheduleTake shiftScheduleTake = new ShiftScheduleTake()
            {
                CreatedDate = DateTime.Now,
                Status = (int)AppEnums.Status.Active,
                IsTaken = true,
                MembersId = shiftScheduleData.selectedMemberId,
                ScheduleDate = shiftScheduleData.scheduleDate,
                ShiftScheduleId = shiftScheduleData.selectedShiftTime,
                CreatedBy = shiftScheduleData.loggedInUserId,
                IsCustom = shiftScheduleData.isCustom,
                CustomId = shiftScheduleData.customId
            };

            string shiftScheduleDataString = JsonConvert.SerializeObject(shiftScheduleData);
            if (shiftScheduleData.isWeekly == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;
                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }
                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);

                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(7);
                }
            }
            else if (shiftScheduleData.isBiweekly == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;
                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);

                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(14);
                }
            }
            else if (shiftScheduleData.isEvery3Weeks == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;
                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(21);
                }

            }
            else if (shiftScheduleData.isEvery4Weeks == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;

                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(28);
                }

            }
            else if (shiftScheduleData.isEvery5Weeks == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;

                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(35);
                }

            }
            else if (shiftScheduleData.isEvery6Weeks == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;

                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(42);
                }
            }
            else if (shiftScheduleData.isEvery7Weeks == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;

                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(49);
                }
            }
            else if (shiftScheduleData.isEvery8Weeks == true)
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    shiftScheduleTake.ScheduleDate = shiftScheduleData.scheduleDate;
                    shiftScheduleTake.Id = 0;

                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                    shiftScheduleData.scheduleDate = shiftScheduleData.scheduleDate.AddDays(56);
                }
            }
            else
            {
                while (shiftScheduleData.scheduleDate.Date <= shiftScheduleData.endDate?.Date)
                {
                    var existingDetails = await GetShiftScheduleCheckMembersID(shiftScheduleTake);

                    if (existingDetails != null)
                    {
                        if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.MemberID }, null);
                        }
                    }

                    response = await _shiftRepository.AddShiftScheduleTake(shiftScheduleTake);


                    if (response > 0)
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} added shift. TakeId: {shiftScheduleTake.Id}, ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Success"));
                    }
                    else
                    {
                        await _applicationLogErrorRepository.AddApplicationLogError(new ApplicationLog("ShiftScheduleController", "AddShifts", $"User: {shiftScheduleData.loggedInUserId} failed to add shift. ScheduleDate: {shiftScheduleTake.ScheduleDate},  ShiftScheduleId: {shiftScheduleTake.ShiftScheduleId}, CustomId: {shiftScheduleTake.CustomId}, MembersId: {shiftScheduleTake.MembersId}", shiftScheduleDataString, "Failed"));
                    }
                }
            }
            if (response > 0)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, response);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }

        }

        public async Task<CommonResultResponseDto<string>> DeleteShifts(DeleteShiftsRequestDto deleteShiftsRequestDto)
        {
            var result = await _shiftRepository.DeleteShifts(deleteShiftsRequestDto);
            if (result > 0)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, result);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<ShiftScheduleTake> GetShiftScheduleCheckMembersID(ShiftScheduleTake shiftScheduleTake)
        {
            var existingDetails = await _shiftRepository.GetShiftScheduleCheckMembersID(shiftScheduleTake);
            if (existingDetails != null)
            {
                if (existingDetails.MembersId.Equals(shiftScheduleTake.MembersId))
                {
                    return existingDetails;
                }
                existingDetails.IsTaken = false;
                if (existingDetails.StartTime != null && existingDetails.EndTime != null)
                {
                    shiftScheduleTake.StartTime = existingDetails.StartTime;
                    shiftScheduleTake.EndTime = existingDetails.EndTime;
                }
                existingDetails.Status = (int)AppEnums.Status.Deleted;
                existingDetails.UpdatedDate = DateTime.UtcNow;
                existingDetails.UpdatedBy = existingDetails.CreatedBy;
                await _shiftRepository.SoftDeleteShiftScheduleTake(existingDetails);
            }
            return existingDetails;
        }

        public async Task<CommonResultResponseDto<IList<EmsMembersResponseDto>>> GetAllEmsMembers()
        {
            var getAllEmsMembers = await _shiftRepository.GetAllEmsMembers();
            return CommonResultResponseDto<IList<EmsMembersResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getAllEmsMembers, 0);
        }

        public async Task<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>> GetShiftScheduleTakeDataAdminForPrint(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate)
        {
            var result = await _shiftRepository.GetShiftScheduleTakeDataAdminForPrint(shiftTypeId, scheduleStartDate, scheduleEndDate);
            return CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>.Success(new string[] { ActionStatusHelper.Success }, result, 0);
        }
        #region private
        private static string ShiftSchedulePlansByShiftTypeXml(ShiftSchedulePlansRequestDto shiftSchedulePlanrequestDtoList)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);

            foreach (var findItems in shiftSchedulePlanrequestDtoList.ShiftSchedulesDto)
            {
                XmlNode doorSelectionNode = xmlDocument.CreateElement("ShiftSchedulePlansByShiftTypeXml");
                XmlAttribute attribute = xmlDocument.CreateAttribute("shiftScheduleId");
                attribute.Value = findItems.shiftScheduleId.ToString();
                doorSelectionNode.Attributes.Append(attribute);
                rootNode.AppendChild(doorSelectionNode);

                attribute = xmlDocument.CreateAttribute("dayOfWeek");
                attribute.Value = findItems.dayOfWeek.ToString();
                doorSelectionNode.Attributes.Append(attribute);
                rootNode.AppendChild(doorSelectionNode);

                attribute = xmlDocument.CreateAttribute("shiftTypeId");
                attribute.Value = findItems.shiftTypeId.ToString();
                doorSelectionNode.Attributes.Append(attribute);
                rootNode.AppendChild(doorSelectionNode);

            }

            return xmlDocument.OuterXml;
        }
        #endregion

    }
}
