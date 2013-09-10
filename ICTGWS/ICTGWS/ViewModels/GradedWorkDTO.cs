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
    public class GradedWorkDTO
    {
        public int Id { get; set; }
        public bool IsCurrent { get; set; }

        //[Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        //[Required(ErrorMessage = "DateAssigned is required")]
        //[MaxLength(20)]
        public DateTime DateAssigned { get; set; }

        //[Required(ErrorMessage = "DateCreated is required")]
        public DateTime DateCreated { get; set; }

        //[Required(ErrorMessage = "DateDue is required")]
        public DateTime DateDue { get; set; }

        //[Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        //[Required(ErrorMessage = "MoreInfoUrl is required")]
        public string MoreInfoUrl { get; set; }

        //[Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "Value is required")]
        public double Value { get; set; }

        //public Course course { get; set; }
        public int CourseId { get; set; }

    }//end of class



    //Post
    public class GradedWorkAdd
    {
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

        //public Course course { get; set; }
        public int CourseId { get; set; }

    }//end of class

    //put
    public class GradedWorkUpdate
    {
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

        //public Course course { get; set; }
        public int CourseId { get; set; }

    }//end of class

    public class GradedWorkForList
    {
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "DateAssigned is required")]
        [MaxLength(20)]
        public DateTime DateAssigned { get; set; }

        [Required(ErrorMessage = "DateDue is required")]
        public DateTime DateDue { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public double Value { get; set; }

    }//end of class

}