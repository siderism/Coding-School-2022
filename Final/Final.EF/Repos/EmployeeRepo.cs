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
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        private readonly FinalContext _context;

        public EmployeeRepo(FinalContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee entity)
        {
            await AddLogic(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteLogic(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.SingleOrDefaultAsync(employee => employee.Id == id);
        }

        public async Task UpdateAsync(int id, Employee entity)
        {
            await UpdateLogic(id, entity);
            await _context.SaveChangesAsync();
        }

        private async Task AddLogic(Employee entity)
        {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));
            await _context.Employees.AddAsync(entity);

        }
        private async Task DeleteLogic(int id)
        {
            var currentEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.Id == id);
            if (currentEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            _context.Employees.Remove(currentEmployee);
        }

        private async Task UpdateLogic(int id, Employee entity)
        {
            var currentEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.Id == id);
            if (currentEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            currentEmployee.Name = entity.Name;
            currentEmployee.Surname = entity.Surname;
            currentEmployee.HireDateStart = entity.HireDateStart;
            currentEmployee.HireDateEnd = entity.HireDateEnd;
            currentEmployee.SallaryPerMonth = entity.SallaryPerMonth;
        }
    }
}
