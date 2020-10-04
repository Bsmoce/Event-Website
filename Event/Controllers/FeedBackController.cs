using Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event.Controllers
{
    public class FeedBackController : Controller
    {
        Model1 ev = new Model1();

        // GET: FeedBack
        public ActionResult Index()
        {
            List<Event_Rez> Rez = ev.Event_Rez.ToList();
            return View(Rez);
        }
    }
}