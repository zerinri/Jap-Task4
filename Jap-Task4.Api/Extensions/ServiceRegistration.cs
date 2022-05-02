using Jap_Task4.Services.Interfaces;
using Jap_Task4.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jap_Task4.Api.Extensions
{
    public static class ServiceRegistration
    {
        public static void SetupServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<ICouponService, CouponService>();
        }
    }
}