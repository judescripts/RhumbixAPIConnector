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
    }
}
