using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraderSys.Portfolios.Models.Context;
using TraderSys.Portfolios.Services;

var builder = WebApplication.CreateBuilder(args);
// Configurations
var Configuration = builder.Configuration;
Configuration.AddEnvironmentVariables();

builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    options.ListenLocalhost(7091, o => o.Protocols =
        HttpProtocols.Http2);
});

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();
// Database
//builder.Services.AddDbContextFactory<ApplicationDbContext>(
//    options => options.UseNpgsql("Server=localhost; Port=5432; Database=project; Username=postgres; Password=postgres"));

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
