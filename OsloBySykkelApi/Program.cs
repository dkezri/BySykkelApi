using Microsoft.AspNetCore.Builder;
using OsloBySykkelApi;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
using var app = builder.Build();

startup.Configure(app, app.Environment);
app.Run();


public partial class Program
{
    // This is needed in order to run unit and integration tests
}