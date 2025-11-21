using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserReg
        Job_Portal_WebsiteEntities dbobj = new Job_Portal_WebsiteEntities();

        public ActionResult Page_Load()
        {

            UserInsert us = new UserInsert();
            us.favQuali = getQualificationData();
            us.favSkill = getSkillData();
            return View(us);

        }
        public List<Quali> getQualificationData()
        {
            List<Quali> qul = new List<Quali>()
            {
                new Quali{value="SSLC",text="SSLC",IsChecked=true},
              new Quali{value="Plus Two",text="Plus Two",IsChecked=false},
              new Quali{value="BTECH",text="BTECH",IsChecked=false},
              new Quali{value="BCA",text="BCA",IsChecked=false},
              new Quali{value="MCA",text="MCA",IsChecked=false},
            };
            return qul;
        }
        public List<Skills> getSkillData()
        {
            List<Skills> sk = new List<Skills>()
            {
                new Skills{value="Python",text="Python",IsChecked=true},
              new Skills{value="Java",text="Java",IsChecked=false},
              new Skills{value="C#",text="C#",IsChecked=false},
              new Skills{value="MVC",text="MVC",IsChecked=false},
              new Skills{value=".Net",text=".NET",IsChecked=false},
            };
            return sk;
        }
        public ActionResult Insert_Click(UserInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var quid = string.Join(",", clsobj.selectedqual);
                clsobj.Qualification = quid;
                clsobj.favQuali = getQualificationData();

                var sid = string.Join(",", clsobj.selecetdskill);
                clsobj.Skills = sid;
                clsobj.favSkill = getSkillData();
                var count = dbobj.sp_regCount().FirstOrDefault();
                //var regid=dbobj.sp_LoginCount(clsobj.username, clsobj.password).FirstOrDefault();
                int RegId = 0;
                int id = Convert.ToInt32(count);

                if (id == 0)
                {
                    RegId = 1;
                }
                else
                {
                    RegId = id+ 1;
                }
                dbobj.sp_UserReg(RegId, clsobj.username, clsobj.User_Email, clsobj.User_Dob, clsobj.Ph, clsobj.ExperianceInyear, clsobj.Skills, clsobj.Qualification, "Active");
                dbobj.sp_LoginInsert(RegId, clsobj.username, clsobj.cpassword, "User");
                clsobj.msg = "successfully inserted";
                return View("Page_Load", clsobj);


            }
            else
            {
                clsobj.favQuali = getQualificationData();
                clsobj.favSkill = getSkillData();
                return View("Page_Load", clsobj);
            }
            return View("Page_Load", clsobj);

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}