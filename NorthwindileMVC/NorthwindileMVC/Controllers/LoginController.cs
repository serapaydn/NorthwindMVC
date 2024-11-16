using NorthwindileMVC.Models;
using NorthwindileMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindileMVC.Controllers
{
    public class LoginController : Controller
    {
        NORTHWNDEntities3 db = new NORTHWNDEntities3();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employees employee = db.Employees.FirstOrDefault(e => e.Username == model.UserName
                && e.Password == model.Password);
                if (employee != null)
                {
                    Session["employee"] = employee;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.error = "Kullanıcı bulunamadı";
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["employee"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}