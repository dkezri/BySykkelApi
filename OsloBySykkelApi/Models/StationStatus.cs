using Newtonsoft.Json;

namespace OsloBySykkelApi.Models
{
    public class StationStatusRoot
    {
        [JsonProperty("last_updated")]
        public int LastUpdated { get; set; }
        public SatationStatusData Data { get; set; }
    }
    public class SatationStatusData
    {
        public List<StationStatus> Stations { get; set; }
    }


    public class StationStatus
    {
        [JsonProperty("is_installed")]
        public bool IsInstalled { get; set; }

        [JsonProperty("is_renting")]
        public bool IsRenting { get; set; }

        [JsonProperty("is_returning")]
        public bool IsReturning { get; set; }

        [JsonProperty("num_bikes_available")]
        public int NumBikesAvailable { get; set; }

        [JsonProperty("num_docks_available")]
        public int NumDocksAvailable { get; set; }

        [JsonProperty("last_reported")]
        public int LastReported { get; set; }

        [JsonProperty("station_id")]
        public string StationId { get; set; }
    }

}
