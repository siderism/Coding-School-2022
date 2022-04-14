using Final.EF.Repos;
using Final.Model;
using Final.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;

        public TransactionController(IEntityRepo<Transaction> entityRepo)
        {
            _transactionRepo = entityRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionListViewModel>> Get()
        {
            var result = await _transactionRepo.GetAllAsync();
            return result.Select(x => new TransactionListViewModel
            {
                Id = x.Id,
                EmployeeFullName = x.Employee.FullName,
                CustomerFullName = x.Customer.FullName,
                PaymentMethod = x.PaymentMethod,
                Date = x.Date,
                TotalValue = x.TotalValue,
            });
        }

        [HttpGet("{id}")]
        public async Task<TransactionEditViewModel?> Get(int id)
        {
            var getTransaction = new TransactionEditViewModel();
            if (id != 0)
            {
                var existing = await _transactionRepo.GetByIdAsync(id);
                if (existing == null) throw new ArgumentException($"Given id '{id}' was not found in database");

                getTransaction.Id = existing.Id;
                getTransaction.PaymentMethod = existing.PaymentMethod;
                getTransaction.TotalValue = existing.TotalValue;
                getTransaction.CustomerFullName = $"{existing.Customer.Name} {existing.Customer.Surname}";
                getTransaction.EmployeeFullName = $"{existing.Employee.Name} {existing.Employee.Surname}";
                getTransaction.CustomerId = existing.Customer.Id;
                getTransaction.EmployeeId = existing.Employee.Id;
                ConvertTransactionLineToViewModel(getTransaction, existing);
            }
            return getTransaction;
        }

        [HttpPost]
        public async Task Post(TransactionEditViewModel transactionViewModel)
        {
            var newTransaction = new Transaction()
            {
                CustomerId = transactionViewModel.CustomerId,
                EmployeeId = transactionViewModel.EmployeeId,
                PaymentMethod = transactionViewModel.PaymentMethod,
                TotalValue = transactionViewModel.TotalValue,
                TransactionLines = new()
            };
            newTransaction.Date = DateTime.Now;
            ConvertViewModelLineToTransactionLine(transactionViewModel, newTransaction);

            await _transactionRepo.AddAsync(newTransaction);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TransactionEditViewModel transactionViewModel)
        {
            var transactionUpdate = await _transactionRepo.GetByIdAsync(transactionViewModel.Id);
            if (transactionUpdate == null) return NotFound();
            transactionUpdate.CustomerId = transactionViewModel.CustomerId;
            transactionUpdate.EmployeeId = transactionViewModel.EmployeeId;
            transactionUpdate.PaymentMethod = transactionViewModel.PaymentMethod;
            transactionUpdate.TransactionLines = new();
            ConvertViewModelLineToTransactionLine(transactionViewModel, transactionUpdate);

            await _transactionRepo.UpdateAsync(transactionViewModel.Id, transactionUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var selectedTransaction = await _transactionRepo.GetByIdAsync(id);
            if (selectedTransaction is null)
            {
                return;
            }

            await _transactionRepo.DeleteAsync(id);
        }

        private void ConvertViewModelLineToTransactionLine(TransactionEditViewModel model, Transaction newTransaction)
        {
            foreach (var tl in model.TransactionLineList)
            {
                var helper = new TransactionLine()
                {
                    ItemId = tl.ItemId,
                    ItemPrice = tl.ItemPrice,
                    NetValue = tl.NetValue,
                    DiscountPercent = tl.DiscountPercent,
                    DiscountValue = tl.DiscountValue,
                    TotalValue = tl.TotalValue,
                    Quantity = tl.Quantity,
                };
                newTransaction.TransactionLines.Add(helper);
            }
        }

        private void ConvertTransactionLineToViewModel(TransactionEditViewModel model, Transaction newTransaction)
        {
            foreach (var tl in newTransaction.TransactionLines)
            {
                var helper = new TransactionLineEditViewModel()
                {
                    ItemId = tl.ItemId,
                    ItemPrice = tl.ItemPrice,
                    NetValue = tl.NetValue,
                    DiscountPercent = tl.DiscountPercent,
                    DiscountValue = tl.DiscountValue,
                    TotalValue = tl.TotalValue,
                    Quantity = tl.Quantity,
                    ItemDescription = tl.Item.Description
                };
                model.TransactionLineList.Add(helper);
            }
        }
    }
}
