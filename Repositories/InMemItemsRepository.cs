using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id= Guid.NewGuid(), Name="Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id= Guid.NewGuid(), Name="Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id= Guid.NewGuid(), Name="Boots", Price = 12, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id= Guid.NewGuid(), Name="Armor", Price = 16, CreatedDate = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var updateIndex = items.FindIndex(existingItem => existingItem.Id == item.Id); 
            items[updateIndex] = item;
        }

        public void DeleteItem(Item item)
        {
            var itemIndex = items.FindIndex(existingItem => existingItem.Id == item.Id); 
            items.RemoveAt(itemIndex);
        }
    }
}