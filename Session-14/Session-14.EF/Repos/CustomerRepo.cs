using Session_14.EF.Context;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Repos
{
    public class CustomerRepo : IEntityRepo<Customer>
    {
        public async Task Create(Customer entity)
        {
            var _context = new Session_14Context();
            var customerExist = _context.Customers.FirstOrDefault(c => c.ID == entity.ID);
            if (customerExist is not null)
            {
                return;
            }
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var _context = new Session_14Context();
            var customerExist = _context.Customers.FirstOrDefault(c => c.ID == id);
            if (customerExist is null)
            {
                return;
            }
            _context.Customers.Remove(customerExist);
            await _context.SaveChangesAsync();
        }

        public List<Customer> GetAll()
        {
            var _context = new Session_14Context();
            return _context.Customers.ToList();
        }

        public Customer? GetById(Guid id)
        {
            var _context = new Session_14Context();
            return _context.Customers.FirstOrDefault(c => c.ID == id);
        }

        public async Task Update(Guid id, Customer entity)
        {
            var _context = new Session_14Context();
            var customerExist = _context.Customers.FirstOrDefault(c => c.ID == entity.ID);
            if (customerExist is null)
            {
                return;
            }
            customerExist.Name = entity.Name;
            customerExist.Surname = entity.Surname;
            customerExist.TIN = entity.TIN;
            customerExist.Phone = entity.Phone;
            await _context.SaveChangesAsync();
        }
    }
}
