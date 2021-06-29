using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using twitterapp.Models;
using System.Web.Security;

namespace twitterapp.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user user)
        {
            if(ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(user);
            }
            
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user user)
        {
            using(var u= new Model1())
            {
                user a = new user();
                bool isValid = u.users.Any(x => x.Email == user.Email && x.password == user.password);
                a= u.users.SingleOrDefault(x => x.Email == user.Email);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    Session["user"] = a.Email;
                    Session["userId"] = a.Id;
                    Session["name"] = a.Name;

                    return RedirectToAction("Index", "posts");
                }
                else 
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                    return View(user);
                }
                
            }
            

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}