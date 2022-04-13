using Final.EF.Context;
using Final.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.EF.Repos
{
    public class ItemRepo : IEntityRepo<Item>
    {
        private readonly FinalContext _context;

        public ItemRepo(FinalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item entity)
        {
            await AddLogic(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteLogic(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task UpdateAsync(int id, Item entity)
        {
            await UpdateLogic(id, entity);
            await _context.SaveChangesAsync();
        }

        private async Task AddLogic(Item entity)
        {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            await _context.Items.AddAsync(entity);

        }
        private async Task DeleteLogic(int id)
        {
            var currentItem = await _context.Items.SingleOrDefaultAsync(item => item.Id == id);
            if (currentItem is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            _context.Items.Remove(currentItem);
        }

        private async Task UpdateLogic(int id, Item entity)
        {
            var currentItem = await _context.Items.SingleOrDefaultAsync(item => item.Id == id);
            if (currentItem is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            currentItem.Code = entity.Code;
            currentItem.Description = entity.Description;
            currentItem.ItemType = entity.ItemType;
            currentItem.Price = entity.Price;
            currentItem.Cost = entity.Cost;
        }
    }
}
