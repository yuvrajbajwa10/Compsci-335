using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz1.Models;

namespace Quiz1.Data
{
    public interface IQ1Repo
    {
        Marks UpdateMarks(Marks m);

        IEnumerable<Courses> GetAllCourses();
        IEnumerable<Enrolments> GetAllEnrolments();
        IEnumerable<Marks> GetAllMarks();
        IEnumerable<Staff> GetAllStaff();
        IEnumerable<Students> GetAllStudents();
        
        Courses GeCoursesById(string code);
        Enrolments GetEnrolmentsById(int id);
        Marks GetMarksById(int id);
        Staff GetStaffById(string id);
        Students GetStudentssById(string id);

        Courses AddCourses(Courses c);
        Enrolments AddEnrolments(Enrolments e);
        Marks AddMarks(Marks m);
        Staff AddStaff(Staff s);
        Students AddStudents(Students s);

        void DeleteCourses(string code);
        void DeleteEnrolments(int id);
        void DeleteMarks(int id);
        void DeleteStaff(string id);
        void DeleteStudents(string id);

        void SaveChanges();
        bool ValidLoginStaff(string id, string password);
        bool ValidLoginStudent(string id, string password);
    }
}
