using FechaduraEletronica.Borders.Executors.Client;
using FechaduraEletronica.Borders.Executors.Device;
using FechaduraEletronica.Executors;
using Microsoft.Extensions.DependencyInjection;

namespace FechaduraEletronica.Api.Configuration
{
    public static class ExecutorConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGetClientExecutor, GetClientExecutor>();
            services.AddScoped<IGetDeviceExecutor, GetDeviceExecutor>();
            services.AddScoped<ICreateClientExecutor, CreateClientExecutor>();
            services.AddScoped<ICreateDeviceExecutor, CreateDeviceExecutor>();
        }
    }
}
