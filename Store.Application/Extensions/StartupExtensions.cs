using NSwag;
using NSwag.Generation.Processors.Security;
using MongoDB.Driver;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Linq;
using Store.Data.DataAccess;
using Store.Data.Infrastructures;
using Store.Data.Entities;
using Store.Data.Repositories;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.Services.MappingProfiles;

namespace Store.Application.Extensions
{
    public static class StartupExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            #region Common
            services.AddHttpClient<IHttpService, HttpService>();
            #endregion

            #region Standard
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IHangFireService, HangFireService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();
            #endregion

            #region Import
            #endregion

            #region Export
            #endregion

            #region For implement base controller
            #endregion
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Common
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Standard
            #endregion

            #region For implement base service
            #endregion
        }

        public static void AddMappingProfile(this IServiceCollection services)
        {
            var profiles = new MapperConfiguration(
                _ =>
                {
                    _.AddProfile(new FilterMappingProfile());
                    _.AddProfile(new AuthenticationMappingProfile());
                }
            );

            services.AddSingleton(profiles.CreateMapper());
        }

        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        public static void ConfigSwagger(this IServiceCollection services, IWebHostEnvironment env)
        {
            var environmentOfSystem = env.IsDevelopment() ? "Development" : "Production";
            var apiVersionDescriptionProvider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                services.AddSwaggerDocument(document =>
                {
                    document.Title = "Store API";
                    document.Description = $"{environmentOfSystem} | Build at {DateTime.Now.ToLocalTime().ToString("HH:mm dd/MM/yyyy")}";
                    document.Version = "6.0";

                    document.DocumentName = description.GroupName;
                    document.PostProcess = _ => _.Info.Version = description.GroupName;
                    document.ApiGroupNames = new[] { description.GroupName };

                    document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Type into the textbox: Bearer {your JWT token}."
                    });

                    document.OperationProcessors.Add(
                        new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                    document.AllowReferencesWithProperties = true;
                });
        }

        public static void ConfigJwt(this IServiceCollection services, string key, string issuer, string audience)
        {
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtconfig =>
                {
                    jwtconfig.SaveToken = true;
                    jwtconfig.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = issuer,
                        ValidAudience = string.IsNullOrEmpty(audience) ? issuer : audience,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
                        ClockSkew = System.TimeSpan.Zero,
                    };
                });
        }
    }
}
