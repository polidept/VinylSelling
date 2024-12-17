using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VinylSeliing.EndPoints;

namespace VinylSeliing.Extensions;

public static class ApiExtension
{
    public static void AppMappedEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapUsersEndpoints();
        app.MapAuthorEndpoints();
        app.MapVinylEndpoints();
        app.MapOrderEndpoints();
    }

    public static void AppApiAuthentification(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                };


                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["hz-cookies"];

                        return Task.CompletedTask;
                    }
                };
                
            });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
            options.AddPolicy("UserOnly", policy => policy.RequireRole("user"));
        });


    }
}