using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace DAL.CosmosDb.Initializer
{
    public class CosmosContext
    {
        private static readonly DocumentClient Client = CosmosClient.CosmosClient.Instance;

        public static async Task RegisterCosmosContextAsync()
        {
            await CreateDatabaseIfNotExistsAsync();
            await CreateCollectionIfNotExistsAsync();
        }

        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await Client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(ConfigurationManager.AppSettings["databaseId"]));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Client.CreateDatabaseAsync(new Database { Id = ConfigurationManager.AppSettings["databaseId"] });
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await Client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["databaseId"]
                    , ConfigurationManager.AppSettings["collectionId"]));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await Client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(ConfigurationManager.AppSettings["databaseId"]),
                        new DocumentCollection { Id = ConfigurationManager.AppSettings["collectionId"] },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}