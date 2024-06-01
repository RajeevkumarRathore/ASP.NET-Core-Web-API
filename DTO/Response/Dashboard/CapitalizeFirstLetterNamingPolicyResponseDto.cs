using System.Text.Json;

namespace DTO.Response.Dashboard
{
    public class CapitalizeFirstLetterNamingPolicyResponseDto : JsonNamingPolicy
    {
        private readonly string propertyNameToCapitalize;

        public CapitalizeFirstLetterNamingPolicyResponseDto(string propertyNameToCapitalize)
        {
            this.propertyNameToCapitalize = propertyNameToCapitalize;
        }

        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            // Capitalize the first letter only for the specified property
            return name.Equals(propertyNameToCapitalize, StringComparison.OrdinalIgnoreCase)
                ? char.ToUpper(name[0]) + name.Substring(1)
                : name.ToLower();
        }
    }
}
