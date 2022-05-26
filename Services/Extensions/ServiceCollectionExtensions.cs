using HW_CreateCustomerApi_Services.Abstractions;
using HW_CreateCustomerApi_Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace HW_CreateCustomerApi_Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}