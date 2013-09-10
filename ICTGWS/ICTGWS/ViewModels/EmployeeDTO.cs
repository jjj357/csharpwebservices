using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        //[Required(ErrorMessage = "Employee FullName is required")]
        //[MaxLength(100)]
        public string FullName { get; set; }

        //[Required(ErrorMessage = "Employee Telephone is required")]
        //[Range(33000, 33999)]
        public int Telephone { get; set; }

        //[Required(ErrorMessage = "Employee Email is required")]
        //[MaxLength(100)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Employee WebSite is required")]
        //[MaxLength(100)]
        public string WebSite { get; set; }

        //[MaxLength(50)]
        public string UserName { get; set; }

        public string Password { get; set; }

        //[MaxLength(100)]
        public string DisplayName { get; set; }
    }//end of public class


    // POST
    public class EmployeeAdd
    {
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

        [Required(ErrorMessage = "Employee UserName is required")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Employee DisplayName is required")]
        [MaxLength(100)]
        public string DisplayName { get; set; }
    }

    //PUT
    public class EmployeeUpdate
    {

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

        //public ICollection<Course> Courses { get; set; }
    }//end of public class 

    //
    public class EmployeeAll
    {

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        //[Required(ErrorMessage = "Employee FullName is required")]
        //[MaxLength(100)]
        public string FullName { get; set; }

        //[Required(ErrorMessage = "Employee Telephone is required")]
        //[Range(33000, 33999)]
        public int Telephone { get; set; }

        //[Required(ErrorMessage = "Employee Email is required")]
        //[MaxLength(100)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Employee WebSite is required")]
        //[MaxLength(100)]
        public string WebSite { get; set; }

        //[MaxLength(50)]
        public string UserName { get; set; }

        public string Password { get; set; }

        //[MaxLength(100)]
        public string DisplayName { get; set; }

        //public ICollection<Course> Courses { get; set; }
    }//end of public class 

    public class EmployeeForList
    {
        public int Id { get; set; }
        //public bool IsCurrent { get; set; }

        public string FullName { get; set; }

        public int Telephone { get; set; }

        public string Email { get; set; }

        //public string WebSite { get; set; }

        //public string UserName { get; set; }

        //public string Password { get; set; }

        //public string DisplayName { get; set; }
    }//end of public class
}
