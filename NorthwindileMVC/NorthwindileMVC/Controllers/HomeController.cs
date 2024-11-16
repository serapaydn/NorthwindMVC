using NorthwindileMVC.Fitreler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindileMVC.Controllers
{
    public class HomeController : Controller
    {
        [GirisKontrol]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}