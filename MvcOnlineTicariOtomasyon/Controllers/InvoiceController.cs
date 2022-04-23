using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Invoices.ToList(); 
            return View(list);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice I)
        {
            c.Invoices.Add(I);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetInvoice(int id)
        {
            var invoice = c.Invoices.Find(id);
            return View("GetInvoice", invoice);
        }
        public ActionResult UpdateInvoice(Invoice I)
        {
            var invoice = c.Invoices.Find(I.InvoiceID);
            invoice.InvoiceSerialNumber = I.InvoiceSerialNumber;
            invoice.InvoiceQueueNumber = I.InvoiceQueueNumber;
            invoice.InvoiceDate = I.InvoiceDate;
            invoice.InvoiceHour = I.InvoiceHour;
            invoice.InvoiceTaxAdministration = I.InvoiceTaxAdministration;
            invoice.InvoiceDeliveryPerson = I.InvoiceDeliveryPerson;
            invoice.InvoiceReciever = I.InvoiceReciever;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetails(int id)
        {
            var values = c.InvoiceItems.Where(x => x.InvoiceID == id).ToList();
            var inv = c.Invoices.Where(x => x.InvoiceID == id).Select(y => y.InvoiceSerialNumber).FirstOrDefault();
            ViewBag.i = inv;
            return View(values);
        }

        [HttpGet]
        public ActionResult NewItemtoInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewItemtoInvoice(InvoiceItem i)
        {
            c.InvoiceItems.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}