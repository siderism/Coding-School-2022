using Final.EF.Context;
using Final.EF.Repos;
using Final.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Handlers
{
    public class LedgerHandler
    {
        private decimal _rentCost = 5000.0m;
        private readonly FinalContext _context;
        private readonly IEntityRepo<Transaction> _transactionRepo;

        public LedgerHandler(FinalContext context, IEntityRepo<Transaction> transactionRepo)
        {
            _context = context;
            _transactionRepo = transactionRepo;
        }

        public async Task<decimal> GetIncome(Ledger ledger)
        {
            var transactions = await _transactionRepo.GetAllAsync();
            return transactions.Where(transaction => transaction.Date.Year == ledger.Year && transaction.Date.Month == ledger.Month).Sum(transaction => transaction.TotalValue);
        }

        private decimal GetStuffExpences(Ledger ledger)
        {
            decimal expences = 0m;
            foreach (var employee in _context.Employees)
            {
                int daysWorked = CalculateWorkingDays(ledger, employee);
                expences += (employee.SallaryPerMonth / DateTime.DaysInMonth(ledger.Year, ledger.Month)) * daysWorked;
            }
            return expences;
        }

        private async Task<decimal> GetItemExpences(Ledger ledger)
        {
            var transaction = await _transactionRepo.GetAllAsync();
            var monthlyTrans = transaction.Where(transaction => transaction.Date.Year == ledger.Year && transaction.Date.Month == ledger.Month);
            var expences = 0m;
            foreach(var t in monthlyTrans)
            {
                expences += t.TransactionLines.Sum(tl => tl.Item.Cost * tl.Quantity);
            }
            return expences;
        }

        public async Task<decimal> GetTotalExpences(Ledger ledger)
        {
            var itemExpences = await GetItemExpences(ledger);
            return GetStuffExpences(ledger) + itemExpences + _rentCost;
        }

        public async Task<decimal> GetTotal(Ledger ledger)
        {
            var income = await GetIncome(ledger);
            var expences = await GetTotalExpences(ledger);
            return income - expences;
        }

        private int CalculateWorkingDays(Ledger ledger, Employee employee)
        {
            DateTime dateTimeBegin = new DateTime(ledger.Year, ledger.Month, 1);
            DateTime dateTimeEnd = new DateTime(ledger.Year, ledger.Month, DateTime.DaysInMonth(ledger.Year, ledger.Month));
            if(!HasWorkedThisMonth(employee, dateTimeBegin, dateTimeEnd))
                return 0;
            if(HasWorkedWholeMonth(employee, dateTimeBegin, dateTimeEnd))
                return DateTime.DaysInMonth(ledger.Year, ledger.Month);
            if(employee.HireDateStart > dateTimeBegin && employee.HireDateEnd >= dateTimeEnd)
            {
                int daysInMonth = DateTime.DaysInMonth(ledger.Year, ledger.Month);
                int startDay = employee.HireDateStart.Day;
                return daysInMonth - startDay;
            }
            if(employee.HireDateStart <= dateTimeBegin && employee.HireDateEnd < dateTimeEnd)
                return employee.HireDateEnd.Day;
            return (employee.HireDateEnd - employee.HireDateStart).Days;
        }

        private bool HasWorkedThisMonth(Employee employee, DateTime begin, DateTime end)
        {
            if (begin > employee.HireDateEnd || end < employee.HireDateStart)
                return false;
            return true;
        }

        private bool HasWorkedWholeMonth(Employee employee, DateTime begin, DateTime end)
        {
            if (employee.HireDateStart <= begin && employee.HireDateEnd >= end)
                return true;
            return false;
        }

        public void SetRentCost(decimal rent)
        {
            _rentCost = rent;
        }
    }
}
