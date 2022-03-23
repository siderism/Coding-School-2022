using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class ServiceTaskRepo : IEntityRepo<ServiceTask>
    {
        public async Task Create(ServiceTask entity)
        {
            var _context = new Session_14Context();
            var serviceExist = _context.ServiceTasks.FirstOrDefault(s => s.ID == entity.ID);
            if (serviceExist is null)
            {
                return;
            }
            _context.ServiceTasks.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var serviceExist = _context.ServiceTasks.FirstOrDefault(s => s.ID == id);
            if (serviceExist is null)
            {
                return;
            }
            _context.ServiceTasks.Remove(serviceExist);
            await _context.SaveChangesAsync();
        }

        public List<ServiceTask> GetAll()
        {
            var _context = new Session_14Context();
            return _context.ServiceTasks.ToList();
        }

        public ServiceTask? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.ServiceTasks.FirstOrDefault(s => s.ID == id);
        }

        public async Task Update(Guid id, ServiceTask entity)
        {
            var _context = new Session_14Context();
            var serviceExist = _context.ServiceTasks.FirstOrDefault(s => s.ID == entity.ID);
            if (serviceExist is null)
            {
                return;
            }
            serviceExist.Hours = entity.Hours;
            serviceExist.Code = entity.Code;
            serviceExist.Description = entity.Description;
            await _context.SaveChangesAsync();
        }
    }
}
