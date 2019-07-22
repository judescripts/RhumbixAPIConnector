using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace RhumbixAPIConnector.Models
{
    /// <summary>
    /// Rhumbix API projects model and explicit casts
    /// </summary>
    public partial class Project
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("job_number")]
        public string JobNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("require_signature")]
        public string RequireSignature { get; set; }
    }

    public partial class Project
    {
        // Explicit cast operator from QueryResult type to Timekeeping type
        public static explicit operator Project(Result r)
        {
            var p = new Project()
            {
                Status = r.Status,
                Description = r.Description,
                Address = r.Address,
                JobNumber = r.JobNumber,
                Name = r.Name,
                Timezone = r.Timezone,
                RequireSignature = r.RequireSignature
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
