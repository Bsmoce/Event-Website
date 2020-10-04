using Event.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event.Controllers
{
    public class SignUpController : Controller
    {
        Model1 ev = new Model1();
        // GET: SignUp
        public ActionResult Index()
        {
            List<Login> L = ev.Logins.ToList();
            return View();
        }
        public ActionResult Add_Account()
        {
            ViewBag.Logins = ev.Logins.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Account(Login L)
        {
            ev.Logins.AddOrUpdate(L);
            ev.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}