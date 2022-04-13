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
    public class CustomerRepo : IEntityRepo<Customer>
    {
        private readonly FinalContext _context;

        public CustomerRepo(FinalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer entity)
        {
            await AddLogic(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteLogic(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(customer => customer.Id == id);
        }

        public async Task UpdateAsync(int id, Customer entity)
        {
            await UpdateLogic(id, entity);
            await _context.SaveChangesAsync();
        }

        private async Task AddLogic(Customer entity)
        {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            if (!(await CardNumberExists(entity)))
            {
                await _context.Customers.AddAsync(entity);
            }

        }
        private async Task DeleteLogic(int id)
        {
            var currentCustomer = await _context.Customers.SingleOrDefaultAsync(customer => customer.Id == id);
            if (currentCustomer is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            _context.Customers.Remove(currentCustomer);
        }

        private async Task UpdateLogic(int id, Customer entity)
        {
            var currentCustomer = await _context.Customers.SingleOrDefaultAsync(customer => customer.Id == id);
            if (currentCustomer is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            currentCustomer.Name = entity.Name;
            currentCustomer.Surname = entity.Surname;
            currentCustomer.CardNumber = entity.CardNumber;

        }

        public async Task<bool> CardNumberExists(Customer entity)
        {
            return await _context.Customers.SingleOrDefaultAsync(customer => customer.CardNumber == entity.CardNumber) is not null;
        }
    }
}
