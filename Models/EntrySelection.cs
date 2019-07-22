using Newtonsoft.Json;
using SQLite;

namespace RhumbixAPIConnector.Models
{
    public class EntrySelection
    {
        [Indexed]
        public string Employee { get; set; }
        [PrimaryKey, Indexed]
        public long Id { get; set; }

        [JsonProperty("A/AType")]
        public string AAType { get; set; }

        [JsonProperty("Select A ($65) or B ($25)")]
        public string SelectA65OrB25 { get; set; }
    }
}
