using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class AdminRegController : Controller
    {
        Job_Portal_WebsiteEntities dbobj = new Job_Portal_WebsiteEntities();
        // GET: AdminReg

        public ActionResult Page_Load()
        {
            return View();
        }

        public ActionResult Insert_Click(AdminInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var count = dbobj.sp_regCount().FirstOrDefault();
                int RegId = 0;
                int id = Convert.ToInt32(count);
                if (id == 0)
                {
                    RegId = 1;
                }
                else
                {
                    RegId = id + 1;
                }
                dbobj.sp_AdminReg(RegId, clsobj.Admin_Name, clsobj.Company_Name, clsobj.Company_Description);
                dbobj.sp_LoginInsert(RegId, clsobj.username, clsobj.cpassword, "Admin");
                clsobj.msg = "inserted successfully";

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