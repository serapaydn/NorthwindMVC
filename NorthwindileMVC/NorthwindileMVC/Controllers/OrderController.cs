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
    public class OrderController : Controller
    {
        NORTHWNDEntities3 db = new NORTHWNDEntities3();
        // GET: Order
        public ActionResult Index()
        {
            List<Orders> satislar = db.Orders.ToList();
            return View(satislar);
        }
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Orders model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Orders.Add(model);
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
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", model.EmployeeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", model.CustomerID);

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Orders o = db.Orders.Find(id);
            if (o != null)
            {
                ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", o.EmployeeID);
                ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", o.CustomerID);
                return View(o);
            }
            return RedirectToAction("Index", "Order");
        }
        [HttpPost]
        public ActionResult Edit(Orders model)
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


            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", model.EmployeeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", model.CustomerID);

            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Orders o = db.Orders.Find(id);
            if (o == null)
            {
                return RedirectToAction("Index", "Order");
            }
            return View(o);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders o = db.Orders.Find(id);
            if (o != null)
            {
                db.Orders.Remove(o);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Order");
        }
    }
}