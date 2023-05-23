using OsloBySykkelApi.Extensions;
using OsloBySykkelApi.Models;

namespace OsloBySykkelApi.Services
{
    public interface IBySykkelService
    {
        public Task<SystemInformation> GetSystemInformation();
        public Task<StationInformationRoot> GetStationInformationAsync();
        public Task<StationStatusRoot> GetStationStatus();
    }

    public class BySykkelService : IBySykkelService
    {
        private readonly HttpClient _httpClient;

        public BySykkelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Client-Identifier", "developerfirma-oslobysykkeldata");
            _httpClient.BaseAddress = new Uri("https://gbfs.urbansharing.com/oslobysykkel.no/");
        }

        public async Task<SystemInformation> GetSystemInformation()
        {
            var systemInformation= await _httpClient.GetAsync<SystemInformation>("system_information.json");
            return systemInformation;
        }
        public async Task<StationInformationRoot> GetStationInformationAsync()
        {
            var stationInformation = await _httpClient.GetAsync<StationInformationRoot>("station_information.json");
            return stationInformation;
        }

        public async Task<StationStatusRoot> GetStationStatus()
        {
            var stationStatus = await _httpClient.GetAsync<StationStatusRoot>("station_status.json");
            return stationStatus;
        }
    }
}
