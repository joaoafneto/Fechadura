using FechaduraEletronica.Borders.Repositories;
using FechaduraEletronica.Borders.Repositories.Helpers;
using FechaduraEletronica.Repositories;
using FechaduraEletronica.Repositories.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace FechaduraEletronica.Api.Configuration
{
    public static class RepositoryConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepositoryHelper, RepositoryHelper>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientDeviceRepository, ClientDeviceRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
        }
    }
}
