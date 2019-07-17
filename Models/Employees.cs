using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System.Collections.Generic;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class Employee
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [PrimaryKey]
        [JsonProperty("company_supplied_id")]
        public string CompanySuppliedId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("user_role")]
        public string UserRole { get; set; }

        [JsonProperty("trade")]
        public string Trade { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [Ignore]
        [JsonProperty("job_numbers")]
        public List<string> JobNumbers { get; set; }
    }

    public partial class Employee
    {
        public static explicit operator Employee(Result r)
        {
            var e = new Employee()
            {
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email,
                CompanySuppliedId = r.CompanySuppliedId,
                Phone = r.Phone,
                Classification = r.Classification,
                UserRole = r.UserRole,
                Trade = r.Trade,
                IsActive = r.IsActive,
                JobNumbers = r.JobNumbers
            };
            return e;
        }

        public static Employee FromJson(string json) => JsonConvert.DeserializeObject<Employee>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Employee self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
