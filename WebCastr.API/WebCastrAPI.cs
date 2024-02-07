using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebCastr.API.Authentication;
using WebCastr.API.Data;
using WebCastr.API.Models;
using WebCastr.API.Services.Liquidsoap.Options;
using WebCastr.API.Services.Liquidsoap;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebCastr.API.Repositories;
using WebCastr.API.Services;
using System.Text.Json.Serialization;

namespace WebCastr.API;

public class WebCastrAPI
{
    public const string GithubUrl = "https://github.com/WebCastr/WebCastr";

    public readonly Version Version = new Version(0, 1, 0);

    public readonly string Name = "WebCastr";

    public readonly string FullName = "WebCastr API Server v0.1.0";

    public void Run(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        InitServices(builder);
        PreBuildInitSwagger(builder);
        InitDatabase(builder);

        var app = builder.Build();

        PostBuildInitSwagger(app);

        app.MapGroup("/api/auth").MapIdentityApi<ApplicationUser>().WithTags("Authentication");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Services.GetService<LiquidsoapService>()!.Start();

        app.Run();
    }

    private void InitServices(WebApplicationBuilder builder)
    {
        // Logger
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
        builder.Host.UseSerilog();
        Log.Information(FullName);
        Log.Information($"Please visit the source project for latest version and issues at {GithubUrl}");
        Log.Information($"Thank you for using WebCastr :-)");

        // Controllers
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
            );

        // Repositories
        builder.Services.AddScoped<IRepository<Station>, StationsRepository>();
        builder.Services.AddScoped<StationService>();

        builder.Services.AddAutoMapper(typeof(WebCastrProfile));

        // Liquidsoap
        builder.Services.AddSingleton<LiquidsoapOptions>();
        builder.Services.Configure<LiquidsoapOptions>(
            builder.Configuration.GetSection("Services:Liquidsoap"));
        builder.Services.AddSingleton<LiquidsoapService>();
    }

    private void PreBuildInitSwagger(WebApplicationBuilder builder)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WebCastr API",
                Description = "WebCastr is a web radio management tool based on Liquidsoap and Icecast, written in C#. It exposes a public API, described below.",

                Contact = new OpenApiContact
                {
                    Name = "Github",
                    Url = new Uri($"{GithubUrl}")
                },
                License = new OpenApiLicense
                {
                    Name = "GNU General Public License v3.0",
                    Url = new Uri($"{GithubUrl}/blob/main/LICENSE")
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

    private void PostBuildInitSwagger(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = "WebCastr API";
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }

    private void InitDatabase(WebApplicationBuilder builder)
    {
        // Supported database providers
        string[] supportedDatabaseProviders = new string[] { "sqlite" };

        string? databaseProvider = builder.Configuration.GetRequiredSection("Database:Provider").Value;
        if (string.IsNullOrEmpty(databaseProvider) || !supportedDatabaseProviders.Contains(databaseProvider))
        {
            throw new NotSupportedException($"Unsupported database provider: {databaseProvider}");
        }
        Log.Information($"Database provider: {databaseProvider}");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            string? connectionString = builder.Configuration.GetRequiredSection("Database:ConnectionString").Value ?? "";
            switch (databaseProvider)
            {
                case "sqlite":
                    options.UseSqlite(builder.Configuration.GetConnectionString(connectionString));
                    break;
                default:
                    throw new NotSupportedException($"Unsupported database provider: {databaseProvider}");
            }
        });

        builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
}
