using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace University_CRM.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
