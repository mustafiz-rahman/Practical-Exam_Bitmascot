using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical_Exam_Bitmascot.Models;
using Practical_Exam_Bitmascot.Helper;

namespace Practical_Exam_Bitmascot.Controllers
{
    public class HomeController : Controller
    {
        Practical_Exam_BitmascotEntities obj = new Practical_Exam_BitmascotEntities();
        // GET: Account
        public ActionResult Index()
        {
            LoginModel loginmodel =new LoginModel();
            return View(loginmodel);
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginmodel)
        {
            string pass = Encrypt.EncryptPassword(loginmodel.Password);


                var usr = obj.signUpInfoes.Where(u => u.Email == loginmodel.Email && u.Password ==pass  ).FirstOrDefault();
                if (usr != null)
                {
                    
                    Session["Email"] = loginmodel.Email.ToString();
                TempData["Loginmsg"] = " Login Successfully ";
                return RedirectToAction("LoggeIn");

                }
                else
                {
                TempData["loginmsg"] = " Wrong Email or Password ";
            }
            
            return View();
        }
        
        public ActionResult LoggeIn()
        {
            UserProfileModel userProfileModel = new UserProfileModel();
            if(Session["Email"]==null)
            {
               return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return View(userProfileModel);
            }
         
        }
        [HttpGet]
        public ActionResult LoggeIn(UserProfileModel userProfileModel)
        {
            string emaillll = Session["Email"].ToString();
            var user = obj.signUpInfoes.Where(u => u.Email == emaillll).FirstOrDefault();
            if (user != null)
            {
                userProfileModel.FirstName = user.FirstName;
                userProfileModel.LastName = user.LastName;
                userProfileModel.Address = user.Address;
                userProfileModel.Phone = user.Phone;
                userProfileModel.Email = user.Email;
                userProfileModel.Dob = user.Dob;

            }
            return View(userProfileModel);

        }
        public ActionResult ChangePassword()
        {
            ChangePassworModel changePassword = new ChangePassworModel();
            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View(changePassword);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassworModel changePasswordModel)
        {
            signUpInfo objinfo = new signUpInfo();

            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string email = Session["Email"].ToString();
                string pass = Encrypt.EncryptPassword(changePasswordModel.OldPassword);
                var usr = obj.signUpInfoes.Where(u => u.Email == email && u.Password == pass).FirstOrDefault();
                if (usr!=null)
                {
                    if(ModelState.IsValid)
                    {
                        string newpass = Encrypt.EncryptPassword(changePasswordModel.ConfrmNewPassword);
                        usr.Password =newpass;
                        
                        
                        //obj.signUpInfoes.Add(objinfo);

                        obj.SaveChanges();
                        TempData["ChangePassword"] = " Password Changed Successfully ";
                    }

                }
                else { TempData["ChangePassword"] = " Old Password Does Not Match "; }
                return View();
            }
            

        }
        public ActionResult Logout()
        {
            Session["Email"] = null;
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
        
        

        public ActionResult Register()
        {
            UserModel userModel = new UserModel();
            
            return View(userModel);
        }

        [HttpPost]
        public JsonResult EmailExists(string email)
        {
            UserModel mod = new UserModel();

            return Json(!obj.signUpInfoes.Any(u => u.Email == email), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
           // PasswordStorage passwordStorage = new PasswordStorage();
            signUpInfo objinfo = new signUpInfo();
            if (ModelState.IsValid)
             {
                    objinfo.FirstName = userModel.FirstName;
                    objinfo.LastName = userModel.LastName;
                    objinfo.Address = userModel.Address;
                    objinfo.Phone = userModel.Phone;
                    objinfo.Email = userModel.Email;
                    objinfo.Dob = userModel.DateOfBirth;
                objinfo.Password = Encrypt.EncryptPassword(userModel.Password);



                obj.signUpInfoes.Add(objinfo);
                    obj.SaveChanges();



                TempData["testmsg"] = " Registered Successfully ";
                RedirectToAction("Index", "Home");
                return View(userModel);
            }
            else { TempData["testmsg"] = " Requested Not Valid "; }

            return View();
            
        }
        

    }
}