using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public static class ValJWT
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var AuthSettings = configuration.GetSection("AuthSettings").Get<Auth>();
            //services.Configure<Auth>(configuration.GetSection("AuthSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthSettings.SecretKey))
                    };
                    o.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = contex =>
                        {
                            if (contex.Request.Cookies.ContainsKey("jwt"))
                            {
                                contex.Token = contex.Request.Cookies["jwt"];

                            }
                            return Task.CompletedTask;
                        }
                    };



                });
            return services;

            
           
                
        }
    }
}
