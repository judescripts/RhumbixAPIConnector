using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;

namespace RhumbixAPIConnector.Models
{
    public partial class Project
    {
        [PrimaryKey, Indexed]
        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [Ignore]
        [JsonProperty("work_shift_key")]
        public string WorkShiftKey { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("shift_date")]
        public string ShiftDate { get; set; }

        [JsonProperty("cost_code")]
        public string CostCode { get; set; }

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

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }
    }

    public partial class Project
    {
        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator Project(Result r)
        {
            var p = new Project()
            {
                WorkShiftKey = r.WorkShiftKey,
                EndTime = r.EndTime,
                StartTime = r.StartTime,
                CostCode = r.CostCode,
                JobNumber = r.JobNumber,
                Employee = r.Employee,
                Foreman = r.Foreman,
                Status = r.Status,
                IsApproved = r.IsApproved,
                OverTimeMinutes = r.OverTimeMinutes,
                DoubleTimeMinutes = r.DoubleTimeMinutes,
                StandardTimeMinutes = r.StandardTimeMinutes,
                Timezone = r.Timezone,
                Id = r.Id,
                LastUpdated = r.LastUpdated
            };
            return p;
        }
        public static Project FromJson(string json) => JsonConvert.DeserializeObject<Project>(json, ProjectConverter.Settings);
    }

    public static class ProjectSerialize
    {
        public static string ToJson(this Project self) => JsonConvert.SerializeObject((object)self, (JsonSerializerSettings)ProjectConverter.Settings);
    }

    internal static class ProjectConverter
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
