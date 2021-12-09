using DAO;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.StartupConfigure
{
    public static class DependencyInjectionConfigure
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IContatoDAO, ContatoDAO>();
            services.AddTransient<ITelefoneDAO, TelefoneDAO>();

            return services;
        }
    }
}