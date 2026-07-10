using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using HelpDesk.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Infrastructure.Repositories.Interfaces;
using HelpDesk.Infrastructure.Repositories.Implementations;

namespace HelpDesk.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        //Configuracion para comunicación con la BD
        //public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //    {
        //        options.UseSqlServer(
        //            configuration.GetConnectionString("DefaultConnection"));
        //    });

        //    return services;
        //}

        //La puerta por la cual Program.cs conoce las configuraciones especificas que debe tener mi API.
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBase(configuration);

            services.AddRepositories();

            return services;
        }

        //Se encarga de la configuración a la BD
        private static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        //Se indica como emparejar las interfaces con las clases reales
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAreaRepository, AreaRepository>();

            return services;
        }
    }
}
