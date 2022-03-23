using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class EngineerRepo : IEntityRepo<Engineer>
    {
        public async Task Create(Engineer entity)
        {
            var _context = new Session_14Context();
            var engineerExist = _context.Engineers.FirstOrDefault(e => e.ID == entity.ID);
            if (engineerExist is not null)
            {
                return;
            }
            _context.Engineers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var engineerExist = _context.Engineers.FirstOrDefault(e => e.ID == id);
            if (engineerExist is null)
            {
                return;
            }
            _context.Engineers.Remove(engineerExist);
            await _context.SaveChangesAsync();
        }

        public List<Engineer> GetAll()
        {
            var _context = new Session_14Context();
            return _context.Engineers.ToList();
        }

        public Engineer? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.Engineers.FirstOrDefault(e => e.ID == id);
        }

        public async Task Update(Guid id, Engineer entity)
        {
            var _context = new Session_14Context();
            var engineerExist = _context.Engineers.FirstOrDefault(e => e.ID == entity.ID);
            if (engineerExist is null)
            {
                return;
            }
            engineerExist.Name = entity.Name;
            engineerExist.Surname = entity.Surname;
            engineerExist.ManagerID = entity.ManagerID;
            engineerExist.SallaryPerMonth = entity.SallaryPerMonth;
            await _context.SaveChangesAsync();
        }
    }
}
