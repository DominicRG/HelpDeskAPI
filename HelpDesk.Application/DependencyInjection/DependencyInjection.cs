using HelpDesk.Application.Area.Mappings;
using HelpDesk.Application.Area.Services.Implementations;
using HelpDesk.Application.Area.Services.Interfaces;
using HelpDesk.Application.Rol.Services.Implementations;
using HelpDesk.Application.Rol.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        //La puerta por la cual Program.cs conoce las configuraciones especificas que debe tener mi API.
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            services.AddAutoMapper(typeof(AreaProfile));
            return services;
        }

        //Se indica como emparejar las interfaces con las clases reales
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IRolService, RolService>();

            return services;
        }
    }
}
