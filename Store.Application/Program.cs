using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System;
using System.IO;

namespace Store.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureSerilogWithElasticSearch();
            CreateHostBuilder(args).Build().Run();
        }

        private static void ConfigureSerilogWithElasticSearch()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                                .Enrich.FromLogContext()
                                .Enrich.WithExceptionDetails()
                                .Enrich.WithMachineName()
                                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["Elastic:Uri"]))
                                {
                                    AutoRegisterTemplate = true,
                                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                                    IndexFormat = $"{configuration["AppName"]?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}",
                                    ModifyConnectionSettings = _ => _.BasicAuthentication(configuration["Elastic:Username"], configuration["Elastic:Password"])
                                })
                                .Enrich.WithProperty("Environment", environment)
                                .ReadFrom.Configuration(configuration)
                                .CreateLogger();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseWebRoot("wwwroot");
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
