using DB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TASquared.Controllers
{
    public class HomeController : Controller {
        //private static ApplicationDbContext db = new ApplicationDbContext();
    
        public ActionResult Index()
        {
        // need to pass the area 
       
        return View(DbLayer.GetAllLocales());
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