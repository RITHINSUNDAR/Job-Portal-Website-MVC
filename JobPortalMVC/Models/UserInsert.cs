using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Quali
    {
        public string value { get; set; }
        public string text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class Skills
    {
        public string value { get; set; }
        public string text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserInsert
    {

        public List<Quali> favQuali { get; set; }
        public List<Skills> favSkill { get; set; }
        public string[] selectedqual { get; set; }
        public string[] selecetdskill { get; set; }

        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public System.DateTime User_Dob { get; set; }
        [Required(ErrorMessage ="enter your number")]
        public int Ph { get; set; }
        public int ExperianceInyear { get; set; }
        public string Skills { get; set; }
        public string Qualification { get; set; }
        public string Status { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string cpassword { get; set; }
        public string msg { get; set; }
    }
}