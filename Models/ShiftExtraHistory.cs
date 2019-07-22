using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SQLite;
using System;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class ShiftExtraHistory
    {
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

        [JsonProperty("employee")]
        public string Employee { get; set; }

        [JsonProperty("entry_name")]
        public string EntryName { get; set; }
        [Ignore]

        [JsonProperty("entry_store")]
        public EntrySelection EntryStore { get; set; }

        [JsonProperty("is_approved")]
        public bool IsApproved { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [JsonProperty("history_date")]
        public string HistoryDate { get; set; }

        [JsonProperty("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonProperty("history_type")]
        public string HistoryType { get; set; }
    }

    public partial class ShiftExtraHistory
    {
        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator ShiftExtraHistory(Result r)
        {
            var t = new ShiftExtraHistory()
            {
                WorkShiftKey = r.WorkShiftKey,
                CreatedOn = r.CreatedOn,
                ShiftStartTime = r.ShiftStartTime,
                ShiftEndTime = r.ShiftEndTime,
                ShiftDate = r.ShiftDate,
                Employee = r.Employee,
                EntryName = r.EntryName,
                EntryStore = r.EntryStore,
                IsApproved = r.IsApproved,
                Status = r.Status,
                Timezone = r.Timezone,
                Id = r.Id,
                JobNumber = r.JobNumber,
                LastUpdated = r.LastUpdated,
                HistoryDate = r.HistoryDate,
                ModifiedBy = r.ModifiedBy,
                HistoryType = r.HistoryType
            };
            return t;
        }
        // Json deserializer
        public static ShiftExtraHistory FromJson(string json) => JsonConvert.DeserializeObject<ShiftExtraHistory>(json, RhumbixAPIConnector.Models.ShiftExtraHistoryConverter.Settings);
    }

    public static class ShiftExtraHistorySerialize
    {
        public static string ToJson(this ShiftExtraHistory self) => JsonConvert.SerializeObject(self, RhumbixAPIConnector.Models.ShiftExtraHistoryConverter.Settings);
    }

    internal static class ShiftExtraHistoryConverter
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

    internal class ShiftExtraHistoryParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}