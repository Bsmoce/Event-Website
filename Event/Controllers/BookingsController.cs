using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Event.Models;

namespace Event.Controllers
{
    public class BookingsController : Controller
    {
        private Model1 db = new Model1();

        [Authorize(Roles = "A,C")]

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Event_Rez).Include(b => b.Ticket);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.Event_ID = new SelectList(db.Event_Rez, "Event_ID", "Event_Name");
            ViewBag.Ticket_ID = new SelectList(db.Tickets, "Ticket_ID", "Ticket_ID");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_ID,Ticket_ID,Event_ID,Start_dates,End_dates")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Event_ID = new SelectList(db.Event_Rez, "Event_ID", "Event_Name", booking.Event_ID);
            ViewBag.Ticket_ID = new SelectList(db.Tickets, "Ticket_ID", "Ticket_ID", booking.Ticket_ID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Event_ID = new SelectList(db.Event_Rez, "Event_ID", "Event_Name", booking.Event_ID);
            ViewBag.Ticket_ID = new SelectList(db.Tickets, "Ticket_ID", "Ticket_ID", booking.Ticket_ID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_ID,Ticket_ID,Event_ID,Start_dates,End_dates")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Event_ID = new SelectList(db.Event_Rez, "Event_ID", "Event_Name", booking.Event_ID);
            ViewBag.Ticket_ID = new SelectList(db.Tickets, "Ticket_ID", "Ticket_ID", booking.Ticket_ID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
