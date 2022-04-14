using Final.EF.Context;
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

        public LedgerHandler(FinalContext context)
        {
            _context = context;
        }

        public decimal GetIncome(Ledger ledger)
        {
            return _context.Transactions.Where(transaction => transaction.Date.Year == ledger.Year && transaction.Date.Month == ledger.Month).Sum(transaction => transaction.TotalValue);
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

        private decimal GetItemExpences(Ledger ledger)
        {
            var monthlyTrans = _context.Transactions.Where(transaction => transaction.Date.Year == ledger.Year && transaction.Date.Month == ledger.Month);
            var expences = 0m;
            foreach(var t in monthlyTrans)
            {
                expences += t.TransactionLines.Sum(tl => tl.Item.Cost * tl.Quantity);
            }
            return expences;
        }

        public decimal GetTotalExpences(Ledger ledger)
        {
            return GetStuffExpences(ledger) + GetItemExpences(ledger) + _rentCost;
        }

        public decimal GetTotal(Ledger ledger)
        {
            return GetIncome(ledger) - GetTotalExpences(ledger);
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
