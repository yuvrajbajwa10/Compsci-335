using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asignment_2SHITWEBAPI.DTO;
using Asignment_2SHITWEBAPI.Models;
using Asignment_2SHITWEBAPI.Data;

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

        // Get /api/GetVersionA
        [HttpGet("GetVersionA")]
        public ActionResult GetVersion()
        {
            return Ok("v1");
        }

    }
}
