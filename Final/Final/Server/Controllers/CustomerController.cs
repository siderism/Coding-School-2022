﻿using Final.EF.Repos;
using Final.Model;
using Final.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Final.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IEntityRepo<Customer> _customerRepo;

        public CustomerController(IEntityRepo<Customer> entityRepo)
        {
            _customerRepo = entityRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            var result = await _customerRepo.GetAllAsync();
            return result.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                CardNumber = x.CardNumber
            });
        }

        [HttpGet("{id}")]
        public async Task<CustomerViewModel?> Get(int id)
        {
            CustomerViewModel model = new();
            if (id != 0)
            {
                var existing = await _customerRepo.GetByIdAsync(id);
                if (existing is null)
                    return null;
                model.Id = existing.Id;
                model.Name = existing.Name;
                model.Surname = existing.Surname;
                model.CardNumber = existing.CardNumber;
            }
            return model;
        }

        [HttpPost]
        public async Task Post(CustomerEditViewModel customerViewModel)
        {
            var newCustomer = new Customer()
            {
                Name = customerViewModel.Name,
                Surname = customerViewModel.Surname,
            };
            bool cardExist = true;
            string cardNumber = string.Empty;
            var customers = await _customerRepo.GetAllAsync();
            while (cardExist)
            {
                cardNumber = $"A{Guid.NewGuid().ToString("N").Substring(0, 9)}";
                if(!customers.Where(customer => customer.CardNumber == cardNumber).Any())
                {
                    cardExist = false;
                }
            }
            newCustomer.CardNumber = cardNumber;
            await _customerRepo.AddAsync(newCustomer);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CustomerEditViewModel customerEditViewModel)
        {
            var itemToUpdate = await _customerRepo.GetByIdAsync(customerEditViewModel.Id);
            if (itemToUpdate is null) return NotFound();

            itemToUpdate.Name = customerEditViewModel.Name;
            itemToUpdate.Surname = customerEditViewModel.Surname;

            await _customerRepo.UpdateAsync(customerEditViewModel.Id, itemToUpdate);
            return Ok();
        }

        [HttpDelete("{ID}")]
        public async Task Delete(int id)
        {
            var selectedEmployee = await _customerRepo.GetByIdAsync(id);
            if (selectedEmployee is null)
            {
                return;
            }

            await _customerRepo.DeleteAsync(id);
        }
    }
}