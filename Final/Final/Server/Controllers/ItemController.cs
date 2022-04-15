using Final.EF.Repos;
using Final.Model;
using Final.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IEntityRepo<Item> _itemRepo;

        public ItemController(IEntityRepo<Item> entityRepo)
        {
            _itemRepo = entityRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemViewModel>> Get()
        {
            var result = await _itemRepo.GetAllAsync();
            return result.Select(x => new ItemViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Description = x.Description,
                ItemType = x.ItemType,
                Price = x.Price,
                Cost = x.Cost,
            });
        }

        [HttpGet("{id}")]
        public async Task<ItemViewModel?> Get(int id)
        {
            ItemViewModel model = new();
            if (id != 0)
            {
                var existing = await _itemRepo.GetByIdAsync(id);
                if (existing is null)
                    return null;
                model.Id = existing.Id;
                model.Code = existing.Code;
                model.Description = existing.Description;
                model.ItemType = existing.ItemType;
                model.Price = existing.Price;
                model.Cost = existing.Cost;
            }
            return model;
        }

        [HttpPost]
        public async Task Post(ItemViewModel itemViewModel)
        {
            var newItem = new Item()
            {
                Description = itemViewModel.Description,
                ItemType = itemViewModel.ItemType,
                Price = itemViewModel.Price,
                Cost = itemViewModel.Cost
            };
            if(itemViewModel.Code == string.Empty)
            {
                bool codeExist = true;
                string code = string.Empty;
                var items = await _itemRepo.GetAllAsync();
                while (codeExist)
                {
                    code = $"{Guid.NewGuid().ToString("N").Substring(0, 10)}";
                    if (!items.Where(item => item.Code == code).Any())
                    {
                        codeExist = false;
                    }
                }
                newItem.Code = code;
            }
            else
            {
                newItem.Code = itemViewModel.Code;
            }
            await _itemRepo.AddAsync(newItem);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ItemViewModel itemViewModel)
        {
            
            var itemToUpdate = await _itemRepo.GetByIdAsync(itemViewModel.Id);
            if (itemToUpdate is null) return NotFound();

            var oldType = itemToUpdate.ItemType;
            itemToUpdate.Description = itemViewModel.Description;
            itemToUpdate.ItemType = itemViewModel.ItemType;
            itemToUpdate.Price = itemViewModel.Price;
            itemToUpdate.Cost = itemViewModel.Cost;
            itemToUpdate.Code = itemViewModel.Code;

            if(oldType != itemToUpdate.ItemType)
            {
                bool codeExist = true;
                string code = string.Empty;
                var items = await _itemRepo.GetAllAsync();
                while (codeExist)
                {
                    code = $"{Guid.NewGuid().ToString("N").Substring(0, 10)}";
                    if (!items.Where(item => item.Code == code).Any())
                    {
                        codeExist = false;
                    }
                }
                itemToUpdate.Code = code;
            }

            await _itemRepo.UpdateAsync(itemViewModel.Id, itemToUpdate);
            return Ok();
        }

        [HttpDelete("{ID}")]
        public async Task Delete(int id)
        {
            var selectedItem = await _itemRepo.GetByIdAsync(id);
            if (selectedItem is null)
            {
                return;
            }
            await _itemRepo.DeleteAsync(id);
        }
    }
}