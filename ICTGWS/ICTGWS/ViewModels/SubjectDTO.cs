using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{

    public class SubjectDTO
    {

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string OutlineUrl { get; set; }
    }//end of public class 



    // POST
    public class SubjectAdd
    {
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
    }

    //PUT
    public class SubjectUpdate
    {

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

        //public ICollection<Program> Programs { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }//end of public class 

    
    public class SubjectAll
    {

        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string OutlineUrl { get; set; }

        //public ICollection<Program> Programs { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }//end of public class 

    public class SubjectForList
    {

        public int Id { get; set; }
        //public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        //public string Description { get; set; }

        //public string OutlineUrl { get; set; }
    }//end of public class 

}
