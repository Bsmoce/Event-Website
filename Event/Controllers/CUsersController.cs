using Event.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event.Controllers
{
    public class CUsersController : Controller
    {
        Model1 ev = new Model1();

        [Authorize(Roles = "A")]
        // GET: CUsers
        public ActionResult Index()
        {
            List<User> U = ev.Users.ToList();
            return View(U);
        }
        public ActionResult List_User(int id)
        {
            var model = ev.Tickets.Where(x => x.Users_ID == id);
            
            return PartialView(model);
        }
        public ActionResult Book_del(int id)
        {
            Ticket t = ev.Tickets.FirstOrDefault(x => x.Ticket_ID == id);
            ev.Tickets.Remove(t);
            ev.SaveChanges();
            return View();
        }
    }
}