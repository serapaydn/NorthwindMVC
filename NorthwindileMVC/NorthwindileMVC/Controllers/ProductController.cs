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
    public class ProductController : Controller
    {
        NORTHWNDEntities3 db = new NORTHWNDEntities3();
        // GET: Product
        public ActionResult Index()
        {
            List<Products> urunler = db.Products.ToList();
            return View(urunler);         
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Products model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(model);
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
            Products p = db.Products.Find(id);
            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public ActionResult Edit(Products model)
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
            Products p = db.Products.Find(id);
            if (p == null)
            {
                return RedirectToAction("Index", "Product");
            }
            return View(p);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products p = db.Products.Find(id);
            if (p != null)
            {
                db.Products.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }
    }
}