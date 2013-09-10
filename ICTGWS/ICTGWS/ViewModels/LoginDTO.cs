using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICTGWS.ViewModels
{
    public class LoginDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Timestamp is required")]
        public DateTime Timestamp { get; set; }

        //[Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }

        //[Required(ErrorMessage = "Token Expire Date is required")]
        public DateTime TokenExpires { get; set; }

        //[Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
    }

    //POST
    public class LoginAdd
    {

        [Required(ErrorMessage = "Timestamp is required")]
        public DateTime Timestamp { get; set; }

        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Token Expire Date is required")]
        public DateTime TokenExpires { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
    }
}