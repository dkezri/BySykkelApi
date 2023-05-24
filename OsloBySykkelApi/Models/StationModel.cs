using Newtonsoft.Json;

namespace OsloBySykkelApi.Models
{
    public class StationModel
    {
        public string StationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public int? NumBikesAvailable { get; set; }
        public int? NumDocksAvailable { get; set; }
        public double Distance { get; set; }
    }
}
