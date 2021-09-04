using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using SHIT_Web_API_A1_YBAJ161.Data;
using SHIT_Web_API_A1_YBAJ161.Models;
using SHIT_Web_API_A1_YBAJ161.Dtos;
using SHIT_Web_API_A1_YBAJ161.Helper;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace SHIT_Web_API_A1_YBAJ161.Controllers
{
    [Route("api")]
    [ApiController]
    public class SHITController : Controller
    {
        private readonly IShitWebAPIRepo _repository;

        public SHITController(IShitWebAPIRepo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Get /api/GetLogo
        [HttpGet("GetLogo")]
        public ActionResult GetLogo()
        {
            string path = @"SHITData\StaffPhotos\logo.png";
            string FullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            string respHeader = "";
            string fileName = "";
            if (System.IO.File.Exists(FullPath))
            {
                respHeader = "image/png";
                fileName = FullPath;
            }
            else
            {
                return NotFound();
            }
            return PhysicalFile(fileName, respHeader);
        }

        // Get /api/GetVersion
        [HttpGet("GetVersion")]
        public ActionResult GetVersion()
        {
            return Ok("v1");
        }


        //Get/API/GetAllStaff 
        [HttpGet("GetAllStaff")]
        public ActionResult GetAllStaff()
        {
            IEnumerable<Staff> customers = _repository.GetAllStaff();
            IEnumerable<StaffOutDto> c = customers.Select(e => new StaffOutDto
            {
                Id = e.Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Title = e.Title,
                Email = e.Email,
                Tel = e.Tel,
                Url = e.Url,
                Research = e.Research
            });
            return Ok(c);
        }
        //Upload data from JSON to Database
        [HttpGet("UploadStaffData")]
        public ActionResult UploadStaffData()
        {
            using (var reader = new StreamReader(@"SHITData\Staff.csv"))
            {
                reader.ReadLine();
                List<string> StaffData = new List<string>();
                while (!reader.EndOfStream)
                {
                    //Throw away first line
                    var line = reader.ReadLine();
                    var e = line.Split(",");
                    string reseachFixed = string.Join(",", e.Skip(7));
                    reseachFixed = reseachFixed.Substring(1, reseachFixed.Length - 2);
                    Staff s = new Staff() {
                        Id = int.Parse(e[0]),
                        LastName = e[1],
                        FirstName = e[2],
                        Title = e[3],
                        Email = e[4],
                        Tel = e[5],
                        Url = e[6],
                        Research = reseachFixed };

                    _repository.AddStaff(s);
                }
            }

            return Ok("Upload Success");
        }

        //Get/API/GetStaffPhoto/{id}
        [HttpGet("GetStaffPhoto/{id}")]
        public ActionResult GetStaffPhoto(int id)
        {

            string path = @"SHITData\StaffPhotos";
            string Folderpath = Path.Combine(Directory.GetCurrentDirectory(), path);
            string imgName = id.ToString() + ".jpg";
            string ImgPath = Path.Combine(Folderpath, imgName);


            if (System.IO.File.Exists(ImgPath))
            {
                return PhysicalFile(ImgPath, "image/jpeg");
            }
            else
            {
                string defualtImg = Path.Combine(Folderpath, "default.png");
                return PhysicalFile(defualtImg, "image/png");
            }

        }
        //Post/Api/AddProduct
        [HttpPost("AddProduct")]
        public ActionResult AddProduct(ProductsInputDto e)
        {
            Products p = new Products
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
            };
            Products addedProducts = _repository.AddProduct(p);
            ProductsOutDto po = new ProductsOutDto
            {
                Id = addedProducts.Id,
                Name = addedProducts.Name,
                Description = addedProducts.Description,
                Price = addedProducts.Price,
            };
            return CreatedAtAction(nameof(GetItems), new { id = po.Id }, po);
        }

        //Get/Api/GetItems/
        [HttpGet("GetItems")]
        public ActionResult GetItems(string name)
        {
            IEnumerable<Products> products = _repository.GetAllProducts();
            IEnumerable<ProductsOutDto> p = products.Select(e => new ProductsOutDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
            });
            return Ok(p);
        }
        //Get/Api/GetItems/{name}
        [HttpGet("GetItems/{name}")]
        public ActionResult GetItemsByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                name = "";
            }
            name = name.Trim();

            IEnumerable<Products> products = _repository.GetAllProducts();
            List<Products> pp = new List<Products>();
            foreach (Products p in products)
            {
                if (p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    pp.Add(p);
                }
            }

            IEnumerable<ProductsOutDto> productList = pp.Select(e => new ProductsOutDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
            });

            return Ok(productList);
        }

        //Get/API/GetItemPhoto/{id}
        [HttpGet("GetItemPhoto/{id}")]
        public ActionResult GetItemPhoto(int id)
        {

            string path = @"SHITData\ItemsImages";
            string Folderpath = Path.Combine(Directory.GetCurrentDirectory(), path);
            string imgNamejph = id.ToString() + ".jpg";
            string ImgPathjpg = Path.Combine(Folderpath, imgNamejph);
            string imgNamepng = id.ToString() + ".png";
            string ImgPathpng = Path.Combine(Folderpath, imgNamepng);
            string imgNamesvg = id.ToString() + ".png";
            string ImgPathsvg = Path.Combine(Folderpath, imgNamesvg);



            if (System.IO.File.Exists(ImgPathjpg))
            {
                return PhysicalFile(ImgPathjpg, "image/jpeg");
            }
            if (System.IO.File.Exists(ImgPathpng))
            {
                return PhysicalFile(ImgPathpng, "image/png");
            }
            if (System.IO.File.Exists(ImgPathsvg))
            {
                return PhysicalFile(ImgPathsvg, "image/svg");
            }
            else
            {
                string defualtImg = Path.Combine(Folderpath, "default.png");
                return PhysicalFile(defualtImg, "image/png");
            }

        }

        //get/api/GetCard
        [HttpGet("GetCard/{id}")]
        public ActionResult GetCard(int id)
        {
            Staff staff = _repository.GetStaffById(id);
            string path = Directory.GetCurrentDirectory();
            string fileName = Path.Combine(path, @"SHITData\StaffPhotos\" + id + ".jpg");
            string photoString, photoType;
            ImageFormat imageFormat;
            CardOut cardOut = new CardOut();

            if (staff == null)
            {
                Response.Headers.Add("Content-Type", "text/vcard");
                return Ok(cardOut);
            }
            if (System.IO.File.Exists(fileName))
            {
                Image image = Image.FromFile(fileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(200, 200), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else {
                photoString = "";
            }
            var researchList = staff.Research.Split(", ");
            string research = string.Join(",", researchList);
            cardOut.FirstName = staff.FirstName;
            cardOut.LastName = staff.LastName;
            cardOut.Title = staff.Title;
            cardOut.Tel = staff.Tel;
            cardOut.Email = staff.Email;
            cardOut.Url = staff.Url;
            cardOut.Id = staff.Id.ToString();
            cardOut.Org = "Southern Hemisphere Institue of Technology";
            cardOut.Photo = photoString;
            cardOut.Research = research;
            Response.Headers.Add("Content-Type", "text/vcard");
            return Ok(cardOut);
        }

        //get/api/GetComments
        [HttpGet("GetComments")]
        public ActionResult GetComments()
        {
            IEnumerable<Comments> comments = _repository.Get5Comments();

            IEnumerable<CommentOutDto> c = comments.Select(e => new CommentOutDto
            {
                Name = e.Name,
                Comment = e.Comment,
            });
            StringBuilder builder = new StringBuilder();
            foreach (CommentOutDto co in c)
            {
                builder.AppendLine(string.Format("<p>{0} — {1}</p>",co.Comment,co.Name));
            }
            Response.Headers.Add("Content-Type", "text/html");
            return base.Content(builder.ToString(), "text/html") ;

        }

        //Post/api/WriteComment
        [HttpPost("WriteComment")]
        public ActionResult WriteComment(CommentInputDto e)
        {
            if ((e.Name == null || e.Name == "") & (e.Comment == null || e.Comment == ""))
            {
                return BadRequest("Enter Something for comment or name");
            }
            if (String.IsNullOrWhiteSpace(e.Comment))
            {
                e.Comment = "";
            }
            if (String.IsNullOrWhiteSpace(e.Name))
            {
                e.Name = "";
            }
            Comments c = new Comments()
            {
                Name = e.Name,
                Comment = e.Comment,
                Time = DateTime.Now.ToString(),
                IP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),

            };
            Comments addedComments = _repository.AddComments(c);
            CommentOutDto po = new CommentOutDto
            {
                Name = addedComments.Name,
                Comment = addedComments.Comment,
            };
            return CreatedAtAction(nameof(GetComments), new { Comment = po.Comment }, po);
        }

    }



}
