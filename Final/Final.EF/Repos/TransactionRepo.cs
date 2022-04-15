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
    public class TransactionRepo : IEntityRepo<Transaction>
    {
        private readonly FinalContext _context;

        public TransactionRepo(FinalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction entity)
        {
            await AddLogic(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteLogic(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.Include(transaction => transaction.Employee).Include(transaction => transaction.Customer).Include(transaction => transaction.TransactionLines).ThenInclude(tl => tl.Item).ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions.Include(transaction => transaction.Employee).Include(transaction => transaction.Customer).Include(transaction => transaction.TransactionLines).ThenInclude(tl => tl.Item).SingleOrDefaultAsync(transaction => transaction.Id == id);
        }

        public async Task UpdateAsync(int id, Transaction entity)
        {
            await _context.SaveChangesAsync();
        }

        private async Task AddLogic(Transaction entity)
        {
            entity.Date = DateTime.Now;
            await _context.Transactions.AddAsync(entity);

        }
        private async Task DeleteLogic(int id)
        {
            var currentTransaction = await _context.Transactions.SingleOrDefaultAsync(transaction => transaction.Id == id);
            if (currentTransaction is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            _context.Transactions.Remove(currentTransaction);
        }
    }
}
