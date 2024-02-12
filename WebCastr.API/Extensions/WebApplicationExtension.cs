using Microsoft.AspNetCore.Identity;
using WebCastr.API.Services.Liquidsoap;

namespace WebCastr.API.Extensions
{
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

        public static void AddAuthorization(this WebApplication webApp)
        {
            webApp.MapGroup("/api/auth").MapIdentityApi<IdentityUser>().WithTags("Authentication");
            webApp.UseAuthentication();
            webApp.UseAuthorization();
        }

        public static void StartServices(this WebApplication webApp)
        {
            webApp.Services.GetService<LiquidsoapService>()!.Start();
        }
    }
}
