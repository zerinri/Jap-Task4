using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Jap_Task4.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jap_Task4.Api", Version = "v1" });
                }
            );
        }
    }
}