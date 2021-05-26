using FechaduraEletronica.Shared.Configurations;
using Microsoft.Extensions.Configuration;

namespace FechaduraEletronica.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void LoadConfiguration(this IConfiguration source)
        {
            source.Get<ApplicationConfig>();
        }
    }
}
