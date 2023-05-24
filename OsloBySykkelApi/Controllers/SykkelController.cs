using Geolocation;
using Microsoft.AspNetCore.Mvc;
using OsloBySykkelApi.Models;
using OsloBySykkelApi.Services;

namespace OsloBySykkelApi.Controllers
{
    [ApiController]
    public class SykkelController : ControllerBase
    {
        private readonly IBySykkelService bySykkelService;
        private List<StationStatus> stationStatus;

        public SykkelController(IBySykkelService bySykkelService)
        {
            this.bySykkelService = bySykkelService;
        }

        [HttpGet("/stationinformation")]
        [ProducesResponseType(typeof(IEnumerable<StationInformationRoot>), 200)]
        public async Task<IActionResult> GetStationInformationAsync()
        {
            var stationInformation = await bySykkelService.GetStationInformationAsync();
            return Ok(stationInformation);
        }
        [HttpGet("/stationinstatus")]
        [ProducesResponseType(typeof(IEnumerable<StationStatusRoot>), 200)]
        public async Task<IActionResult> GetStationStatusAsync()
        {
            var stationInformation = await bySykkelService.GetStationStatusAsync();
            return Ok(stationInformation);
        }
        [HttpGet("/stations")]
        [ProducesResponseType(typeof(IEnumerable<StationModel>), 200)]

        public async Task<IActionResult> GetStations(double latitude,double longitude)
        {
            try
            {
                var allStationInformation = await bySykkelService.GetStationInformationAsync();
                var allStationStatus = await bySykkelService.GetStationStatusAsync();
                var stationInformation = allStationInformation.Data.Stations;
                var stationStatus = allStationStatus.Data.Stations;

                if (longitude>0 && latitude>0)
                {
                    stationInformation = stationInformation
                        .Where(_ => GeoCalculator.GetDistance(latitude, longitude,_.Lat,_.Lon)<0.5).ToList();
                }
                var stations = stationInformation.Select(x => new StationModel
                {
                    StationId = x.StationId,
                    Name = x.Name,
                    Address = x.Address,
                    Capacity = x.Capacity,
                    NumBikesAvailable = stationStatus.FirstOrDefault(_ => _.StationId == x.StationId)?.NumBikesAvailable,
                    NumDocksAvailable = stationStatus.FirstOrDefault(_ => _.StationId == x.StationId)?.NumDocksAvailable,
                    Distance = GeoCalculator.GetDistance(latitude, longitude, x.Lat, x.Lon)
                }).OrderBy(x=>x.Distance); 
                return Ok(stations);
            }
            catch (Exception ex)
            {
                return BadRequest("Your request for station data failed, please contact the customerservice via email: post@oslobysykkel.no");
            }

        }

    }
}
