using Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace Event.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Model1 ev = new Model1();
        public Login L_id;
        // GET: CEvent
        public ActionResult Index(Login id)
        {
            List<Booking> Rez = ev.Bookings.ToList();
            L_id = id;
            return View(Rez);
        }
        public ActionResult My_pro(Login L_id)
        {
            Rating R = ev.Ratings.FirstOrDefault(x => x.Login_ID == L_id.Login_ID);
            return View(R);
        }
    }
}