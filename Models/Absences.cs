using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class Absences
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
    }

    public partial class Absences
    {
        // Explicit cast operator from QueryResult type to Absenses type

        public static explicit operator Absences(Result r)
        {
            var t = new Absences
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
                LastUpdated = r.LastUpdated
            };

            return t;
        }

        // Json deserializer
        public static Absences FromJson(string json) => JsonConvert.DeserializeObject<Absences>(json, RhumbixAPIConnector.Models.AbsencesConverter.Settings);
    }

    public static class AbsencesSerialize
    {
        public static string ToJson(this Absences self) => JsonConvert.SerializeObject(self, RhumbixAPIConnector.Models.AbsencesConverter.Settings);
    }

    internal static class AbsencesConverter
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

    internal class ParseStringConverter : JsonConverter
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
