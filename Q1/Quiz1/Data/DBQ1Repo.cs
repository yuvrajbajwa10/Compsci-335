using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quiz1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1.Data
{
    public class DBQ1Repo : IQ1Repo
    {
        private readonly Q1DBContext _dbContext;

        public DBQ1Repo(Q1DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Courses> GetTimetableStudent(string id)
        {
            IEnumerable<Enrolments> en = _dbContext.Enrolments.Where(e => e.StudentID == id);

            List<Courses> courses = new List<Courses>();
            foreach (Enrolments enn in en)
            {
                Courses c = _dbContext.Courses.FirstOrDefault(e => e.Code == enn.Course);
                if (c != null)
                {
                    courses.Add(c);
                }
            }
            return courses;
        }
    
    public Marks UpdateMarks(Marks m)
        {
            Marks marks = _dbContext.Marks.Single(e => e.Id == m.Id);
            marks.A1 = m.A1;
            marks.A2 = m.A2;
            _dbContext.SaveChanges();
            return (marks);
        }
        public Courses AddCourses(Courses c)
        {
            EntityEntry<Courses> courses = _dbContext.Courses.Add(c);
            Courses returnCourses = courses.Entity;
            _dbContext.SaveChanges();
            return returnCourses;
        }

        public Enrolments AddEnrolments(Enrolments e)
        {
            EntityEntry<Enrolments> enrolments = _dbContext.Enrolments.Add(e);
            Enrolments returnEnrolments = enrolments.Entity;
            _dbContext.SaveChanges();
            return returnEnrolments;
        }

        public Marks AddMarks(Marks m)
        {
            EntityEntry<Marks> marks = _dbContext.Marks.Add(m);
            Marks returnMarks = marks.Entity;
            _dbContext.SaveChanges();
            return returnMarks;
        }

        public Staff AddStaff(Staff s)
        {
            EntityEntry<Staff> staff = _dbContext.Staff.Add(s);
            Staff returnStaff = staff.Entity;
            _dbContext.SaveChanges();
            return returnStaff;
        }

        public Students AddStudents(Students s)
        {
            EntityEntry<Students> students = _dbContext.Students.Add(s);
            Students returnStudents = students.Entity;
            _dbContext.SaveChanges();
            return returnStudents;
        }

        public void DeleteCourses(string code)
        {
            Courses Course = _dbContext.Courses.FirstOrDefault(e => e.Code == code);
            if (Course != null)
            {
                _dbContext.Courses.Remove(Course);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteEnrolments(int en)
        {
            Enrolments Enrolment = _dbContext.Enrolments.FirstOrDefault(e => e.EnrolmentNum == en);
            if (Enrolment != null)
            {
                _dbContext.Enrolments.Remove(Enrolment);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteMarks(int id)
        {
            Marks Mark = _dbContext.Marks.FirstOrDefault(e => e.Id == id);
            if (Mark != null)
            {
                _dbContext.Marks.Remove(Mark);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteStaff(string id)
        {
            Staff Staff = _dbContext.Staff.FirstOrDefault(e => e.Id == id);
            if (Staff != null)
            {
                _dbContext.Staff.Remove(Staff);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteStudents(string id)
        {
            Students Student = _dbContext.Students.FirstOrDefault(e => e.Id == id);
            if (Student != null)
            {
                _dbContext.Students.Remove(Student);
                _dbContext.SaveChanges();
            }
        }


        public IEnumerable<Courses> GetAllCourses()
        {
            IEnumerable<Courses> AllCourses = _dbContext.Courses.ToList<Courses>();
            return AllCourses;
        }

        public IEnumerable<Enrolments> GetAllEnrolments()
        {
            IEnumerable<Enrolments> AllEnrolments = _dbContext.Enrolments.ToList<Enrolments>();
            return AllEnrolments;
        }

        public IEnumerable<Marks> GetAllMarks()
        {
            IEnumerable<Marks> AllMarks = _dbContext.Marks.ToList<Marks>();
            return AllMarks;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            IEnumerable<Staff> AllStaff = _dbContext.Staff.ToList<Staff>();
            return AllStaff;
        }

        public IEnumerable<Students> GetAllStudents()
        {
            IEnumerable<Students> AllStudents = _dbContext.Students.ToList<Students>();
            return AllStudents;
        }

        public Courses GetCoursesById(string code)
        {
            Courses Course = _dbContext.Courses.FirstOrDefault(e => e.Code == code);
            return Course;
        }


        public Enrolments GetEnrolmentsById(int en)
        {
            Enrolments Enrolment = _dbContext.Enrolments.FirstOrDefault(e => e.EnrolmentNum == en);
            return Enrolment;
        }

        public Marks GetMarksById(int id)
        {
            Marks Mark = _dbContext.Marks.FirstOrDefault(e => e.Id == id);
            return Mark;
        }

        public Staff GetStaffById(string id)
        {
            Staff Staff = _dbContext.Staff.FirstOrDefault(e => e.Id == id);
            return Staff;
        }

        public Students GetStudentssById(string id)
        {
            Students Student = _dbContext.Students.FirstOrDefault(e => e.Id == id);
            return Student;
        }
        
        public bool ValidLoginStaff(string id, string password)
        {
             Staff st = _dbContext.Staff.FirstOrDefault(e => e.Id == id && e.Password == password);

            if (st == null)
                return false;
            else
                return true;
        }
        public bool ValidLoginStudent(string id, string password)
        {
            Students s = _dbContext.Students.FirstOrDefault(e => e.Id == id && e.Password == password);
          
            if (s == null)
                return false;
            else
                return true;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
