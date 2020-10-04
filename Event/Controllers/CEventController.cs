using Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Net;
using System.Data.Entity;

namespace Event.Controllers
{
    public class CEventController : Controller
    {
        Model1 ev = new Model1();
        // GET: CEvent
        public ActionResult Index()
        {
            List<Event_Rez> Rez = ev.Event_Rez.ToList();
            return View(Rez);

        }
        [Authorize(Roles = "A")]
        public ActionResult Add()
        {
            ViewBag.Venues = ev.Venues.ToList();
            ViewBag.Categorys = ev.Categories.ToList();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult Add(Event_Rez e)
        {
            ev.Event_Rez.AddOrUpdate(e);
            ev.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Event_del(int id)
        {
            Event_Rez e = ev.Event_Rez.FirstOrDefault(x => x.Event_ID == id);
            ev.Event_Rez.Remove(e);
            ev.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Rez event_Rez = ev.Event_Rez.Find(id);
            if (event_Rez == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_ID = new SelectList(ev.Categories, "Cat_ID", "Cat_Name", event_Rez.Cat_ID);
            ViewBag.Venue_ID = new SelectList(ev.Venues, "Venue_ID", "Venue_Name", event_Rez.Venue_ID);
            return View(event_Rez);
        }

        [Authorize(Roles = "A")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Event_ID,Event_Name,Venue_ID,Cat_ID")] Event_Rez event_Rez)
        {
            if (ModelState.IsValid)
            {
                ev.Entry(event_Rez).State = EntityState.Modified;
                ev.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cat_ID = new SelectList(ev.Categories, "Cat_ID", "Cat_Name", event_Rez.Cat_ID);
            ViewBag.Venue_ID = new SelectList(ev.Venues, "Venue_ID", "Venue_Name", event_Rez.Venue_ID);
            return View(event_Rez);
        }
    }
}