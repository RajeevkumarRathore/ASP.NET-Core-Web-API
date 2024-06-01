using Application.Handler.Header.Dtos.CallLoaction.Response;
using Application.Handler.Header.Dtos.GoogleApi;
using Newtonsoft.Json;
using System.Web;

namespace Application.Common.Helpers
{
    public static class Utilities
    {
        public static string ConvertToTwillioPhone(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                value = new string(value.Where(char.IsDigit).ToArray());
                value = value.Length == 10 ? "+1" + value : "+" + value;
            }
            return value;
        }

        public static async Task<GeoContent> GetAddress(string location)
        {
            try
            {
                string param = "?latlng=" + location.Replace(" ", "").Replace("(", "").Replace(")", "") + "&key=" + ConstantVariables.API_KEY;
                string url = "https://maps.googleapis.com/maps/api/geocode/json";

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url + param);
                response.EnsureSuccessStatusCode();
                GeoContent geoContent = JsonConvert.DeserializeObject<GeoContent>(await response.Content.ReadAsStringAsync());
                //geoContent.results = geoContent.results.Where(x => x.types.Contains("route")).ToList();
                return geoContent;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string CreateLatLng(double lat, double lng)
        {
            return $"{lat},{lng}";
        }

        public static async Task<SearchAutocompleteResult> SearchHospitals(string searchText)
        {
            try
            {
                searchText = HttpUtility.UrlEncode(searchText);
                string param = $"?input={searchText}&key={ConstantVariables.API_KEY}" +
                    $"&location={ConstantVariables.MONSEY_NY_LAT_LONG}&radius={ConstantVariables.RADIUS_SEARCH_AREA}&types=hospital";
                string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json";

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url + param);
                response.EnsureSuccessStatusCode();
                var a = await response.Content.ReadAsStringAsync();
                SearchAutocompleteResult searchLocation = JsonConvert.DeserializeObject<SearchAutocompleteResult>(await response.Content.ReadAsStringAsync());
                searchLocation.predictions = searchLocation.predictions.OrderByDescending(x => x.description.Contains("Monroe")).ToList();

                return searchLocation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<GeoContent> GetLocation(string address)
        {
            try
            {
                string addressEncoded = HttpUtility.UrlEncode(address.Trim());
                string param = "?address=" + addressEncoded + "&key=" + ConstantVariables.API_KEY;
                string url = "https://maps.googleapis.com/maps/api/geocode/json";

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url + param);
                response.EnsureSuccessStatusCode();
                GeoContent geoContent = JsonConvert.DeserializeObject<GeoContent>(await response.Content.ReadAsStringAsync());

                if (geoContent.results?.Count >= 2)
                {
                    if (address.IndexOf("&") > -1)
                    {
                        address = address.Replace("&", "");
                        addressEncoded = HttpUtility.UrlEncode(address.Trim());
                        param = "?address=" + addressEncoded + "&key=" + ConstantVariables.API_KEY;
                        response = await client.GetAsync(url + param);
                        response.EnsureSuccessStatusCode();
                        geoContent = JsonConvert.DeserializeObject<GeoContent>(await response.Content.ReadAsStringAsync());
                    }
                }
                return geoContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string OnlyNumeric(string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? new string(value.Where(Char.IsDigit).ToArray()) : null;
        }

        public static async Task<AddressDetails> GetLocationNameFromLocationDetails(string locationId)
        {
            try
            {
                string param = $"?place_id={locationId}&key={ConstantVariables.API_KEY}";
                string url = "https://maps.googleapis.com/maps/api/place/details/json";

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url + param);
                response.EnsureSuccessStatusCode();
                var a = await response.Content.ReadAsStringAsync();
                AddressDetails addressDetails = JsonConvert.DeserializeObject<AddressDetails>(await response.Content.ReadAsStringAsync());
                return addressDetails;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string TrimAndReplaceMemberBadgeNumber(string badgeNumber)
        {
            if (!string.IsNullOrWhiteSpace(badgeNumber))
            {
                badgeNumber = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(badgeNumber.Trim(), "^KY", "K"), "^Medic", "M");
            }
            return badgeNumber;
        }

        public static string UntrimAndReplaceMemberBadgeNumber(string badgeNumber)
        {
            if (!string.IsNullOrWhiteSpace(badgeNumber) && (!badgeNumber.StartsWith("KY") && !badgeNumber.StartsWith("Medic")))
            {
                badgeNumber = System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(badgeNumber.Trim(), "^K", "KY"), "^M", "Medic");
            }
            return badgeNumber;
        }

        public static List<string> ConvertMemberStringToListOfBadgeNumbers(string memberString)
        {
            var result = memberString?.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList() ?? new List<string>();
            return result;
        }

        public static string SetRealPath(string appSettingsPath)
        {
            if (Path.IsPathRooted(appSettingsPath))
            {
                return appSettingsPath;
            }
            else
            {
                //Expects LakewoodFiles folder on the same folder level of the project. (Not inside.)
                string folderPath = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(folderPath, "LakewoodFiles");
                int i = 0; //Try at most 10 level up.
                while (!Directory.Exists(path) && i < 10)
                {
                    folderPath = Path.Combine(folderPath, "..");
                    path = Path.Combine(folderPath, "LakewoodFiles");
                    i++;
                }
                path = Path.Combine(folderPath, appSettingsPath);
                Directory.CreateDirectory(path);
                return path;
            }
        }

    }
 
}
