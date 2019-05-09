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

        public AdminController()
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
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
           
            AdminViewModel mymodel = new AdminViewModel();
            mymodel.posts = DbLayer.getAllPosts();
            mymodel.users = DbLayer.getAllUsers();
            return View(mymodel);
            
        }

        // GET: Admin/Details/5
        //Allows admin to view User's information
            //user id in model should be string?
        public ActionResult Details(string id)
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
        //present the user modification information
        public ActionResult Edit(string userid)
        {
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!DbLayer.CheckIfUserExists(userid))
            {
                return HttpNotFound();
            }
            return View(DbLayer.getUser(userid));
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

                DbLayer.modifyUserStatus(user);
  
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Delete/5
        //Deleting the user from database
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (DbLayer.CheckIfUserExists(id))
            {
                User user = DbLayer.getUser(id);
                return View(user);
            } else
            {
                return HttpNotFound();
            }

       
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (DbLayer.CheckIfUserExists(id))
            {
                DbLayer.deleteUser(id);
                return RedirectToAction("index");
            }
            else
            {
                return HttpNotFound();
            }
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
