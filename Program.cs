using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TraderSys.Portfolios.Models.Context;
using TraderSys.Portfolios.Services;
using TraderSys.Portfolios.Data;
using TraderSys.Portfolios.Repositories;
using TraderSys.Portfolios.Controllers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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
        // builder.Services.AddGrpcHttpApi();
        builder.Services.AddRepository();
        builder.Services.AddServices();
        // builder.Services.AddAutoMapper(typeof(Mapper));
        // Database
        builder.Services.AddDbContextFactory<DataContext>(
                    options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=productsDb;User Id=admin;Password=admin1234"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<GreeterService>();
        app.UseEndpoints(endpoints => {
            endpoints.MapGrpcService<ProductController>();
        });

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}