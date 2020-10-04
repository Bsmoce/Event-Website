using Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event.Controllers
{
    public class CDatesController : Controller
    {
        Model1 ev = new Model1();
        // GET: CDates
        public ActionResult Index()
        {
            List<Booking> B = ev.Bookings.ToList();
            return View(B);
        }
    }
}