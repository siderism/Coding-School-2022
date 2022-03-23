using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class TransactionLineRepo : IEntityRepo<TransactionLine>
    {
        public async Task Create(TransactionLine entity)
        {
            var _context = new Session_14Context();
            var tlExist = _context.TransactionLines.FirstOrDefault(tl => tl.ID == entity.ID);
            if (tlExist is null)
            {
                return;
            }
            _context.TransactionLines.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var tlExist = _context.TransactionLines.FirstOrDefault(tl => tl.ID == id);
            if (tlExist is null)
            {
                return;
            }
            _context.TransactionLines.Remove(tlExist);
            await _context.SaveChangesAsync();
        }

        public List<TransactionLine> GetAll()
        {
            var _context = new Session_14Context();
            return _context.TransactionLines.ToList();
        }

        public TransactionLine? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.TransactionLines.FirstOrDefault(tl => tl.ID == id);
        }

        public async Task Update(Guid id, TransactionLine entity)
        {
            await Task.CompletedTask;
        }
    }
}
