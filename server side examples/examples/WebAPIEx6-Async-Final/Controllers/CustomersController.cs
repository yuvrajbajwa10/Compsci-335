using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIEx6.Models;
using WebAPIEx6.Data;
using WebAPIEx6.Dtos;

namespace WebAPIEx6.Controllers
{
    [Route("webapi")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IWebAPIRepo _repository;

        public CustomersController(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        // GET /webapi/GetCustomers
        [HttpGet("GetCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerOutDto>>> GetCustomersAsync()
        {
            Task< IEnumerable < Customer >> t = _repository.GetAllCustomersAsync();
            await t;
            IEnumerable<Customer> customers = t.Result;
            //IEnumerable <Customer> customers = await _repository.GetAllCustomersAsync();
            IEnumerable <CustomerOutDto> c = customers.Select(e => new CustomerOutDto { Id = e.Id, FirstName = e.FirstName, LastName = e.LastName });
            return Ok(c);
        }

        // GET /webapi/GetCustomer/{ID}
        [HttpGet("GetCustomer/{ID}")]
        public async Task<ActionResult<CustomerOutDto>> GetCustomerAsync(int id)
        {
            Customer customer = await _repository.GetCustomerByIDAsync(id);
            if (customer == null)
                return NotFound();
            else {
                CustomerOutDto c = new CustomerOutDto { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName };
                return Ok(c);
            }
                
        }

        [HttpPost("AddCustomer")]
        public async Task<ActionResult<CustomerOutDto>> AddCustomerAsync(CustomerInputDto customer)
        {
            Customer c = new Customer { FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email };
            Customer addedCustomer = await _repository.AddCustomerAsync(c);
            CustomerOutDto co = new CustomerOutDto { Id = addedCustomer.Id, FirstName = addedCustomer.FirstName, LastName = addedCustomer.LastName };
            return CreatedAtAction(nameof(GetCustomerAsync), new { id = co.Id }, co);
        }

        // PUT /webapi/UpdateCustomer/{id}
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<ActionResult> UpdateCustomerAsync(int id, CustomerInputDto customer)
        {
            Customer c = await _repository.GetCustomerByIDAsync(id);
            if (c == null)
                return NotFound();
            else
            {
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.Email = customer.Email;
                await _repository.SaveChangesAsync();
                return NoContent();
            }
        }

        // DELETE /webapi/DeleteCustomer/{id}
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomerAsync(int id)
        {
            Customer c = await _repository.GetCustomerByIDAsync(id);
            if (c == null)
                return NotFound();
            else
            {
                await _repository.DeleteCustomerAsync(id);
                return NoContent();
            }
        }
    }
}
