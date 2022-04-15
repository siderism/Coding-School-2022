using Final.Handlers;
using Final.Model;
using Final.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LedgerController : ControllerBase
    {
        private readonly LedgerHandler _handler;

        public LedgerController(LedgerHandler ledgerHandler)
        {
            _handler = ledgerHandler;
        }

        [HttpGet("{year}/{month}/{rent}")]
        public async Task<LedgerViewModel> Get(int year, int month, decimal rent)
        {
            var ledgerViewModel = new LedgerViewModel()
            {
                Year = year,
                Month = month
            };
            var ledger = new Ledger()
            {
                Year = year,
                Month = month
            };
            _handler.SetRentCost(rent);
            ledgerViewModel.Income = await _handler.GetIncome(ledger);
            ledgerViewModel.Expenses = await _handler.GetTotalExpences(ledger);
            ledgerViewModel.Total = await _handler.GetTotal(ledger);
            return ledgerViewModel;
        }
    }
}
