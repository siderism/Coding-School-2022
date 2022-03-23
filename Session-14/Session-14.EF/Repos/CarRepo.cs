using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class CarRepo : IEntityRepo<Car>
    {
        public async Task Create(Car entity)
        {
            var _context = new Session_14Context();
            var carExist = _context.Cars.FirstOrDefault(c => c.ID == entity.ID);
            if (carExist is null)
            {
                return;
            }
            _context.Cars.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var carExist = _context.Cars.FirstOrDefault(c => c.ID == id);
            if (carExist is null)
            {
                return;
            }
            _context.Cars.Remove(carExist);
            await _context.SaveChangesAsync();
        }

        public List<Car> GetAll()
        {
            var _context = new Session_14Context();
            return _context.Cars.ToList();
        }

        public Car? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.Cars.FirstOrDefault(c => c.ID == id);
        }

        public async Task Update(Guid id, Car entity)
        {
            var _context = new Session_14Context();
            var carExist = _context.Cars.FirstOrDefault(c => c.ID == entity.ID);
            if (carExist is null)
            {
                return;
            }
            carExist.Brand = entity.Brand;
            carExist.Model = entity.Model;
            carExist.CarRegNumber = entity.CarRegNumber;
            await _context.SaveChangesAsync();
        }
    }
}
