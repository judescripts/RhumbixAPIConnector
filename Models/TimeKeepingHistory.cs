﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class TimekeepingHistory
    {
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

    public partial class TimekeepingHistory
    {
        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator TimekeepingHistory(Result r)
        {
            var s = new TimekeepingHistory()
            {
                WorkShiftKey = r.WorkShiftKey,
                EndTime = r.EndTime,
                StartTime = r.StartTime,
                ShiftDate = r.ShiftDate,
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
                LastUpdated = r.LastUpdated,
                HistoryDate = r.HistoryDate,
                ModifiedBy = r.ModifiedBy,
                HistoryType = r.HistoryType
            };
            return s;
        }

        // Json deserializer
        public static TimekeepingHistory FromJson(string json) => JsonConvert.DeserializeObject<TimekeepingHistory>(json, RhumbixAPIConnector.Models.TimeKeepingHistoryConverter.Settings);
    }

    public static class TimeKeepingHistorySerialize
    {
        public static string ToJson(this TimekeepingHistory self) => JsonConvert.SerializeObject(self, RhumbixAPIConnector.Models.TimeKeepingHistoryConverter.Settings);
    }

    internal static class TimeKeepingHistoryConverter
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

    internal class TimeKeepingHistoryParseStringConverter : JsonConverter
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