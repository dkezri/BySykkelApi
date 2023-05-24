using Newtonsoft.Json;
using OsloBySykkelApi.Models;
using OsloBySykkelApi.Services;

namespace OsloBySykkelApiTests.Core
{
    public class BySykkelServiceMock : IBySykkelService
    {

        public async Task<StationInformationRoot> GetStationInformationAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonData", "StationInformation.json");
            var jsonData = File.ReadAllText(filePath);
            var stationInformation= JsonConvert.DeserializeObject<StationInformationRoot>(jsonData);
            return stationInformation;
        }

        public async Task<StationStatusRoot> GetStationStatusAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonData", "StationStatus.json");
            var jsonData = File.ReadAllText(filePath);
            var stationStatus = JsonConvert.DeserializeObject<StationStatusRoot>(jsonData);
            return stationStatus;
        }

        public Task<SystemInformation> GetSystemInformationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
