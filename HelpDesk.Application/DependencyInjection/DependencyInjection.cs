using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        //La puerta por la cual Program.cs conoce las configuraciones especificas que debe tener mi API.
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        //Se indica como emparejar las interfaces con las clases reales
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
