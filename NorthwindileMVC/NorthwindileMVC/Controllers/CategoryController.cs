﻿using NorthwindileMVC.Fitreler;
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
    public class CategoryController : Controller
    {
        
        NORTHWNDEntities3 db = new NORTHWNDEntities3();
        // GET: Category
        
        public ActionResult Index()
        {
            List<Categories> kategoriler = db.Categories.ToList();
            return View(kategoriler);
        }
        [HttpGet ]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Categories.Add(model);
                    db.SaveChanges();
                    ViewBag.message = "Ekleme Başarılı";
                    ViewBag.status ="1";

                }
                catch
                {
                    ViewBag.message = "Ekleme Başarısız";
                    ViewBag.status ="0";
                }
                
            }
            return View();
        }
        [HttpGet ]
        public ActionResult Edit(int id)
        {
            Categories c = db.Categories.Find(id);
            if (c != null)
            {
                return View(c);
            }
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        public ActionResult Edit(Categories model)
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
            Categories c = db.Categories.Find(id);
            if (c == null)
            {
                return RedirectToAction("Index", "Category");
            }
            return View(c);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories c = db.Categories.Find(id);
            if (c != null)
            {
                db.Categories.Remove(c);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
        }

    }
}