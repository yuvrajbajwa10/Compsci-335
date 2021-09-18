using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz1.DTO;
using Quiz1.Models;

namespace Quiz1.Helper
{
    public class VTimeTableOutputFormatter : TextOutputFormatter
    {
        public VTimeTableOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vTT"));
            SupportedEncodings.Add(Encoding.UTF8);
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            List<string> dayofweek = new List<string> { "MO", "TU", "WE", "TH", "FR" };
            string iso = "yyyyMMddTHHmmss";
            TimeTableOutDTO tt = (TimeTableOutDTO)context.Object;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCALENDAR");
            builder.AppendLine("VERSION:2.0");
            builder.AppendLine("PRODID:YBAJ161");
            foreach (Courses card in tt.Courses) { 
            builder.AppendLine("BEGIN:VEVENT");
            builder.Append("UID:").AppendLine(card.Code + "-1");
            builder.Append("DTSTAMP:").AppendLine(DateTime.Now.ToString(iso));
            DateTime DTStart1 = new DateTime(2022, 1, 2).AddDays(dayofweek.IndexOf(card.Weekday1) + 1).AddHours(int.Parse(card.Start1.Split(":")[0]));
            DateTime DTEnd1 = new DateTime(2022, 1, 2).AddDays(dayofweek.IndexOf(card.Weekday1) + 1).AddHours(int.Parse(card.End1.Split(":")[0]));
            builder.Append("DTSTART:").AppendLine(DTStart1.ToString(iso));
            builder.Append("RRULE:FREQ=WEEKLY;BYDAY=").AppendLine(card.Weekday1);
            builder.Append("DTEND:").AppendLine(DTEnd1.ToString(iso));
            builder.Append("SUMMARY:").AppendLine(card.Code);
            builder.Append("LOCATION:").AppendLine(card.Location1);
            builder.AppendLine("END:VEVENT");
            if (card.Weekday2 != "")
            {
                builder.AppendLine("BEGIN:VEVENT");
                builder.Append("UID:").AppendLine(card.Code + "-2");
                builder.Append("DTSTAMP:").AppendLine(DateTime.Now.ToString(iso));
                DateTime DTStart2 = new DateTime(2022, 1, 2, 0, 0, 0).AddDays(dayofweek.IndexOf(card.Weekday2) + 1).AddHours(int.Parse(card.Start2.Split(":")[0]));
                DateTime DTEnd2 = new DateTime(2022, 1, 2, 0, 0, 0).AddDays(dayofweek.IndexOf(card.Weekday2) + 1).AddHours(int.Parse(card.End2.Split(":")[0]));
                builder.Append("DTSTART:").AppendLine(DTStart2.ToString(iso));
                builder.Append("RRULE:FREQ=WEEKLY;BYDAY=").AppendLine(card.Weekday2);
                builder.Append("DTEND:").AppendLine(DTEnd2.ToString(iso));
                builder.Append("SUMMARY:").AppendLine(card.Code);
                builder.Append("LOCATION:").AppendLine(card.Location2);
                builder.AppendLine("END:VEVENT");
            }
            }
            builder.AppendLine("END:VCALENDAR");
            string outString = builder.ToString();
            byte[] outBytes = selectedEncoding.GetBytes(outString);
            var response = context.HttpContext.Response.Body;
            return response.WriteAsync(outBytes, 0, outBytes.Length);
        }
    }
}
