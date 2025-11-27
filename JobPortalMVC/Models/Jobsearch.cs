using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVC.Models
{
    public class Jobsearch
    {
        public Jobsearch()
        {
            selectjob = new List<jobList>();
            //selectjob = new List<Job_Tab>();
            insertse = new jobList();
        }
        public jobList insertse { get; set; }
        public List<jobList> selectjob { get; set; }
       // public IEnumerable<Job_Tab> selectjob { get; set; }



    }
    public class jobList
    {
        public int Job_id { get; set; }
        public int Company_id { get; set; }
        public string Job_Title { get; set; }
        public string Job_description { get; set; }
        public string Job_Experiance { get; set; }
        public string Job_skills { get; set; }
        public string Job_Salary { get; set; }
        public System.DateTime Job_enddate { get; set; }
        public string Location { get; set; }
        public string Job_status { get; set; }
        public int Jobtype_Id { get; set; }
        public string Jobtype_name { get; set; }


    }
}