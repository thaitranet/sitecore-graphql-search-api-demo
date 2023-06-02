using Feature.ContentSearch.Models;
using Foundation.GraphQL.Infrastructure;
using System.Threading.Tasks;

namespace Feature.ContentSearch.Services
{
    public interface IGraphQLService
    {
        Task<SearchResponse> Search(SearchRequest request, bool isEditingMode);
    }

    public class GraphQLService : IGraphQLService
    {
        private readonly IGraphQLProvider _graphQLProvider;


        public GraphQLService(IGraphQLProvider graphQLProvider)
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