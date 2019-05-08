using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB.Database;
using Data.Models;

namespace TASquared.Controllers
{
    public class SubcategoriesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subcategories
        public ActionResult Index()
        {
            var subcats = DbLayer.GetAllSubCategories();
            return View(subcats);
        }
        /*
        // GET: Subcategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = db.SubCategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }*/

        // GET: Subcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subCategoryID,name")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {

                DbLayer.addSubcategory(subcategory);
                return RedirectToAction("Index");
            }



            return View(subcategory);
        }

        // GET: Subcategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!DbLayer.CheckIfLocaleExists(id))
            {
                return HttpNotFound();
            }

            Subcategory sub = DbLayer.getSubcategory(id);
            if (sub == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subCategoryID,name")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                DbLayer.saveSubcategory(subcategory);
                return RedirectToAction("Index");
            }
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subcategory sub = DbLayer.getSubcategory(id);
            if (sub == null)
            {
                return HttpNotFound();
            }
            return View(sub);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DbLayer.deleteSubcategory(id);
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
