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
    public class ProgramDTO
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Credential { get; set; }

        public int Semesters { get; set; }
    }//end of public class ProgramDTO

    public class ProgramWithSubjects
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Credential { get; set; }

        public int Semesters { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        //public ICollection<Student> Students { get; set; }
    }//end of public class

    public class ProgramWithStudents
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Credential { get; set; }

        public int Semesters { get; set; }

        //public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
    }//end of public class

    // POST
    public class ProgramAdd
    {
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
    }

    //PUT
    public class ProgramUpdate
    {
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

        //public ICollection<Subject> Subjects { get; set; }
        //public ICollection<Student> Students { get; set; }
    }//end of public class 

    //GET
    public class ProgramDTOAll
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Credential { get; set; }

        public int Semesters { get; set; }

        //public ICollection<Subject> Subjects { get; set; }
        //public ICollection<Student> Students { get; set; }
    }//end of public class 

    // GET - for a user interface list control
    public class ProgramForList
    {
        public int Id { get; set; }
        //public bool IsCurrent { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        //public string Description { get; set; }

        //public string Credential { get; set; }

        //public int Semesters { get; set; }
    }


}
