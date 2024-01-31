using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebCaster.API.Authentication;
using WebCaster.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to dependancy container

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WebCaster API",
        Description = "WebCaster is a web radio management tool based on Liquidsoap and Icecast, written in C#. It exposes a public API, described below.",

        Contact = new OpenApiContact
        {
            Name = "Github",
            Url = new Uri("https://github.com/gmasquelier59/WebCaster")
        },
        License = new OpenApiLicense
        {
            Name = "GNU General Public License v3.0",
            Url = new Uri("https://github.com/gmasquelier59/WebCaster/blob/main/LICENSE")
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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WebCasterAPIConnection"))
);

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "WebCaster API";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapGroup("/api/auth").MapIdentityApi<ApplicationUser>().WithTags("Authentication");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
