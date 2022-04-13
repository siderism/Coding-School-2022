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
    public class TransactionLineRepo : IEntityRepo<TransactionLine>
    {
        private readonly FinalContext _context;

        public TransactionLineRepo(FinalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TransactionLine entity)
        {
            await AddLogic(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteLogic(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransactionLine>> GetAllAsync()
        {
            return await _context.TransactionLines.Include(transactionLine => transactionLine.Transaction).Include(transactionLine => transactionLine.Item).ToListAsync();
        }

        public async Task<TransactionLine?> GetByIdAsync(int id)
        {
            return await _context.TransactionLines.Include(transactionLine => transactionLine.Transaction).Include(transactionLine => transactionLine.Item).SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
        }

        public async Task UpdateAsync(int id, TransactionLine entity)
        {
            await UpdateLogic(id, entity);
            await _context.SaveChangesAsync();
        }

        private async Task AddLogic(TransactionLine entity)
        {
            if (entity.Id == 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            await _context.TransactionLines.AddAsync(entity);

        }
        private async Task DeleteLogic(int id)
        {
            var currentTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.Id == id);
            if (currentTransactionLine is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            _context.TransactionLines.Remove(currentTransactionLine);
        }

        private async Task UpdateLogic(int id, TransactionLine entity)
        {
            var foundTransLine = await _context.TransactionLines.SingleOrDefaultAsync(transLine => transLine.Id == id);
            if (foundTransLine is null)
                return;

            foundTransLine.ItemId = entity.ItemId;
            foundTransLine.Quantity = entity.Quantity;
            foundTransLine.ItemPrice = entity.ItemPrice;
            foundTransLine.NetValue = entity.NetValue;
            foundTransLine.DiscountPercent = entity.DiscountPercent;
            foundTransLine.DiscountValue = entity.DiscountValue;
            foundTransLine.TotalValue = entity.TotalValue;
        }
    }
}
