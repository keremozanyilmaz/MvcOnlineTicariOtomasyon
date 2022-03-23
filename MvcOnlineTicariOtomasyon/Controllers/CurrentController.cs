using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Currents.Where(x => x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCurrent(Current p)
        {
            p.Status = true;
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var cr = c.Currents.Find(id);
            cr.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var cr = c.Currents.Find(id);
            return View("GetCurrent",cr);
        }
        public ActionResult UpdateCurrent(Current p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var cr = c.Currents.Find(p.CurrentID);
            cr.CurrentName = p.CurrentName;
            cr.CurrentSurname = p.CurrentSurname;
            cr.CurrentCity = p.CurrentCity;
            cr.CurrentMail = p.CurrentMail;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentSale(int id)
        {
            var values = c.SalesMovements.Where(x => x.CurrentID == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(values);
        }
    }
}