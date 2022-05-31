using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Hangfire.MemoryStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Store.Application.Extensions;
using Store.Data.DataAccess;
using Store.Services.Core;
using Store.Services;

namespace Store.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                             .SetBasePath(env.ContentRootPath)
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                             .AddEnvironmentVariables();

            Environment = env;
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region --- Old ---
            services.Configure<IISServerOptions>(_ => _.MaxRequestBodySize = int.MaxValue);
            services.Configure<KestrelServerOptions>(_ => _.Limits.MaxRequestBodySize = int.MaxValue);
            services.AddControllers()
                    .AddNewtonsoftJson(_ => {
                        _.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        _.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });
            #endregion

            #region Hangfire
            if (Environment.IsDevelopment())
            {
                services.AddHangfire(configuration =>
                    configuration
                        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                        .UseSimpleAssemblyNameTypeSerializer()
                        .UseDefaultTypeSerializer()
                        .UseMemoryStorage()
                    );
            }
            else
            {
                services.AddHangfire(configuration => configuration
                        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                        .UseSimpleAssemblyNameTypeSerializer()
                        .UseRecommendedSerializerSettings()
                        .UseSqlServerStorage(
                            Configuration.GetConnectionString("Hangfire"),
                            new SqlServerStorageOptions
                            {
                                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                QueuePollInterval = TimeSpan.Zero,
                                UseRecommendedIsolationLevel = true,
                                DisableGlobalLocks = true
                            }
                        ));
            }
            services.AddHangfireServer();
            #endregion

            #region App Settings
            services.AddOptions();
            #endregion

            #region Versioning
            services.AddApiVersioning(_ =>
            {
                _.DefaultApiVersion = new ApiVersion(1, 0);
                _.AssumeDefaultVersionWhenUnspecified = true;
                _.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(_ =>
            {
                _.GroupNameFormat = "'v'VVV";
                _.SubstituteApiVersionInUrl = true;
            });
            #endregion

            services.ConfigCors();
            services.ConfigJwt(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], Configuration["Jwt:Issuer"]);
            services.ConfigSwagger(Environment);
            services.AddRepositories();
            services.AddBusinessServices();
            services.AddMappingProfile();
            services.AddHttpContextAccessor();
            services.AddDbContext<SqlDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("SqlDb"))
            );
            ServiceDI.AddDependencies(services);
        }

        public void Configure(
            IApplicationBuilder application,
            IWebHostEnvironment environment,
            IHangFireService hangFireService
        )
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new List<IDashboardAuthorizationFilter>()
            });

            application.UseCors("AllowAll");

            application.UseMiddleware<ErrorHandlerExtensions>();

            application.UseHttpsRedirection();
            application.UseRouting();

            application.UseAuthentication();
            application.UseAuthorization();

            application.UseStaticFiles(
                new StaticFileOptions
                {
                    OnPrepareResponse = _ =>
                    {
                        if (_.Context.Request.Path.StartsWithSegments("/files"))
                        {
                            _.Context.Response.Headers.Add("Cache-Control", "no-store");
                            if (!_.Context.User.Identity.IsAuthenticated)
                            {
                                _.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                _.Context.Response.ContentLength = 0;
                                _.Context.Response.Body = Stream.Null;
                                _.Context.Response.Redirect("/");
                            }
                        }
                    }
                }
            );

            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            application.UseOpenApi();

            application.UseSwaggerUi3(options =>
            {
                options.CustomStylesheetPath = "/styles/swagger.css";
            });

            hangFireService.StartBackgroundService();
        }
    }
}
