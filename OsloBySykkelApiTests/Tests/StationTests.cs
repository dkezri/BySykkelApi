using FluentAssertions;
using OsloBySykkelApi.Extensions;
using OsloBySykkelApi.Models;
using OsloBySykkelApiTests.Core;
using Xunit;

namespace OsloBySykkelApiTests.Tests
{
    public class StationTests : TestBase
    {
        public StationTests(CustomWebApplicationFactory webApplicationFactory)
            : base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task GetAllStationTests()
        {
            var url = "/stations";
            var getAllResponse = await _httpClient.GetAsync<List<StationModel>>(url);
            getAllResponse.Should().NotBeNull();
            getAllResponse.Count.Should().BeGreaterThan(2);
        }

        [Fact]
        public async Task GetNearstStationsTests()
        {
            var url = "/stations?latitude=59.9131891&longitude=10.7897605";
            var getAllResponse = await _httpClient.GetAsync<List<StationModel>>(url);
            getAllResponse.Should().NotBeNull();
            getAllResponse.Count.Should().BeGreaterThan(0);
        }
    }
}
