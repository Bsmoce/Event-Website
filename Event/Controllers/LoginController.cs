using Event.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Event.Controllers
{
    public class LoginController : Controller
    {
        Model1 ev = new Model1();
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Login L)
        {
            Login Useri = ev.Logins.FirstOrDefault(x => x.User_names == L.User_names && x.User_Password == L.User_Password);
            if (Useri != null)
            {
                FormsAuthentication.SetAuthCookie(Useri.User_names, false); 
                return RedirectToAction("Index", "Home", Useri);
            }
            else
            {
                ViewBag.mesaj = "Failed";
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}