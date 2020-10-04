using Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_Event(String E)
        {
            var Ev = new Event_Rez();
            Ev.Event_Name = E;
            return View();
        }
    }
}