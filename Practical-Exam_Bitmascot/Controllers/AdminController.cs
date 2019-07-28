using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical_Exam_Bitmascot.Models;

namespace Practical_Exam_Bitmascot.Controllers
{
    public class AdminController : Controller
    {
        Practical_Exam_BitmascotEntities obj = new Practical_Exam_BitmascotEntities();
        // GET: Admin
        public ActionResult Index(string search)
        {
            if(Session["Email"]!=null)
            {
                return View(obj.signUpInfoes.Where(x => x.FirstName.Contains(search) || search == null).ToList());

            }
            else { return RedirectToAction("Index", "Home"); }
            

        }
    }
}