using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories 
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private readonly IMongoCollection<Item> itemsCollection;
        private const string databaseName = "catalog"; 
        private const string collectionName = "items";
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.
        }
        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}