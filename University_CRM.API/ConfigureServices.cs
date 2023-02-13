using Microsoft.AspNetCore.Mvc;

namespace University_CRM.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            //services.Configure<ApiBehaviorOptions>(option =>
            //{
            //    option.SuppressModelStateInvalidFilter = true;
            //});

            return services; 
        }
    }
}
