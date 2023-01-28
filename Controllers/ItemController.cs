using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    // GET /items

    [ApiController]
    [Route("items")]
    public class ItemsController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        // GET /items/id 
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = this.repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item item = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemDto> DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItem(existingItem);
            
            return NoContent();
        }
    }
}