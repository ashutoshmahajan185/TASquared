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
    //Create, Delete, List, Modify, SendMessage, ViewPost

    //annotate class to allow anonymous as well as users to access actions
    public class PostsController : Controller
    {
        public PostsController()
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

        //need to think how to do this for other permutations of (area,locale) and (cat,subcat)
        // GET: List Posts
        public ActionResult Index(string area_id, string category_id )
        {
            //handle errors and edgecases
            if (area_id == null || category_id == null)
            {
                return HttpNotFound();
            }
            else if(!DbLayer.CheckIfAreaExists(area_id) || !DbLayer.CheckIfCategoryExists(category_id))
            {
                return HttpNotFound();
            }

            return View(DbLayer.GetAllPosts(area_id, category_id));
        }

        //viewing a post
        // GET: Posts/Details/5
        public ActionResult Details(string area_id, string category_id, int? id)
        {
            //handle errors and edgecases
            if (area_id == null || category_id == null)
            {
                return HttpNotFound();
            }
            else if (!DbLayer.CheckIfAreaExists(area_id) || !DbLayer.CheckIfCategoryExists(category_id))
            {
                return HttpNotFound();
            }
            else if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (!DbLayer.CheckIfPostsExists(id))
            {
                return HttpNotFound();
            }

            int post_id = (int)id;
            return View(DbLayer.getPost(post_id));
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            //might need to handle edge cases

            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,postNumber,postTimestamp,postExpiration,ownerID,title,body,area,locale,category,subcategory,isDeletedOrHidden,canBeModified")] Post post)
        {
            if (ModelState.IsValid)
            {
                DbLayer.SavePost(post);
                return RedirectToAction("Index");
            }

            return View(post);
        }

        //only allowed for admin, need to annotate
        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (!DbLayer.CheckIfPostsExists((int)id))
            {
                return HttpNotFound();
            }
            return View(DbLayer.getPost((int)id));
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,postNumber,postTimestamp,postExpiration,ownerID,title,body,area,locale,category,subcategory,isDeletedOrHidden,canBeModified")] Post post)
        {
            if (ModelState.IsValid)
            {
                DbLayer.SavePost(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //only allowed for admin, need to annotate
        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!DbLayer.CheckIfPostsExists((int)id))
            {
                return HttpNotFound();
            }
            return View(DbLayer.getPost((int)id));
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DbLayer.deletePost(id);
            return RedirectToAction("Index");
        }
    }
}
