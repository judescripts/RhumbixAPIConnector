using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    /// <summary>
    /// Rhumbix API shift extra object model and explicit casts
    /// </summary>
    public partial class ShiftExtra
    {
        [PrimaryKey, Indexed]
        [JsonProperty("id")]
        public string Id { get; set; }

        [Indexed]
        [JsonProperty("work_shift_key")]
        public string WorkShiftKey { get; set; }

        [JsonProperty("created_on")]
        public string CreatedOn { get; set; }

        [JsonProperty("shift_start_time")]
        public string ShiftStartTime { get; set; }

        [JsonProperty("shift_end_time")]
        public string ShiftEndTime { get; set; }

        [JsonProperty("shift_date")]
        public string ShiftDate { get; set; }

        [Indexed]
        [JsonProperty("employee")]
        public string Employee { get; set; }

        [JsonProperty("entry_name")]
        public string EntryName { get; set; }

        [JsonProperty("is_approved")]
        public bool IsApproved { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [Ignore]
        [JsonProperty("entry_store")]
        public EntrySelection EntryStore { get; set; }
        public string AAType { get; set; }

    }

    public partial class ShiftExtra
    {
        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator ShiftExtra(Result r)
        {
            var s = new ShiftExtra()
            {
                WorkShiftKey = r.WorkShiftKey,
                JobNumber = r.JobNumber,
                Employee = r.Employee,
                Status = r.Status,
                IsApproved = r.IsApproved,
                Timezone = r.Timezone,
                Id = r.Id,
                LastUpdated = r.LastUpdated,
                CreatedOn = r.CreatedOn,
                ShiftStartTime = r.ShiftStartTime,
                ShiftEndTime = r.ShiftEndTime,
                ShiftDate = r.ShiftDate,
                EntryName = r.EntryName,
                AAType = r.AAType,
            };
            return s;
        }
        // Json deserializer
        public static ShiftExtra FromJson(string json) => JsonConvert.DeserializeObject<ShiftExtra>(json, ShiftExtraConverter.Settings);
    }

    public static class ShiftExtraSerialize
    {
        public static string ToJson(this ShiftExtra self) => JsonConvert.SerializeObject(self, ShiftExtraConverter.Settings);
    }

    internal static class ShiftExtraConverter
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

