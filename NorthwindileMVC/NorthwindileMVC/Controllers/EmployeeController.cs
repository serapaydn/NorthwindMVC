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
    public class EmployeeController : Controller
    {
        NORTHWNDEntities3 db = new NORTHWNDEntities3();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> calısanlar = db.Employees.ToList();
            return View(calısanlar);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employees model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Employees.Add(model);
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
            Employees e = db.Employees.Find(id);
            if (e != null)
            {
                return View(e);
            }
            return RedirectToAction("Index", "Employee");
        }
        [HttpPost]
        public ActionResult Edit(Employees model)
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
            Employees e = db.Employees.Find(id);
            if (e == null)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View(e);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees e = db.Employees.Find(id);
            if (e != null)
            {
                db.Employees.Remove(e);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Employee");
        }
    }
}