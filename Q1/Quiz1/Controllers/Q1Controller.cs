using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz1.Models;
using Quiz1.Data;
using Quiz1.DTO;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Quiz1.Controllers
{
    [Route("quizapi")]
    [ApiController]
    public class Q1Controller : Controller
    {
        private readonly IQ1Repo _repository;

        public Q1Controller(IQ1Repo repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Get /quizapi/GetVersion
        [HttpGet("GetVersion")]
        public ActionResult GetVersion()
        {
            return Ok("v1");
        }
        // Get /quizapi/GetCourseInfo/{courseCode}
        [HttpGet("GetCourseInfo/{courseCode}")]
        public ActionResult GetCourseInfo(string courseCode)
        {
            string path = @"Quiz1DataXY-716636073";
            string Folderpath = Path.Combine(Directory.GetCurrentDirectory(), path);
            string courseFile = courseCode + ".html";
            string htmlPath = Path.Combine(Folderpath, courseFile);

            if (System.IO.File.Exists(htmlPath))
            {
                return PhysicalFile(htmlPath, "text/html");
            }
            else
            {
                return NotFound(string.Format("There is no course {0}", courseCode));
            }
        }

        // Get/ quizapi/ GetMarks
        [HttpGet("GetMarks")]
        public ActionResult GetMarks()
        {
            IEnumerable<Marks> marks = _repository.GetAllMarks();
            IEnumerable<MarksOutDTO> m = marks.Select(e => new MarksOutDTO
            {
                Id = e.Id,
                A1 = e.A1,
                A2 = e.A2
            });
            return Ok(m);
        }
        // get / quizapi/ GetMarkByID
        [HttpGet("GetMarkByID/{id}")]
        public ActionResult GetMarkByID(int id)
        {
            Marks m = _repository.GetMarksById(id);
            if (m == null)
            {
                return NotFound(string.Format("No record for the student with ID number {0}", id));
            }
            return Ok(new MarksOutDTO{Id = m.Id, A1 = m.A1, A2 = m.A2});
        }

        //Post / quizapi/ SetMark
        [HttpPost("SetMark")]
        public ActionResult SetMark(MarksInputDTO min)
        {
            Marks Returnm = null;
            Marks m = _repository.GetMarksById(min.Id);
            if (m == null)
            {
                Returnm  =_repository.AddMarks(new Marks { Id = min.Id, A1 = min.A1, A2 = min.A2 });
                return CreatedAtAction(nameof(GetMarks),new { id = Returnm.Id} ,new MarksOutDTO{Id = Returnm.Id, A1 = Returnm.A1, A2 = Returnm.A2 });
            }
            
            Returnm = _repository.UpdateMarks(new Marks { Id = min.Id, A1 = min.A1, A2 = min.A2 });
            return CreatedAtAction(nameof(GetMarks), new { id = Returnm.Id }, new MarksOutDTO { Id = Returnm.Id, A1 = Returnm.A1, A2 = Returnm.A2 });
             
        }

        // Get/ quizapi/ GetMarksAuth
        [Authorize(AuthenticationSchemes = "StaffAuthentication")]
        [Authorize(Policy = "StaffOnly")]
        [HttpGet("GetMarksAuth")]
        public ActionResult GetMarksAuth()
        {
            IEnumerable<Marks> marks = _repository.GetAllMarks();
            IEnumerable<MarksOutDTO> m = marks.Select(e => new MarksOutDTO
            {
                Id = e.Id,
                A1 = e.A1,
                A2 = e.A2
            });
            return Ok(m);
        }
        // get / quizapi/ GetMarkByIDAuth
        [Authorize(AuthenticationSchemes = "StudentAuthentication")]
        [Authorize(AuthenticationSchemes = "StaffAuthentication")]
        [HttpGet("GetMarkByIDAuth/{id}")]
        public ActionResult GetMarkByIDAuth(int id)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();;
            Claim Studentc = ci.FindFirst("Student");
            Marks m;
            if (Studentc != null)
            {
                string SuserName = Studentc.Value;
                m = _repository.GetMarksById(int.Parse(SuserName));
                return Ok(new MarksOutDTO { Id = m.Id, A1 = m.A1, A2 = m.A2 });


            }

                m = _repository.GetMarksById(id);
                if (m == null)
                {
                    return NotFound(string.Format("No record for the student with ID number {0}", id));
                }
                return Ok(new MarksOutDTO { Id = m.Id, A1 = m.A1, A2 = m.A2 });
            
        }
        //Post / quizapi/ SetMark
        [HttpPost("SetMarkAuth")]
        [Authorize(AuthenticationSchemes = "StaffAuthentication")]
        [Authorize(Policy = "StaffOnly")]
        public ActionResult SetMarkAuth(MarksInputDTO min)
        {
            Marks Returnm = null;
            Marks m = _repository.GetMarksById(min.Id);
            if (m == null)
            {
                Returnm = _repository.AddMarks(new Marks { Id = min.Id, A1 = min.A1, A2 = min.A2 });
                return CreatedAtAction(nameof(GetMarks), new { id = Returnm.Id }, new MarksOutDTO { Id = Returnm.Id, A1 = Returnm.A1, A2 = Returnm.A2 });
            }

            Returnm = _repository.UpdateMarks(new Marks { Id = min.Id, A1 = min.A1, A2 = min.A2 });
            return CreatedAtAction(nameof(GetMarks), new { id = Returnm.Id }, new MarksOutDTO { Id = Returnm.Id, A1 = Returnm.A1, A2 = Returnm.A2 });
        }
        // get/ quizapi/ GetSchedule
        [HttpGet("GetSchedule/{code}")]
        public ActionResult GetSchedule(string code)
        {
            Courses c = _repository.GetCoursesById(code);
            if (c == null)
            {
                return NotFound(string.Format("Course {0} is not found.", code));
            }
            VCalOutDTO vc = new VCalOutDTO { Code = c.Code, End1 = c.End1, End2 = c.End2, Location1 = c.Location1, Location2 = c.Location2, Start1 = c.Start1, Start2 = c.Start2, Weekday1 = c.Weekday1, Weekday2 = c.Weekday2 };
            Response.Headers.Add("Content-Type", "text/vcal");
            return Ok(vc);
        }
        // get / quizapi / GetTimetable

        [HttpGet("GetTimetable/{id}")]
        public ActionResult GetTimetable(string id)
        {
            IEnumerable<Courses> courses = _repository.GetTimetableStudent(id);
            if (courses.Count() == 0 || courses == null)
            {
                return NotFound(string.Format("Student {0} has not enrolled in any course.", id));
            }
            TimeTableOutDTO tt = new TimeTableOutDTO { sId = id, Courses = courses };
            Response.Headers.Add("Content-Type", "text/vTT");
            return Ok(tt);
        }

    }
}
