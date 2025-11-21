using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Job
    {
        public int Job_Id { get; set; }
        public int Admin_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Experiance { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public string Job_Status { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string msg { get; set; }
    }
}