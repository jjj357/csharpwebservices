using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{
    public class SemesterDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Semester Name  is required")]
        public string SemesterName { get; set; }

        //[Required(ErrorMessage = "Semester Number is required")]
        public int SemesterNumber { get; set; }

        //[Required(ErrorMessage = "Semester String is required")]
        public string SemesterString { get; set; }

        //[Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        //public ICollection<Course> Courses { get; set; }
    }

    //POST
    public class SemesterAdd
    {
        [Required(ErrorMessage = "Semester Name  is required")]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Semester Number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Semester String is required")]
        public string SemesterString { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        //public ICollection<Course> Courses { get; set; }
    }

    //PUT
    public class SemesterUpdate
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Semester Name  is required")]
        public string SemesterName { get; set; }

        [Required(ErrorMessage = "Semester Number is required")]
        public int SemesterNumber { get; set; }

        [Required(ErrorMessage = "Semester String is required")]
        public string SemesterString { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        //public ICollection<Course> Courses { get; set; }

    }//end of public class

    public class SemesterDTOAll
    {

        public int Id { get; set; }


        //[Required(ErrorMessage = "Semester Name  is required")]
        public string SemesterName { get; set; }

        //[Required(ErrorMessage = "Semester Number is required")]
        public int SemesterNumber { get; set; }

        //[Required(ErrorMessage = "Semester String is required")]
        public string SemesterString { get; set; }

        //[Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        //public ICollection<Course> Courses { get; set; }

    }//end of public class


    public class SemesterForList
    {
        //[Required(ErrorMessage = "Semester Name  is required")]
        public string SemesterName { get; set; }

        //[Required(ErrorMessage = "Semester Number is required")]
        public int SemesterNumber { get; set; }

        //[Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

    }//end of public class
}