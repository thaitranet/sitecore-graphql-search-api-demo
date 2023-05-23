using Feature.ContentSearch.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Feature.ContentSearch.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFeatureContentSearch(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IGraphQLProductsService, GraphQLProductsService>();
        }

    }
}
