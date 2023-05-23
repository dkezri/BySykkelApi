using Newtonsoft.Json;

namespace OsloBySykkelApi.Models
{
    public class SystemInformation
    {
        [JsonProperty("last_updated")]
        public int LastUpdated { get; set; }
        public int Ttl { get; set; }
        public SystemData Data { get; set; }
    }
    public class SystemData
    {
        [JsonProperty("system_id")]
        public string SystemId { get; set; }

        public string Language { get; set; }
        public string Name { get; set; }
        public string Operator { get; set; }
        public string Timezone { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }

 }
