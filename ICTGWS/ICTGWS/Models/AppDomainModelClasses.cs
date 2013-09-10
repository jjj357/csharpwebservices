using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.Models
{
            public class Login
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Timestamp is required")]
        public DateTime Timestamp { get; set; }

        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Token Expire Date is required")]
        public DateTime TokenExpires { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
     }// end of public class Login

            public class Semester
    {
            public Semester()
        {
            this.Courses = new List<Course>();
        }

        public int Id { get; set; }


        [Required(ErrorMessage = "Semester Name  is required")]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Semester Number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Semester String is required")]
        public string SemesterString { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        public ICollection<Course> Courses { get; set; }

     }//end of public class Semester


        public class Student
    {
            public Student()
        {
            this.Courses = new List<Course>();
          

            // Default values
            IsCurrent = true;
        }

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Display Name is required")]
        [MaxLength(20)]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Given Names is required")]
        [MaxLength(20)]
        public string GivenNames { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Student Id is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        public ICollection<Course> Courses { get; set; }
        public Program program { get; set; }
       }//end of public class Student
    

        public class GradedWork
    {
            public GradedWork()
        {
            // Default values
            IsCurrent = true;
        }

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "DateAssigned is required")]
        [MaxLength(20)]
        public DateTime DateAssigned { get; set; }

        [Required(ErrorMessage = "DateCreated is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "DateDue is required")]
        public DateTime DateDue { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "MoreInfoUrl is required")]
        public string MoreInfoUrl { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public double Value { get; set; }

        public Course course { get; set; }

    }//end of public class GradedWork
    

    public class Program
    {
        public Program()
        {
            this.Subjects = new List<Subject>();
            this.Students = new List<Student>();

            // Default values
            IsCurrent = true;
        }

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Program Code is required")]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Program Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Program Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Program Credential is required")]
        public string Credential { get; set; }

        [Required(ErrorMessage = "Program Semesters value is required")]
        [Range(2, 8)]
        public int Semesters { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
    }//end of public class Program

    public class Subject
    {
        public Subject()
        {
            this.Programs = new List<Program>();
            this.Courses = new List<Course>();
            // Default values
            IsCurrent = true;
        }

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Subject Code is required")]
        [MaxLength(6)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Subject Name is required")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Subject Description is required")]
        public string Description { get; set; }

        [MaxLength(200)] // Arbitrary limit
        [Required(ErrorMessage = "Subject Outline URL is required")]
        public string OutlineUrl { get; set; }

        public ICollection<Program> Programs { get; set; }
        public ICollection<Course> Courses { get; set; }
    }//end of public class Subject

    public class Employee
    {
        public Employee()
        {
            // Default values
            IsCurrent = true;
        }

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        [Required(ErrorMessage = "Employee FullName is required")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Employee Telephone is required")]
        [Range(33000, 33999)]
        public int Telephone { get; set; }

        [Required(ErrorMessage = "Employee Email is required")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee WebSite is required")]
        [MaxLength(100)]
        public string WebSite { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        public ICollection<Course> Courses { get; set; }
    }//end of public class Employee

        public class Course
    {
            public Course()
        {
            this.Students = new List<Student>();
            this.GradedWorks = new List<GradedWork>();


            // Default values
            IsOffered = true;

        }

        // private field 
        private string _section;


        public int Id { get; set; }


        [Required(ErrorMessage = "Day1  is required")]
        public string Day1 { get; set; }

        [Required(ErrorMessage = "Day2  is required")]
        public string Day2 { get; set; }

        [Required(ErrorMessage = "Duration1  is required")]
        public int Duration1 { get; set; }

        [Required(ErrorMessage = "Duration2  is required")]
        public int Duration2 { get; set; }

        [Required(ErrorMessage = "IsOffered is required")]
        public bool IsOffered { get; set; }

        [Required(ErrorMessage = "Room1  is required")]
        public string Room1 { get; set; }

        [Required(ErrorMessage = "Room2  is required")]
        public string Room2 { get; set; }


        [Required(ErrorMessage = "Section is required")]
        public string Section{ get; set; }

        [Required(ErrorMessage = "StartPeriod1 is required")]
        public int StartPeriod1 { get; set; }


        [Required(ErrorMessage = "StartPeriod2 is required")]
        public int StartPeriod2 { get; set; }



        public ICollection<Student> Students { get; set; }
        public ICollection<GradedWork> GradedWorks { get; set; }
        public Subject subject { get; set; }
        public Semester semester { get; set; }
        public Employee employee { get; set; }

     }// end of public class Course

}
