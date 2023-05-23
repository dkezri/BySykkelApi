using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using OsloBySykkelApi.Services;

namespace OsloBySykkelApiTests.Core
{

    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            //LaunchSettingsFixture.SetEnvironmentVariables();

            builder.ConfigureServices(services =>
            {
                services.AddScoped<IBySykkelService, BySykkelServiceMock>();
            });

            return base.CreateHost(builder);
        }
    }
}
