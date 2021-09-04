using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIvCard.Data;
using WebAPIvCard.Models;
using WebAPIvCard.Dtos;
using System.IO;
using System.Drawing;
using WebAPIvCard.Helper;
using System.Drawing.Imaging;

namespace WebAPIvCard.Controllers
{
    [Route("api")]
    [ApiController]
    public class BearController : Controller
    {
        private readonly ICardRepo _cardRepo;

        public BearController(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }

        [HttpGet("GetCard/{id}")]
        public ActionResult GetCard(int id)
        {
            Bear bear = _cardRepo.GetBear(id);
            string path = Directory.GetCurrentDirectory();
            string fileName = Path.Combine(path, "Images/"+id+".jpg");
            string photoString, photoType;
            ImageFormat imageFormat;
            if (System.IO.File.Exists(fileName))
            {
                Image image = Image.FromFile(fileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(100, 100), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else
                return NotFound();
            CardOut cardOut = new CardOut();
            cardOut.Name = bear.Title + " " + bear.FirstName + " " + bear.LastName;
            cardOut.Uid = bear.Id;
            cardOut.Photo = photoString;
            cardOut.PhotoType = photoType;
            cardOut.Categories = Helper.HobbiesFilter.Filter(bear.Hobbies);
            Response.Headers.Add("Content-Type", "text/vcard");
            return Ok(cardOut);
        }
    }
}
