using DAO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebUI.StartupConfigure
{
    public static class DependencyInjectionConfigure
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
            IWebHostEnvironment env, IConfiguration config)
        {
            if (env.IsDevelopment())
            {
                services.AddTransient<IContatoDAO, DAO.SQLite.ContatoDAO>();
                services.AddTransient<ITelefoneDAO, DAO.SQLite.TelefoneDAO>();
            }
            else
            {
                var connectionString = config.GetConnectionString("SQLServer");
                services.AddTransient<IContatoDAO>(o => new DAO.SQLServer.ContatoDAO(connectionString));
                services.AddTransient<ITelefoneDAO>(o => new DAO.SQLServer.TelefoneDAO(connectionString));
            }

            return services;
        }
    }
}