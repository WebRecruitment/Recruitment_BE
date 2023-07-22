using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace WebRecruitment.WebApi.Configuration
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,string JWTSecretKey, string Issuer, string Audience)
        {
            // AUTHENTICATION
            var secretKeyBytes = Encoding.UTF8.GetBytes(JWTSecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(jwtBearerOptions =>
           {
               jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Issuer,
                   ValidAudience = Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                   ClockSkew = TimeSpan.Zero
               };
           });
            services.AddMemoryCache();


            return services;
        }
    }
}
