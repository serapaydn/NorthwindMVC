using NorthwindileMVC.Fitreler;
using NorthwindileMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindileMVC.Controllers
{
    [GirisKontrol]
    public class SupplierController : Controller
    {
        
        NORTHWNDEntities3 db = new NORTHWNDEntities3();
        // GET: Supplier
        public ActionResult Index()
        {
            List<Suppliers> tedarikciler = db.Suppliers.ToList();
            return View(tedarikciler);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Suppliers model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Suppliers.Add(model);
                    db.SaveChanges();
                    ViewBag.message = "Ekleme Başarılı";
                    ViewBag.status = "1";
                }
                catch
                {
                    ViewBag.message = "Ekleme Başarısız";
                    ViewBag.status = "0";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Suppliers s = db.Suppliers.Find(id);
            if (s != null)
            {
                return View(s);
            }
            return RedirectToAction("Index", "Supplier");
        }
        [HttpPost]
        public ActionResult Edit(Suppliers model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.message = "Düzenleme Başarılı";
                    ViewBag.status = "1";

                }
                catch
                {
                    ViewBag.message = "Düzenleme Başarısız";
                    ViewBag.status = "0";
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Suppliers s = db.Suppliers.Find(id);
            if (s == null)
            {
                return RedirectToAction("Index", "Supplier");
            }
            return View(s);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers s = db.Suppliers.Find(id);
            if (s != null)
            {
                db.Suppliers.Remove(s);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Supplier");
        }

    }
}