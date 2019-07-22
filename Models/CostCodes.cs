using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;


namespace RhumbixAPIConnector.Models
{
    public partial class CostCodes
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("erp_units")]
        public string ErpUnits { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }
    }

    public partial class CostCodes
    {

        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator CostCodes(Result r)
        {
            var t = new CostCodes
            {
                Code = r.Code,
                Description = r.Description,
                Units = r.Units,
                ErpUnits = r.ErpUnits,
                IsActive = r.IsActive,
                JobNumber = r.JobNumber,
                Group = r.Group
            };
            return t;
        }
        // Json deserializer
        public static CostCodes FromJson(string json) => JsonConvert.DeserializeObject<CostCodes>(json, RhumbixAPIConnector.Models.CostCodesConverter.Settings);
    }

    public static class CostCodesSerialize
    {
        public static string ToJson(this CostCodes self) => JsonConvert.SerializeObject(self, RhumbixAPIConnector.Models.CostCodesConverter.Settings);
    }

    internal static class CostCodesConverter
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
