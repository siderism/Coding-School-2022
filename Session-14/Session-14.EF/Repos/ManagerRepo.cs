using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class ManagerRepo : IEntityRepo<Manager>
    {
        public async Task Create(Manager entity)
        {
            var _context = new Session_14Context();
            var managerExist = _context.Managers.FirstOrDefault(m => m.ID == entity.ID);
            if (managerExist is not null)
            {
                return;
            }
            _context.Managers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var managerExist = _context.Managers.FirstOrDefault(m => m.ID == id);
            if (managerExist is null)
            {
                return;
            }
            _context.Managers.Remove(managerExist);
            await _context.SaveChangesAsync();
        }

        public List<Manager> GetAll()
        {
            var _context = new Session_14Context();
            return _context.Managers.ToList();
        }

        public Manager? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.Managers.FirstOrDefault(m => m.ID == id);
        }

        public async Task Update(Guid id, Manager entity)
        {
            var _context = new Session_14Context();
            var managerExist = _context.Managers.FirstOrDefault(m => m.ID == entity.ID);
            if (managerExist is null)
            {
                return;
            }
            managerExist.Name = entity.Name;
            managerExist.Surname = entity.Surname;
            managerExist.SallaryPerMonth = entity.SallaryPerMonth;
            await _context.SaveChangesAsync();
        }
    }
}
