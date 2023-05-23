using Foundation.GraphQL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.GraphQL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFoundationGraphQL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GraphQLRequestBuilder>();
            serviceCollection.AddHttpClient<GraphQLClientFactory>();
            serviceCollection.AddSingleton<IGraphQLProvider, GraphQLProvider>();
        }

    }
}
