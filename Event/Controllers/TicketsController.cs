using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Event.Models;
using System.Data.Entity.Migrations;

namespace Event.Controllers
{
    public class TicketsController : Controller
    {
        Model1 ev = new Model1();

        [AllowAnonymous]

        // GET: Tickets
        public ActionResult Index(int? id)
        {
            var model = ev.Event_Rez.FirstOrDefault(x => x.Event_ID == id);
            return View("Index", model);
        }
        public ActionResult AddtoCart(Ticket id)
        {
            ev.Tickets.Add(id);
            ev.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CreateDocument(int? id)
        {
            string N = Convert.ToString(id);

            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();

                PdfGraphics graphics = page.Graphics;

                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //PdfImage image = PdfImage.FromFile(Server.MapPath("~/Content2/eee.jpg"));
                //RectangleF bounds = new RectangleF(176, 0, 390, 130);

                graphics.DrawString("Welcome To The Conference your Ticket Number is:" + N , font, PdfBrushes.Black, new PointF(0, 0));
                //page.Graphics.DrawImage(image, bounds);

                document.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);
            }
            return View();
        }

    }
}