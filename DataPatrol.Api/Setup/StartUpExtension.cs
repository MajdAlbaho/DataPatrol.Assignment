using DataPatrol.Services.GeneratorServices;
using DataPatrol.Services.IGeneratorServices;

namespace DataPatrol.Api.Setup
{
    public static class StartUpExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration) {
            serviceCollection.AddTransient<INumberGenerator, NumberGenerator>();
            return serviceCollection;
        }
    }
}
