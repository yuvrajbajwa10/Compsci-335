using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIImg.Controllers
{
    [Route("api")]
    [ApiController]
    public class ImgController : Controller
    {
        [HttpGet("GetImg/{name}")]
        public ActionResult GetImg(string name)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "Images");
            string fileName1 = Path.Combine(imgDir, name + ".png");
            string fileName2 = Path.Combine(imgDir, name + ".jpg");
            string fileName3 = Path.Combine(imgDir, name + ".gif");
            string respHeader = "";
            string fileName = "";
            if (System.IO.File.Exists(fileName1))
            {
                respHeader = "image/png";
                fileName = fileName1;
            }
            else if (System.IO.File.Exists(fileName2))
            {
                respHeader = "image/jpeg";
                fileName = fileName2;
            }
            else if (System.IO.File.Exists(fileName3))
            {
                respHeader = "image/gif";
                fileName = fileName3;
            }
            else
                return NotFound();
            return PhysicalFile(fileName, respHeader);
        }
    }
}
