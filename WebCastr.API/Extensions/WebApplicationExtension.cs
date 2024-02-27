using System.Reflection;

namespace WebCastr.API.Extensions;

public static class WebApplicationExtension
{
    public static void AddSwagger(this WebApplication webApp)
    {
        webApp.UseSwagger();
        webApp.UseSwaggerUI(options =>
        {
            options.DocumentTitle = "WebCastr API";
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}
