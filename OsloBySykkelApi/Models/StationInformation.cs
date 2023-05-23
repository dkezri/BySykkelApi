using Newtonsoft.Json;

namespace OsloBySykkelApi.Models
{
   

    public class StationInformationRoot
    {
        [JsonProperty("last_updated")]
        public int LastUpdated { get; set; }
        public StationInformaionData Data { get; set; }
    }
    public class StationInformaionData
    {
        public List<StationInformation> Stations { get; set; }
    }

    public class StationInformation
    {
        [JsonProperty("station_id")]
        public string StationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Capacity { get; set; }
    }
}
