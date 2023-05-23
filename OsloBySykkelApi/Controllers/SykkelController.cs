using Microsoft.AspNetCore.Mvc;
using OsloBySykkelApi.Models;
using OsloBySykkelApi.Services;

namespace OsloBySykkelApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SykkelController : ControllerBase
    {
        private readonly IBySykkelService bySykkelService;

        public SykkelController(IBySykkelService bySykkelService)
        {
            this.bySykkelService = bySykkelService;
        }

        [HttpGet("/stationinformation")]
        public async Task<IActionResult> GetStationInformations()
        {
            var stationInformation = await bySykkelService.GetStationInformationAsync();
            return Ok(stationInformation);
        }
        [HttpGet("/stations")]
        [ProducesResponseType(typeof(IEnumerable<StationModel>), 200)]

        public async Task<IActionResult> GetStations()
        {
            try
            {
                var allStationInformation = await bySykkelService.GetStationInformationAsync();
                var allStationStatus = await bySykkelService.GetStationStatus();

                var stationStatuses = allStationStatus.Data.Stations;
                var stations = allStationInformation.Data.Stations.Select(x => new StationModel
                {
                    StationId = x.StationId,
                    Name = x.Name,
                    Address = x.Address,
                    Capacity = x.Capacity,
                    NumBikesAvailable = stationStatuses.FirstOrDefault(_ => _.StationId == x.StationId)?.NumBikesAvailable,
                    NumDocksAvailable = stationStatuses.FirstOrDefault(_ => _.StationId == x.StationId)?.NumDocksAvailable,
                }); ;
                return Ok(stations);
            }
            catch (Exception ex)
            {
                return BadRequest("Your request for station data failed, please contact the customerservice via email: post@oslobysykkel.no");
            }

        }
    }
}
