using Final.EF.Repos;
using Final.Model;
using Final.Shared.ViewModels;
using Final.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Final.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepo<Employee> _employeeRepo;

        public EmployeeController(IEntityRepo<Employee> entityRepo)
        {
            _employeeRepo = entityRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            var result = await _employeeRepo.GetAllAsync();
            return result.Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                EmployeeType = x.EmployeeType,
                SallaryPerMonth = x.SallaryPerMonth,
                HireDateStart = x.HireDateStart,
                HireDateEnd = x.HireDateEnd
            });
        }

        [HttpGet("{id}")]
        public async Task<EmployeeViewModel?> Get(int id)
        {
            EmployeeViewModel model = new();
            if (id != 0)
            {
                var existing = await _employeeRepo.GetByIdAsync(id);
                if (existing is null)
                    return null;
                model.Id = existing.Id;
                model.Name = existing.Name;
                model.Surname = existing.Surname;
                model.SallaryPerMonth = existing.SallaryPerMonth;
                model.EmployeeType = existing.EmployeeType;
                model.HireDateStart = existing.HireDateStart;
                model.HireDateEnd = existing.HireDateEnd;
            }
            return model;
        }

        [HttpPost]
        public async Task Post(EmployeeViewModel employeeViewModel)
        {
            var newEmployee = new Employee()
            {
                Name = employeeViewModel.Name,
                Surname = employeeViewModel.Surname,
                SallaryPerMonth = employeeViewModel.SallaryPerMonth,
                EmployeeType = employeeViewModel.EmployeeType,
                HireDateStart = employeeViewModel.HireDateStart,
                HireDateEnd = employeeViewModel.HireDateEnd
            };
            //var employees = await _employeeRepo.GetAllAsync();
            //var employeeHandler = new EmployeeHandler(employees.ToList());
            //if (!employeeHandler.CheckAddAvailiability(newEmployee.EmployeeType))
            //    return;
            await _employeeRepo.AddAsync(newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EmployeeViewModel employeeViewModel)
        {
            var itemToUpdate = await _employeeRepo.GetByIdAsync(employeeViewModel.Id);
            if (itemToUpdate is null) return NotFound();

            var oldEmployeeType = itemToUpdate.EmployeeType;
            itemToUpdate.Name = employeeViewModel.Name;
            itemToUpdate.Surname = employeeViewModel.Surname;
            itemToUpdate.SallaryPerMonth = employeeViewModel.SallaryPerMonth;
            itemToUpdate.EmployeeType = employeeViewModel.EmployeeType;
            itemToUpdate.HireDateStart = employeeViewModel.HireDateEnd;
            itemToUpdate.HireDateEnd = employeeViewModel.HireDateStart;

            var employees = await _employeeRepo.GetAllAsync();
            //var employeeHandler = new EmployeeHandler(employees.ToList());

            //if (!employeeHandler.CheckUpdateAvailibility(oldEmployeeType, itemToUpdate.EmployeeType))
            //    return BadRequest();

            await _employeeRepo.UpdateAsync(employeeViewModel.Id, itemToUpdate);
            return Ok();
        }

        [HttpDelete("{ID}")]
        public async Task Delete(int id)
        {
            var selectedEmployee = await _employeeRepo.GetByIdAsync(id);
            if (selectedEmployee is null)
            {
                return;
            }
            var employees = await _employeeRepo.GetAllAsync();
            //var employeeHandler = new EmployeeHandler(employees.ToList());
            //if (!employeeHandler.CheckDeleteAvailiability(selectedEmployee.EmployeeType))
            //    return;
            await _employeeRepo.DeleteAsync(id);
        }
    }
}
