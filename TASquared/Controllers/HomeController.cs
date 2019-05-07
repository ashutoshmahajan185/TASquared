using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB.Database;
using Data.Models;

namespace TASquared.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            var areas = DbLayer.GetAllAreas();
            var locales = DbLayer.GetAllLocales();
            var cat = DbLayer.GetAllCategories();
            var subcat = DbLayer.GetAllSubCategories();

            var layoutViewModel = new LayoutViewModel
            {
                areas = areas,
                locales = locales,
                categories = cat,
                subcategories = subcat
            };

            ViewBag.layoutViewModel = layoutViewModel;

        }
        public ActionResult Index()
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