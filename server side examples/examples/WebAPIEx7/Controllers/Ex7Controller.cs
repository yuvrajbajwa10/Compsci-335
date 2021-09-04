using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIEx7.Controllers
{
    [Route("webapi")]
    [ApiController]
    public class Ex7Controller : Controller
    {
        // GET /webapi/Get335
        [HttpGet("Get335")]
        public ContentResult Get335()
        {
            string cs335 = "<html><body>This is 335.</body></html> ";
            ContentResult c = new ContentResult
            {
                Content = cs335,
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
            };
            return c;
        }
    }
}
