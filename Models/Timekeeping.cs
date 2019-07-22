using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    /// <summary>
    /// Rhumbix API timekeeping object model and explicit casts
    /// </summary>
    public partial class Timekeeping
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [Indexed]
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

        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [Indexed]
        [JsonProperty("employee")]
        public string Employee { get; set; }

        [Indexed]
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

    public partial class Timekeeping
    {
        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator Timekeeping(Result r)
        {
            var t = new Timekeeping
            {
                WorkShiftKey = r.WorkShiftKey,
                ShiftDate = r.ShiftDate,
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
            return t;
        }
        // Json deserializer
        public static Timekeeping FromJson(string json) => JsonConvert.DeserializeObject<Timekeeping>(json, TimeKeepingConverter.Settings);
    }

    public static class TimeKeepingSerialize
    {
        public static string ToJson(this Timekeeping self) => JsonConvert.SerializeObject(self, TimeKeepingConverter.Settings);
    }
    internal static class TimeKeepingConverter
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
