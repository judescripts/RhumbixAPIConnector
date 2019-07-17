using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System.Collections.Generic;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class QueryResults
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("work_shift_key")]
        public string WorkShiftKey { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("cost_code")]
        public string CostCode { get; set; }

        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [JsonProperty("employee")]
        public string Employee { get; set; }

        [JsonProperty("foreman")]
        public string Foreman { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_approved")]
        public bool IsApproved { get; set; }

        [JsonProperty("over_time_minutes")]
        public long OverTimeMinutes { get; set; }

        [JsonProperty("double_time_minutes")]
        public long DoubleTimeMinutes { get; set; }

        [JsonProperty("standard_time_minutes")]
        public long StandardTimeMinutes { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        // Shift extra unique meta data
        [JsonProperty("created_on")]
        public string CreatedOn { get; set; }

        [JsonProperty("shift_start_time")]
        public string ShiftStartTime { get; set; }

        [JsonProperty("shift_end_time")]
        public string ShiftEndTime { get; set; }

        [JsonProperty("shift_date")]
        public string ShiftDate { get; set; }

        [JsonProperty("entry_name")]
        public string EntryName { get; set; }

        [JsonProperty("entry_store")]
        public EntrySelection EntryStore { get; set; }

        // Employees unique meta data
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

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

        public string AAType { get; set; }

        [Ignore]
        [JsonProperty("job_numbers")]
        public List<string> JobNumbers { get; set; }
    }


    public partial class QueryResults
    {
        public static QueryResults FromJson(string json) => JsonConvert.DeserializeObject<QueryResults>(json, QueryResultConverter.Settings);
    }

    public static class QueryResultSerialize
    {
        public static string ToJson(this QueryResults self) => JsonConvert.SerializeObject(self, QueryResultConverter.Settings);
    }

    internal static class QueryResultConverter
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
