using GraphQL;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Foundation.GraphQL.Infrastructure
{
    public interface IGraphQLProvider
    {
        Task<GraphQLResponse<TResponse>> SendQueryAsync<TResponse>(object variables, GraphQLFiles queryFile, bool isEditingMode) where TResponse : class;
    }

    public class GraphQLProvider : IGraphQLProvider
    {
        private readonly GraphQLRequestBuilder graphQLRequestBuilder;
        private readonly GraphQLClientFactory graphQLClientFactory;

        public GraphQLProvider(ILogger<IGraphQLProvider> logger, GraphQLRequestBuilder graphQLRequestBuilder, GraphQLClientFactory graphQLClientFactory)
        {
            this.graphQLRequestBuilder = graphQLRequestBuilder ?? throw new ArgumentNullException(nameof(graphQLRequestBuilder));
            this.graphQLClientFactory = graphQLClientFactory ?? throw new ArgumentNullException(nameof(graphQLClientFactory));
        }

        public async Task<GraphQLResponse<TResponse>> SendQueryAsync<TResponse>(object variables, GraphQLFiles queryFile, bool isEditingMode) where TResponse : class
        {
            var request = graphQLRequestBuilder.BuildQuery(queryFile, variables);
            var client = graphQLClientFactory.CreateGraphQLClient(isEditingMode);
            return await client.SendQueryAsync<TResponse>(request);
        }

    }
}
