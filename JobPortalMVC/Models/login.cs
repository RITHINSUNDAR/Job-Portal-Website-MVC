using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class login
    {
       // [Required(ErrorMessage ="Enter your Username")]
        public string username { get; set; }
       // [Required(ErrorMessage = "Enter your Password")]
        public string password { get; set; }

        public string msg { get; set; }
    }
}