using Microsoft.AspNetCore.Mvc;

namespace OsloBySykkelApi.Models
{
    public class CoordinationModel
    {
        [FromQuery]
        public long Latitude { get; set; }
        [FromQuery]
        public long Longitude { get; set; }
    }
}
