using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RhumbixAPIConnector.Annotations;
using System;
using System.ComponentModel;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    public partial class Absences : INotifyPropertyChanged
    {
        [JsonProperty("work_shift_key")]

        private string _workShiftKey;
        public string WorkShiftKey
        {
            get => _workShiftKey;
            set
            {
                _workShiftKey = value;
                OnPropertyChanged("WorkShiftKey");
            }
        }

        [JsonProperty("end_time")]
        private string _endTime;

        public string EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }

        }


        [JsonProperty("start_time")]
        private string _startTime;

        public string StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }


        [JsonProperty("employee")]
        private string _employee;

        public string Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged("Employee");
            }
        }

        [JsonProperty("shift_date")]
        private string _shiftDate;

        public string ShiftDate
        {
            get => _shiftDate;
            set
            {
                _shiftDate = value;
                OnPropertyChanged("ShiftDate");
            }
        }


        [JsonProperty("status")]
        private string _status;

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        [JsonProperty("is_approved")]
        private bool _isApproved;

        public bool IsApproved
        {
            get => _isApproved;
            set
            {
                _isApproved = value;
                OnPropertyChanged("IsApproved");
            }
        }

        [JsonProperty("type")]
        private string _type;

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        [JsonProperty("timezone")]
        private string _timezone;

        public string Timezone
        {
            get => _timezone;
            set
            {
                _timezone = value;
                OnPropertyChanged("Timezone");
            }
        }

        [JsonProperty("id")]
        private string _id;

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        [JsonProperty("last_updated")]
        private string _lastUpdated;

        public string LastUpdated
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                OnPropertyChanged("LastUpdated");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
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
