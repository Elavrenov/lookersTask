using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using DAL.CosmosDb.Entities;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Interfaces;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace DAL.CosmosDb
{
    public class CosmosRepository : IRepository
    {
        private readonly DocumentClient _client = CosmosClient.CosmosClient.Instance;
        public async Task<IEnumerable<Car>> GetAllItemsAsync()
        {
            IDocumentQuery<Item> query = _client.CreateDocumentQuery<Item>(
                    UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["databaseId"]
                    , ConfigurationManager.AppSettings["collectionId"]))
                    .AsDocumentQuery();

            List<Item> results = new List<Item>();

            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<Item>());
            }

            return Mapper.Mapper.ToEnumerableCarDto(results);
        }

        public async Task<Car> GetItemByIdAsync(string id)
        {
            IDocumentQuery<Item> query = _client.CreateDocumentQuery<Item>(
                    UriFactory.CreateDocumentCollectionUri(ConfigurationManager.AppSettings["databaseId"]
                        , ConfigurationManager.AppSettings["collectionId"]))
                .AsDocumentQuery();


            List<Item> results = new List<Item>();

            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<Item>());
            }

            return Mapper.Mapper.ToEnumerableCarDto(results.Where(x => x.Id == id)).FirstOrDefault();
        }
    }
}