using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using University_CRM.Application.Common.Interface;
using University_CRM.Infrastructure.Persistence;
using University_CRM.Infrastructure.Services;

namespace University_CRM.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(option =>
            {
                option.UseSqlServer("Server=.;Database=University_CRM;Trusted_Connection=True");
                option.LogTo(Console.WriteLine);
            });
            services.AddScoped<ICollageRepository, CollageRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            return services;
        }
    }
}
