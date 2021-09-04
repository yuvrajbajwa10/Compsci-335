using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationEx2.Data;
using AuthenticationEx2.Dto;
using AuthenticationEx2.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthenticationEx2.Controllers
{
    [Route("api")]
    [ApiController]
    public class MyController : Controller
    {
        private readonly IAuthRepo _repository;

        public MyController(IAuthRepo repository)
        {
            _repository = repository;
        }

        // GET api/ViewCustomer
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("ViewCustomer")]
        public ActionResult<CustomerOutputDto> ViewCustomer()
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("userName");
            string email = c.Value;
            Customer customer = _repository.GetCustomerByEmail(email);
            CustomerOutputDto cOut = new CustomerOutputDto { FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Password = customer.Password };
            return Ok(cOut);
        }

        // GET api/ListAllCustomers
        [Authorize(AuthenticationSchemes = "AdminAuthentication")]
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("ListAllCustomers")]
        public ActionResult<IEnumerable<CustomerOutputDto>> ListAllCustomers()
        {
            IEnumerable<Customer> customers = _repository.GetAllCustomers();
            IEnumerable<CustomerOutputDto> cOut = customers.Select(e => new CustomerOutputDto { FirstName = e.FirstName, LastName = e.LastName, Email=e.Email,Password=e.Password });
            return Ok(cOut);
        }
    }
}
