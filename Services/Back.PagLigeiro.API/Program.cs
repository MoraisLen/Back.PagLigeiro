using Autofac.Extensions.DependencyInjection;
using Back.PagLigeiro.Util.Generics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;

namespace Back.PagLigeiro.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                IConfigurationRoot settings = config.Build();
                string TableLog = settings["Logging:LogTable"];
                string connection = EnvironmentHelper.getConnectionString(settings);

                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Logger(lc => lc
                    .Filter.ByExcluding(x => x.Level == LogEventLevel.Information && !x.MessageTemplate.Text.Contains("[INFOR]"))
                    //.WriteTo.File(new Serilog.Formatting.Json.JsonFormatter(), "Logs/log-informations.txt", rollingInterval: RollingInterval.Day)
                    .WriteTo.MSSqlServer(connection,
                        sinkOptions: new SinkOptions()
                        {
                            AutoCreateSqlTable = true,
                            TableName = TableLog
                        })
                    )
                .CreateLogger();
            })
            .UseSerilog()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}