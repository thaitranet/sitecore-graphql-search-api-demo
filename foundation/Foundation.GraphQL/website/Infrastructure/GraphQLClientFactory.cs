using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Foundation.GraphQL.Infrastructure
{
    public class GraphQLClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public GraphQLClientFactory(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public IGraphQLClient CreateGraphQLClient(bool isEditingMode)
        {
            string configurationKeyUrlLiveOrEditMode = isEditingMode ? "Foundation:GraphQL:UrlEdit" : "Foundation:GraphQL:UrlLive";

            GraphQLHttpClientOptions graphQLHttpClientOptions = new GraphQLHttpClientOptions()
            {
                EndPoint = new Uri(
                    $"{_configuration[configurationKeyUrlLiveOrEditMode]}?sc_apikey={_configuration["Sitecore:ApiKey"]}"),
            };

            return new GraphQLHttpClient(graphQLHttpClientOptions, new NewtonsoftJsonSerializer(), _httpClient);
        }


    }
}
