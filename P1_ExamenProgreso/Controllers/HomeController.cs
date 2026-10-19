using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P1_ExamenProgreso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Programa acerca de los caballeros del zodiaco";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Cabelleros y armaduras";

            return View();
        }
    }
}