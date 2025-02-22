using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Applicacion.Tecnofactory.WebApi.Handlers
{
    public static class JwtConfigurationHandler
    {
        public static void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
        {

            var secretKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                        ValidateAudience = true, 
                        ValidateLifetime = true, 
                        ValidateIssuerSigningKey = true, 
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
