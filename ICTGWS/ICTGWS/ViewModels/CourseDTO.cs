using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ICTGWS.Models;

namespace ICTGWS.ViewModels
{
    // GET - full item details
    public class CourseDTO
    {

        public int Id { get; set; }

        //[Required(ErrorMessage = "Day1  is required")]
        public string Day1 { get; set; }

        //[Required(ErrorMessage = "Day2  is required")]
        public string Day2 { get; set; }

        //[Required(ErrorMessage = "Duration1  is required")]
        public int Duration1 { get; set; }

        //[Required(ErrorMessage = "Duration2  is required")]
        public int Duration2 { get; set; }

        //[Required(ErrorMessage = "IsOffered is required")]
        public bool IsOffered { get; set; }

        //[Required(ErrorMessage = "Room1  is required")]
        public string Room1 { get; set; }

        //[Required(ErrorMessage = "Room2  is required")]
        public string Room2 { get; set; }

        //[Required(ErrorMessage = "Section is required")]
        public string Section { get; set; }

        //[Required(ErrorMessage = "StartPeriod1 is required")]
        public int StartPeriod1 { get; set; }

        //[Required(ErrorMessage = "StartPeriod2 is required")]
        public int StartPeriod2 { get; set; }

        //public ICollection<Student> Students { get; set; }
        //public ICollection<GradedWork> GradedWorks { get; set; }
        //public Subject subject { get; set; }
        //public int SubjectId { get; set; }
        //public Semester semester { get; set; }
        //public int SemesterId { get; set; }
        //public Employee employee { get; set; }
        //public int EmployeeId { get; set; }

    }// end of public class

    //POST
    public class CourseAdd
    {

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
        public string Section { get; set; }

        [Required(ErrorMessage = "StartPeriod1 is required")]
        public int StartPeriod1 { get; set; }

        [Required(ErrorMessage = "StartPeriod2 is required")]
        public int StartPeriod2 { get; set; }

        //public ICollection<Student> Students { get; set; }
        //public ICollection<GradedWork> GradedWorks { get; set; }
        //public Subject subject { get; set; }
        //public int SubjectId { get; set; }
        //public Semester semester { get; set; }
        //public int SemesterId { get; set; }
        //public Employee employee { get; set; }
        //public int EmployeeId { get; set; }

    }// end of public class

    //PUT
    public class CourseUpdate
    {

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
        public string Section { get; set; }

        [Required(ErrorMessage = "StartPeriod1 is required")]
        public int StartPeriod1 { get; set; }

        [Required(ErrorMessage = "StartPeriod2 is required")]
        public int StartPeriod2 { get; set; }

        //public ICollection<Student> Students { get; set; }
        //public ICollection<GradedWork> GradedWorks { get; set; }
        //public Subject subject { get; set; }
        //public int SubjectId { get; set; }
        //public Semester semester { get; set; }
        //public int SemesterId { get; set; }
        //public Employee employee { get; set; }
        //public int EmployeeId { get; set; }

    }// end of public class

    // GET - for a user interface list control
    public class CourseForTimeList
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Day1  is required")]
        public string Day1 { get; set; }

        //[Required(ErrorMessage = "Day2  is required")]
        public string Day2 { get; set; }

        //[Required(ErrorMessage = "Duration1  is required")]
        public int Duration1 { get; set; }

        //[Required(ErrorMessage = "Duration2  is required")]
        public int Duration2 { get; set; }

        //[Required(ErrorMessage = "IsOffered is required")]
        //public bool IsOffered { get; set; }

        //[Required(ErrorMessage = "Room1  is required")]
        //public string Room1 { get; set; }

        //[Required(ErrorMessage = "Room2  is required")]
        //public string Room2 { get; set; }

        //[Required(ErrorMessage = "Section is required")]
        public string Section { get; set; }

        //[Required(ErrorMessage = "StartPeriod1 is required")]
        public int StartPeriod1 { get; set; }

        //[Required(ErrorMessage = "StartPeriod2 is required")]
        public int StartPeriod2 { get; set; }
    }

    // GET - for a user interface list control
    public class CourseForLocationList
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Day1  is required")]
        public string Day1 { get; set; }

        //[Required(ErrorMessage = "Day2  is required")]
        public string Day2 { get; set; }

        //[Required(ErrorMessage = "Duration1  is required")]
        //public int Duration1 { get; set; }

        //[Required(ErrorMessage = "Duration2  is required")]
        //public int Duration2 { get; set; }

        //[Required(ErrorMessage = "IsOffered is required")]
        //public bool IsOffered { get; set; }

        //[Required(ErrorMessage = "Room1  is required")]
        public string Room1 { get; set; }

        //[Required(ErrorMessage = "Room2  is required")]
        public string Room2 { get; set; }

        //[Required(ErrorMessage = "Section is required")]
        public string Section { get; set; }

        //[Required(ErrorMessage = "StartPeriod1 is required")]
        //public int StartPeriod1 { get; set; }

        //[Required(ErrorMessage = "StartPeriod2 is required")]
        //public int StartPeriod2 { get; set; }
    }
}