using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using WebCastr.Core.Requests;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebCastr.API.Extensions;

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
    }

    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        Log.Information("Adding database...");
        string[] supportedDatabaseProviders = new string[] { "sqlserver" };

        string? databaseProvider = builder.Configuration.GetRequiredSection("Database:Provider").Value;
        if (string.IsNullOrEmpty(databaseProvider) || !supportedDatabaseProviders.Contains(databaseProvider))
        {
            throw new NotSupportedException($"Unsupported database provider: {databaseProvider}");
        }
        Log.Information($"Database provider: {databaseProvider}");

        //builder.Services.AddDbContext<AppDbContext>(options =>
        //{
        //    string connectionString = builder.Configuration.GetRequiredSection("Database:ConnectionString").Value ?? throw new InvalidOperationException("Connection string not found");
        //    switch (databaseProvider)
        //    {
        //        case "sqlserver":
        //            options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString));
        //            break;
        //        default:
        //            throw new NotSupportedException($"Unsupported database provider: {databaseProvider}");
        //    }
        //});
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
                Description = "WebCastr is an open-source webradio management tool based on Liquidsoap and Icecast, written in C#. It exposes a public API, described below.\n\n[NIY] in route description means \"Not Implemented Yet\" - not functional, please don't use :-)",

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

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }
}
