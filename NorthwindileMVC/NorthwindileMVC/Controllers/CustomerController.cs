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
    public class CustomerController : Controller
    {
        NORTHWNDEntities3 db = new NORTHWNDEntities3();
        // GET: Customer
        public ActionResult Index()
        {
            List<Customers> musteriler = db.Customers.ToList();
            return View(musteriler);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Customers.Add(model);
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
        public ActionResult Edit(string id)
        {
            Customers customer = db.Customers.Find(id);
            if (customer != null)
            {
                return View(customer);
            }
            return RedirectToAction("Index", "Customer");
        }
        [HttpPost]
        public ActionResult Edit(Customers model)
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
        public ActionResult Delete(string id)
        {
            Customers customer = db.Customers.Find(id);
            if (customer == null)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Customers customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}