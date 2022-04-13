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
        public async Task<IEnumerable<TransactionViewModel>> Get()
        {
            var result = await _transactionRepo.GetAllAsync();
            return result.Select(x => new TransactionViewModel
            {
                Id = x.Id,
                EmployeeFullName = x.Employee.FullName,
                CustomerFullName = x.Customer.FullName,
                PaymentMethod = x.PaymentMethod,
                TotalValue = x.TotalValue,
            });
        }

        [HttpGet("{id}")]
        public async Task<TransactionViewModel?> Get(int id)
        {
            TransactionViewModel model = new();
            if (id != 0)
            {
                var existing = await _transactionRepo.GetByIdAsync(id);
                if (existing is null)
                    return null;
                model.Id = existing.Id;
                model.EmployeeFullName = existing.Employee.FullName;
                model.CustomerFullName = existing.Customer.FullName;
                model.PaymentMethod = existing.PaymentMethod;
                model.TotalValue = existing.TotalValue;
            }
            return model;
        }

        [HttpPost]
        public async Task Post(TransactionViewModel transactionViewModel)
        {
            var newTransaction = new Transaction()
            {
                Date = DateTime.Now,
                
            };
            
            await _transactionRepo.AddAsync(newTransaction);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TransactionViewModel transactionViewModel)
        {
            var itemToUpdate = await _transactionRepo.GetByIdAsync(transactionViewModel.Id);
            if (itemToUpdate is null) return NotFound();

            

            await _transactionRepo.UpdateAsync(transactionViewModel.Id, itemToUpdate);
            return Ok();
        }

        [HttpDelete("{ID}")]
        public async Task Delete(int id)
        {
            var selectedTransaction = await _transactionRepo.GetByIdAsync(id);
            if (selectedTransaction is null)
            {
                return;
            }

            await _transactionRepo.DeleteAsync(id);
        }
    }
}
