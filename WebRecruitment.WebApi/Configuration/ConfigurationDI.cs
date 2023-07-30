using System.Diagnostics;
using WebRecruitment.Application.Common;
using WebRecruitment.Infrastructure;
using WebRecruitment.WebApi.Middlewares;


namespace WebRecruitment.WebApi.Configuration
{
    public static class ConfigurationDI
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services, IConfiguration configuration)
        {
            // appConfiguration
            var appConfiguration = configuration.GetSection("ConnectString").Get<AppConfiguration>();
            var jwt = configuration.GetSection("JWT").Get<JWToken>();
            var email = configuration.GetSection("MailConfigurations").Get<Email>();
            //// Bearer
            //// Database + AzureBlog
            services.AddApplication(jwt.JWTSecretKey, jwt.Issuer, jwt.Audience);
            services.AddInfrastructuresService(appConfiguration.DatabaseConnection, appConfiguration.AzureBlobStorage, appConfiguration.ContainerName);
            services.ConfigureSwagger();
            services.AddSingleton(appConfiguration);
            services.AddSingleton(jwt);
            services.AddSingleton(email);


            // ALLOW HTTP
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyOrigin() // You can also specify specific origins here instead of allowing any origin.
                           .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();

            services.AddSingleton<GlobalExceptionMiddleware>();
            //services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();
            // services.AddScoped<IClaimsService, ClaimsService>();
            services.AddHttpContextAccessor();
          


            services.AddEndpointsApiExplorer();
            return services;
        }

    }
}
