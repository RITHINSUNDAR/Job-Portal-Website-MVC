using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Job_Portal_WebsiteEntities dbobj = new Job_Portal_WebsiteEntities();

        public ActionResult Page_Load()

        {

            
            return View();

        }
        public ActionResult Login_click(login clsob)
        {
            if (ModelState.IsValid)
            {
                var count = dbobj.sp_LoginCount(clsob.username, clsob.password).FirstOrDefault()??0;
               // var count = dbobj.sp_LoginIdCount("Admin","000");
                //int ct = Convert.ToInt32(count);
                var type = dbobj.sp_LoginType(clsob.username, clsob.password).FirstOrDefault();
                var uid=dbobj.sp_AdminId(clsob.username, clsob.password).FirstOrDefault();
                Session["uid"] = uid;
                //string typ = type.ToString();

                if (count == 1)
                {
                    if (type == "Admin")
                    {
                        return RedirectToAction("AdminHome");

                    }
                    else if (type == "User")
                    {
                        return RedirectToAction("Jobview_Pageload","Search");
                       // return RedirectToAction("UserHome");

                    }

                }
                else
                {
                    clsob.msg = "Invalid";
                    return View("Page_Load", clsob);
                   

                }

            }
           

            return View("Page_Load", clsob);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult UserHome( )
        {
           // ob.selectjob = dbobj.Job_Tab.ToList();
            return View(dbobj.Job_Tab.ToList());
        }
    }
}