using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UnitOfWork;
using AspNetCoreRateLimit;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
         public static void ConfigureCors(this IServiceCollection services) =>
       services.AddCors(options =>
       {
           options.AddPolicy("CorsPolicy", builder =>
           builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           );
       }

       );
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
            // services.AddScoped<IUserService, UserService>();
        }
            public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            //options.ApiVersionReader = new QueryStringApiVersionReader("ver");
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("ver"),
                new HeaderApiVersionReader("X-Version")
            );
            options.ReportApiVersions = true;

        });
    }
        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>

                (options =>
                {
                    options.EnableEndpointRateLimiting = true;
                    options.StackBlockedRequests = false;
                    options.HttpStatusCode = 429;
                    options.RealIpHeader = "X-Real-Ip";
                    options.GeneralRules = new List<RateLimitRule>
                    {
                        new RateLimitRule{Endpoint="*",Period="10s",Limit=2}
                    };
                }

            );

        }
    }
}