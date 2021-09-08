using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asignment_2SHITWEBAPI.DTO;
using Asignment_2SHITWEBAPI.Models;
using Asignment_2SHITWEBAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Asignment_2SHITWEBAPI.Controllers
{

    [Route("api")]
    [ApiController]
    public class SHITController : Controller
    {
        private readonly ISHITRepo _repository;

        public SHITController(ISHITRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST /api/Register
        [HttpPost("Register")]
        public ActionResult Register(UserInputDTO u)
        {
            if ( _repository.GetUsersById(u.Username) != null)
            {
                return Ok("Username not available.");
            }
            else
            {
                Users nu = new Users { UserName = u.Username, Address = u.Address, Password = u.Password };
                _repository.AddUsers(nu);
                return Ok("User successfully registered.");
            }
        }

        // Get /api/GetVersionA
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetVersionA")]
        public ActionResult GetVersion()
        {
            return Ok("v1");
        }

        // POST /api/PurchaseItem
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("PurchaseItem")]
        public ActionResult PurchaseItem(OrderInputDTO o)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("userName");
            string userName = c.Value;
            Orders no = new Orders() { UserName = userName, ProductID = o.ProductID, Quantity = o.Quantity };
            _repository.AddOrders(no);
            OrderOutDTO returnO = new OrderOutDTO() { OrderID = no.Id, ProductID = no.ProductID, Quantity = no.Quantity, Username = no.UserName };
            return Ok(returnO);
        }

        // Get /api/PurchaseSingleItem
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("PurchaseSingleItem/{pID}")]
        public ActionResult PurchaseSingleItem(int pID)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("userName");
            string userName = c.Value;
            Orders no = new Orders() { UserName = userName, ProductID = pID, Quantity = 1 };
            _repository.AddOrders(no);
            OrderOutDTO returnO = new OrderOutDTO() { OrderID = no.Id, ProductID = no.ProductID, Quantity = no.Quantity, Username = no.UserName };
            return Ok(returnO);


        }

    }
}
