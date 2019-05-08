﻿using System;
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
    public class LocalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locales
        public ActionResult Index()
        {
            return View(db.Locales.ToList());
        }

        // GET: Locales/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locale locale = db.Locales.Find(id);
            if (locale == null)
            {
                return HttpNotFound();
            }
            return View(locale);
        }

        // GET: Locales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "localeID,name")] Locale locale)
        {
            if (ModelState.IsValid)
            {
                db.Locales.Add(locale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locale);
        }

        // GET: Locales/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locale locale = db.Locales.Find(id);
            if (locale == null)
            {
                return HttpNotFound();
            }
            return View(locale);
        }

        // POST: Locales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "localeID,name")] Locale locale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locale);
        }

        // GET: Locales/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locale locale = db.Locales.Find(id);
            if (locale == null)
            {
                return HttpNotFound();
            }
            return View(locale);
        }

        // POST: Locales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Locale locale = db.Locales.Find(id);
            db.Locales.Remove(locale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
