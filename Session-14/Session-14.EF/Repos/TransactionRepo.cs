using Microsoft.EntityFrameworkCore;
using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class TransactionRepo : IEntityRepo<Transaction>
    {
        public async Task Create(Transaction entity)
        {
            var _context = new Session_14Context();
            var transactionExist = _context.Transactions.FirstOrDefault(t => t.ID == entity.ID);
            if (transactionExist is not null)
            {
                return;
            }
            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var transactionExist = _context.Transactions.FirstOrDefault(t => t.ID == id);
            if (transactionExist is null)
            {
                return;
            }
            _context.Transactions.Remove(transactionExist);
            await _context.SaveChangesAsync();
        }

        public List<Transaction> GetAll()
        {
            var _context = new Session_14Context();
            return _context.Transactions.Include(t => t.TransactionLines).ToList();
        }

        public Transaction? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.Transactions.Include(t => t.TransactionLines).FirstOrDefault(c => c.ID == id);
        }

        public async Task Update(Guid id, Transaction entity)
        {
            await Task.CompletedTask;
        }
    }
}
