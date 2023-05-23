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
        public async Task GetAllValuesTests()
        {
            var url = "/stations";
            var getAllResponse = await _httpClient.GetAsync<List<StationModel>>(url);
            getAllResponse.Should().NotBeNull();
            getAllResponse.Count.Should().Be(2);
        }
    }
}
