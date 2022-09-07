using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraderSys.Portfolios.Models.Context;
using TraderSys.Portfolios.Services;
using TraderSys.Portfolios.Repositories;
using TraderSys.Portfolios.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
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

        // Database
        builder.Services.AddDbContextFactory<Context>(
            options => options.UseNpgsql(Configuration.GetValue<string>("Postgres:ConnectionString")));
        builder.Services.AddGrpc();
        // builder.Services.AddGrpcHttpApi();
        builder.Services.AddRepository();
        builder.Services.AddServices();
        // builder.Services.AddAutoMapper(typeof(Mapper));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<GreeterService>();
        // app.UseEndpoints(endpoints => {
        //     endpoints.MapGrpcService<ProductController>();
        // });

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}