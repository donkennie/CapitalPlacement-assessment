using Capital_placement_assessment.Repositories.Abstraction;
using Microsoft.Azure.Cosmos;
using src.Models;

namespace Capital_placement_assessment.Repositories.Implementation
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        public ProfileRepository(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer(databaseId, containerId);
        }
        public async Task Create(Profile entity)
        {
            await _container.CreateItemAsync(entity, new PartitionKey(entity.Id));
        }

        public async Task<int> Delete(Profile entity)
        {
            await _container.DeleteItemAsync<Profile>(entity.Id, new PartitionKey(entity.PartitionKey));
            return (0);
        }

        public async Task<Profile> Get(string id)
        {
            return await _container.ReadItemAsync<Profile>(id, new PartitionKey(id));
        }

        public async Task<IEnumerable<Profile>> GetAll(string queryString)
        {
            var query = _container.GetItemQueryIterator<Profile>(new QueryDefinition(queryString));
            var results = new List<Profile>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateEntity(Profile entity)
        {
            await _container.ReplaceItemAsync(entity, entity.Id, new PartitionKey(entity.PartitionKey));
        }
    }
}