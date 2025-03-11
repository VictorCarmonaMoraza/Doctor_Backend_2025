using Doctor_Data.DB_Context;
using Doctor_Data.Interfaces;
using Doctor_Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API_DOCTOR.Extension
{
    public static class ServiceAplication_Extension
    {
        public static IServiceCollection AddServiceAplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API_DOCTOR", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingresar Beare [espacion] token \r\n\r\n "+
                    "Ejemplo: Bearer 12345abcdef",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
            });
            var connectionString = config.GetConnectionString("ConnectionBBDD");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //CORS
            services.AddCors();

            //Agregar servicios
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
