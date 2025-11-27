using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class SearchController : Controller
    {
        Job_Portal_WebsiteEntities dbobj = new Job_Portal_WebsiteEntities();

        // GET: Search
        public ActionResult Jobview_Pageload()
        {
            Jobsearch js = new Jobsearch();
            js.selectjob = dbobj.Job_Tab.Select(x=> new jobList { 
            Job_Title=x.Title,
            Location=x.Location,
            Company_id=x.Admin_Id,
            Job_description=x.Description,
            Job_skills=x.Skills,
            Job_Experiance=x.Experiance,
            Job_status=x.Job_Status}). ToList();
          
            return View(js);
        }
        public ActionResult searchJob_click(Jobsearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_Experiance))
            {
                qry += "and Experiance Like '%" + clsobj.insertse.Job_Experiance + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Job_skills))
            {
                qry += "and Skills Like '%" + clsobj.insertse.Job_skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Location))
            {
                qry += "and Location Like '%" + clsobj.insertse.Location + "%'";
            }
            return View("Jobview_Pageload", getdata(clsobj, qry));

        }
        private Jobsearch getdata(Jobsearch clsobj, string qry)
        {
            using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["JobPortalDB"].ConnectionString))
           
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new Jobsearch();
                while (dr.Read())
                {
                    var jobcls = new jobList();
                    jobcls.Job_id = Convert.ToInt32(dr["Job_id"].ToString());
                    jobcls.Company_id = Convert.ToInt32(dr["Admin_id"].ToString());

                    jobcls.Job_Title =dr["Title"].ToString();
                    jobcls.Job_description = dr["Description"].ToString();
                    jobcls.Job_Experiance = dr["Experiance"].ToString();
                    jobcls.Job_skills = dr["Skills"].ToString();
                    jobcls.Location = dr["Location"].ToString();
                    jobcls.Job_status = dr["Job_Status"].ToString();

                    joblist.selectjob.Add(jobcls);




                }
                con.Close();
                return joblist;
            }

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}