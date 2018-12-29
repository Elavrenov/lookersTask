using System;
using System.Configuration;
using Microsoft.Azure.Documents.Client;

namespace DAL.CosmosDb.CosmosClient
{
    public class CosmosClient
    {
        private static readonly Lazy<DocumentClient> LazyClient =
            new Lazy<DocumentClient>(() => new DocumentClient(new Uri(ConfigurationManager.AppSettings["endpoint"])
                , ConfigurationManager.AppSettings["authKey"]));
        public static DocumentClient Instance => LazyClient.Value;

        private CosmosClient()
        {

        }
    }
}