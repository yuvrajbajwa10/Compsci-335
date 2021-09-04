using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using SHIT_Web_API_A1_YBAJ161.Dtos;
using System.Drawing;
using System.Drawing.Imaging;



namespace SHIT_Web_API_A1_YBAJ161.Helper
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            string fileName = @"SHITData\StaffPhotos\logo.png";
            ImageFormat imageFormat;
            string photoString, photoType;
            Image image = Image.FromFile(fileName);
            imageFormat = image.RawFormat;
            image = ImageHelper.Resize(image, new Size(100, 100), out photoType);
            photoString = ImageHelper.ImageToString(image, imageFormat);
            


            CardOut card = (CardOut)context.Object;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:4.0");
            string n = String.Format("{0};{1};;{2};", card.LastName, card.FirstName, card.Title);
            builder.Append("N:").AppendLine(n);
            builder.Append("FN:").AppendLine(card.Title+ " "+ card.FirstName + " " + card.LastName);
            builder.Append("UID:").AppendLine(card.Id);
            builder.Append("ORG:").AppendLine(card.Org);
            builder.Append("EMAIL;TYPE=work:").AppendLine(card.Email);
            builder.Append("TEL:").AppendLine(card.Tel);
            builder.Append("URL:").AppendLine(card.Url);
            builder.Append("CATEGORIES:").AppendLine(card.Research);
            builder.Append("PHOTO;ENCODING=BASE64;TYPE=JPEG:").AppendLine(card.Photo);
            builder.Append("LOGO;ENCODING=BASE64;TYPE=PNG:").AppendLine(photoString);
            builder.AppendLine("END:VCARD");
            string outString = builder.ToString();
            byte[] outBytes = selectedEncoding.GetBytes(outString);
            var response = context.HttpContext.Response.Body;
            return response.WriteAsync(outBytes, 0, outBytes.Length);
        }
    }
}
