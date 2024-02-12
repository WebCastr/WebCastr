using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using WebCastr.API.DTO;
using WebCastr.API.Models;
using WebCastr.API.Repositories;
using WebCastr.API.Services;
using WebCastr.API.Services.Liquidsoap.Options;
using WebCastr.API.Services.Liquidsoap;
using WebCastr.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Swashbuckle.AspNetCore.Filters;

namespace WebCastr.API.Extensions
{
    public static class WebApplicationBuidlerExtension
    {
        public static void AddLogger(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog();
        }

        public static void AddControllers(this WebApplicationBuilder builder)
        {
            Log.Information("Adding controllers...");
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                );
        }

        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            Log.Information("Adding repositories...");
            builder.Services.AddScoped<IRepository<Station>, StationsRepository>();
            builder.Services.AddScoped<StationService>();
        }

        public static void AddMapper(this WebApplicationBuilder builder)
        {
            Log.Information("Adding automapper...");
            builder.Services.AddAutoMapper(typeof(ApplicationMapperProfile));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            Log.Information("Adding services...");
            builder.Services.AddSingleton<LiquidsoapOptions>();
            builder.Services.Configure<LiquidsoapOptions>(
                builder.Configuration.GetSection("Services:Liquidsoap"));
            builder.Services.AddSingleton<LiquidsoapService>();
        }

        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            Log.Information("Adding database...");
            string[] supportedDatabaseProviders = new string[] { "sqlite", "sqlserver" };

            string? databaseProvider = builder.Configuration.GetRequiredSection("Database:Provider").Value;
            if (string.IsNullOrEmpty(databaseProvider) || !supportedDatabaseProviders.Contains(databaseProvider))
            {
                throw new NotSupportedException($"Unsupported database provider: {databaseProvider}");
            }
            Log.Information($"Database provider: {databaseProvider}");

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = builder.Configuration.GetRequiredSection("Database:ConnectionString").Value ?? throw new InvalidOperationException("Connection string not found");
                switch (databaseProvider)
                {
                    case "sqlserver":
                        options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString));
                        break;
                    case "sqlite":
                        options.UseSqlite(builder.Configuration.GetConnectionString(connectionString));
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported database provider: {databaseProvider}");
                }
            });
        }

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            Log.Information("Adding Swagger...");

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebCastr API",
                    Description = "WebCastr is an open-source web radio management tool based on Liquidsoap and Icecast, written in C#. It exposes a public API, described below.",

                    Contact = new OpenApiContact
                    {
                        Name = "Github",
                        Url = new Uri("https://github.com/WebCastr/WebCastr")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "GNU General Public License v3.0",
                        Url = new Uri("https://www.gnu.org/licenses/gpl-3.0.html")
                    }
                });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            Log.Information("Adding authentication...");

            builder.Services.AddAuthorization();

            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
