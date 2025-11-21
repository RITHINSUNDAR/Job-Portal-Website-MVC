using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class JobInsertController : Controller
    {
        Job_Portal_WebsiteEntities dbobj = new Job_Portal_WebsiteEntities();
        // GET: JobInsert
        public ActionResult Page_Load()
        {
            return View();
        }

        public ActionResult Insert_Click(Job clsobj)
        {
            if (ModelState.IsValid)
            {
                int adminid = Convert.ToInt32(Session["uid"]);
                dbobj.sp_JobInsert(adminid, clsobj.Title, clsobj.Description, clsobj.Experiance, clsobj.Skills, clsobj.Location, clsobj.Job_Status, clsobj.Start_Date, clsobj.End_Date);
                clsobj.msg = "insert successfully";
                return View("Page_Load", clsobj);
            }
            return View("Page_Load", clsobj);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}