using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class AdminInsert
    {
        public int Admin_Id { get; set; }
        public string Admin_Name { get; set; }
        public string Company_Name { get; set; }
        public string Company_Description { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string cpassword { get; set; }
        public string msg { get; set; }
    }
}