using Microsoft.Extensions.DependencyInjection;
using TradesDataManager.Services.Database;

namespace TradesDataManager.Services.CosmosDb
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCosmosDbServices(this IServiceCollection services)
        {
            //This database is a singleton, despite "scoped" being sufficient for an API request, I would argue that reconnecting to the database and clean-up of the service is
            //more expensive than simply maintaining an instance as a singleton for the runtime of the API.   
            services.AddSingleton<IStocksDatabase, StocksDatabase>();
            return services;
        }
    }
}
