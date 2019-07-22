using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class AbsencesHistory
    {
        [JsonProperty("work_shift_key")]
        public string WorkShiftKey { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("employee")]
        public string Employee { get; set; }

        [JsonProperty("shift_date")]
        public string ShiftDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_approved")]
        public bool IsApproved { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [JsonProperty("history_date")]
        public string HistoryDate { get; set; }

        [JsonProperty("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonProperty("history_type")]
        public string HistoryType { get; set; }
    }

    public partial class AbsencesHistory
    {
        // Explicit cast operator from QueryResult type to AbsencesHistory Type

        public static explicit operator AbsencesHistory(Result r)
        {
            var t = new AbsencesHistory
            {
                WorkShiftKey = r.WorkShiftKey,
                EndTime = r.EndTime,
                StartTime = r.StartTime,
                Employee = r.Employee,
                ShiftDate = r.ShiftDate,
                Status = r.Status,
                IsApproved = r.IsApproved,
                Type = r.Type,
                Timezone = r.Timezone,
                Id = r.Id,
                LastUpdated = r.LastUpdated,
                HistoryDate = r.HistoryDate,
                ModifiedBy = r.ModifiedBy,
                HistoryType = r.HistoryType
            };
            return t;
        }

        // Json deserializer
        public static AbsencesHistory FromJson(string json) => JsonConvert.DeserializeObject<AbsencesHistory>(json, RhumbixAPIConnector.Models.AbsencesHistoryConverter.Settings);
    }

    public static class AbsencesHistorySerialize
    {
        public static string ToJson(this AbsencesHistory self) => JsonConvert.SerializeObject(self, RhumbixAPIConnector.Models.AbsencesHistoryConverter.Settings);
    }

    internal static class AbsencesHistoryConverter
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

    internal class AbsencesHistoryParseStringConverter : JsonConverter
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