using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U5_W1_D2.Models;

namespace U5_W1_D2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Dipendenti> dipendenti = _context.Dipendenti.ToList();
            return View(dipendenti);
        }

        public ActionResult CreaDipendente()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}