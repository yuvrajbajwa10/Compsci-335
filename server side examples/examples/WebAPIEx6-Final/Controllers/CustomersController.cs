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
        public ActionResult<IEnumerable<CustomerOutDto>> GetCustomers()
        {
            IEnumerable<Customer> customers = _repository.GetAllCustomers();
            IEnumerable<CustomerOutDto> c = customers.Select(e => new CustomerOutDto { Id = e.Id, FirstName = e.FirstName, LastName = e.LastName });
            return Ok(c);
        }

        // GET /webapi/GetCustomer/{ID}
        [HttpGet("GetCustomer/{ID}")]
        public ActionResult<CustomerOutDto> GetCustomer(int id)
        {
            Customer customer = _repository.GetCustomerByID(id);
            if (customer == null)
                return NotFound();
            else {
                CustomerOutDto c = new CustomerOutDto { Id = customer.Id, FirstName = customer.FirstName, LastName = customer.LastName };
                return Ok(c);
            }
                
        }

        [HttpPost("AddCustomer")]
        public ActionResult<CustomerOutDto> AddCustomer(CustomerInputDto customer)
        {
            Customer c = new Customer { FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email };
            Customer addedCustomer = _repository.AddCustomer(c);
            CustomerOutDto co = new CustomerOutDto { Id = addedCustomer.Id, FirstName = addedCustomer.FirstName, LastName = addedCustomer.LastName };
            return CreatedAtAction(nameof(GetCustomer), new { id = co.Id }, co);
        }

        // PUT /webapi/UpdateCustomer/{id}
        [HttpPut("UpdateCustomer/{id}")]
        public ActionResult UpdateCustomer(int id, CustomerInputDto customer)
        {
            Customer c = _repository.GetCustomerByID(id);
            if (c == null)
                return NotFound();
            else
            {
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.Email = customer.Email;
                _repository.SaveChanges();
                return NoContent();
            }
        }

        // DELETE /webapi/DeleteCustomer/{id}
        [HttpDelete("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            Customer c = _repository.GetCustomerByID(id);
            if (c == null)
                return NotFound();
            else
            {
                _repository.DeleteCustomer(id);
                return NoContent();
            }
        }
    }
}
