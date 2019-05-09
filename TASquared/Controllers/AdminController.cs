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
//used User model
namespace TASquared.Controllers
{
    public class AdminController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
           
            LayoutViewModel mymodel = new LayoutViewModel();
            mymodel.areas = DbLayer.GetAllAreas();
            mymodel.categories = DbLayer.GetAllCategories();
            mymodel.subcategories = DbLayer.GetAllSubCategories();
            mymodel.locales = DbLayer.GetAllLocales();
            mymodel.posts = DbLayer.GetAllPosts();
            mymodel.users = DbLayer.getAllUsers();
            return View(mymodel);
            
        }

        // GET: Admin/Details/5
        //Allows admin to view User's information
            //user id in model should be string?
        public ActionResult Details(int id)
        {  
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            User user = DbLayer.getUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        /*
        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,userRole,phoneNumber,email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        */
        // GET: Admin/Edit/5

        //Admin should be able to modify a area, a locale, a category or subcategory 
        //overloaded Edit method?
        public ActionResult Edit(string area_id)
        {
            if (area_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!DbLayer.CheckIAreaExists(area_id))
            {
                return HttpNotFound();
            }
            return View(DbLayer.getArea(area_id));
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userRole,phoneNumber,email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
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
