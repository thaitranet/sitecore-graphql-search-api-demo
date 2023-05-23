using Feature.ContentSearch.Models;
using Foundation.GraphQL.Infrastructure;
using System.Threading.Tasks;

namespace Feature.ContentSearch.Services
{
    public interface IGraphQLProductsService
    {
        Task<SearchResponse> Search(SearchRequest request, bool isEditingMode);
    }

    public class GraphQLProductsService : IGraphQLProductsService
    {
        private readonly IGraphQLProvider _graphQLProvider;


        public GraphQLProductsService(IGraphQLProvider graphQLProvider)
        {
            _graphQLProvider = graphQLProvider;
        }

        public async Task<SearchResponse> Search(SearchRequest request, bool isEditingMode)
        {
            var response = await _graphQLProvider.SendQueryAsync<SearchResponse>(request, GraphQLFiles.BasicSearch, isEditingMode);
            return response.Data;
        }
    }
}