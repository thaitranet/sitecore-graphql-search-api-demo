using GraphQL;
using System;
using System.IO;
using System.Reflection;

namespace Foundation.GraphQL.Infrastructure
{
    public class GraphQLRequestBuilder
    {
        public GraphQLRequest BuildQuery(string query, string operationName, object variables)
        {
            return new GraphQLRequest
            {
                Query = query,
                OperationName = operationName,
                Variables = variables
            };
        }

        public GraphQLRequest BuildQuery(GraphQLFiles queryFile, object variables)
        {
            return BuildQuery(GetOperationResource(queryFile), queryFile.ToString(), variables);
        }


        protected string GetOperationResource(GraphQLFiles queryFile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{assembly.GetName().Name}.GraphQLQueries.{queryFile}.graphql";            
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }

    [Flags]
    public enum GraphQLFiles
    {
        None = 0,
        BasicSearch = 1
    }
}
