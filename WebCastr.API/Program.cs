using Serilog;
using WebCastr.API.Extensions;

Version appVersion = new Version(0, 1, 0);
string appName = "WebCastr API Server";
string appFullName = $"{appName} v{appVersion.ToString(3)}";

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
Log.Information(appFullName);
Log.Information($"Please visit the source project for latest version and issues.");
Log.Information($"Thank you for using WebCastr :-)");

builder.AddDatabase();
builder.AddControllers();
builder.AddRepositories();
builder.AddSwagger();

var app = builder.Build();

app.AddSwagger();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();