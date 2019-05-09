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
    public class AreasController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
 

        // GET: Areas
        public ActionResult Index()
        {
            var areas = DbLayer.GetAllAreas();
            return View(areas);
        }

        

        // GET: Areas/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "areaID,name")] Area area)
        {
            if (ModelState.IsValid)
            {

                DbLayer.addArea(area);
                return RedirectToAction("Index");
            }

            return View(area);
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!DbLayer.CheckIfAreaExists(id))
            {
                return HttpNotFound();
            }

            Area area = DbLayer.getArea(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "areaID,name")] Area area)
        {
            if (ModelState.IsValid)
            {
                DbLayer.saveArea(area);
                return RedirectToAction("Index");
            }
            return View(area);
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Area area = DbLayer.getArea(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }



        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            DbLayer.deleteArea(id);
            //Area area = db.Areas.Find(id);
            //db.Areas.Remove(area);
            //db.SaveChanges();
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
        }
        */
    }
}
