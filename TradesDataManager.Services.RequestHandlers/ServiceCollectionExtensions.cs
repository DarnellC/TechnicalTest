using Microsoft.Extensions.DependencyInjection;

namespace TradesDataManager.Services.RequestHandlers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler, RequestHandler>();
            return services;
        }
    }
}
