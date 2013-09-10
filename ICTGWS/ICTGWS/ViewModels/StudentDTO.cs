using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{
    public class StudentDTO
    {
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

            //public ICollection<Course> Courses { get; set; }
            
            //public Program program { get; set; }
            public int ProgramId { get; set; }
        }//end of public class 

    //POST
    public class StudentAdd
    {
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

        //public ICollection<Course> Courses { get; set; }

        //public Program program { get; set; }
        //public int ProgramId { get; set; }
    }//end of public class 

    //PUT
    public class StudentUpdate
    {

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

        //public ICollection<Course> Courses { get; set; }
        //public Program program { get; set; }
    }//end of public class 

    public class StudentAll
    {

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        //[Required(ErrorMessage = "Display Name is required")]
        //[MaxLength(20)]
        public string DisplayName { get; set; }

        //[Required(ErrorMessage = "Given Names is required")]
        //[MaxLength(20)]
        public string GivenNames { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Student Id is required")]
        public int StudentId { get; set; }

        //[Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        //public ICollection<Course> Courses { get; set; }
        //public Program program { get; set; }
    }//end of public class 

    public class StudentForList
    {

        //[Required(ErrorMessage = "Display Name is required")]
        //[MaxLength(20)]
        public string DisplayName { get; set; }

        //[Required(ErrorMessage = "Student Id is required")]
        public int StudentId { get; set; }

        //[Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

    }//end of public class 

    
}