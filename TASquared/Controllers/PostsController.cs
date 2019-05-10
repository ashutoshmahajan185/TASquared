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
        public ActionResult Index(string area_id, string category_id, string Place, string Type)
        {
            //handle errors and edgecases

            if (area_id == null || category_id == null || Place == null || Type == null)
            {
                return HttpNotFound();
            }
            
            if(Place == "Area" && Type == "Category")
            {
                if (!DbLayer.CheckIfAreaExists(area_id) || !DbLayer.CheckIfCategoryExists(category_id))
                {
                    return HttpNotFound();
                }

                return View(DbLayer.GetAllPosts(category_id, area_id));
            }

            else if (Place == "Area" && Type == "SubCategory")
            {
                if (!DbLayer.CheckIfAreaExists(area_id) || !DbLayer.CheckIfSubCategoryExists(category_id))
                {
                    return HttpNotFound();
                }

                return View(DbLayer.GetAllPosts(category_id, area_id, Place, Type));
            }

            else if (Place == "Locale" && Type == "Category")
            {
                if (!DbLayer.CheckIfLocaleExists(area_id) || !DbLayer.CheckIfCategoryExists(category_id))
                {
                    return HttpNotFound();
                }

                return View(DbLayer.GetAllPosts(category_id, area_id, Place, Type));
            }

            else if (Place == "Locale" && Type == "SubCategory")
            {
                if (!DbLayer.CheckIfLocaleExists(area_id) || !DbLayer.CheckIfSubCategoryExists(category_id))
                {
                    return HttpNotFound();
                }

                return View(DbLayer.GetAllPosts(category_id, area_id, Place, Type));
            }

            return HttpNotFound();
        }

        [ActionName("IndexGivenPlaceOnly")]
        public ActionResult Index(string area_id, string Place)
        {
            //handle errors and edgecases
            
            if (area_id == null || Place == null)
            {
                return HttpNotFound();
            }
            
            if (Place == "Area")
            {
                if (!DbLayer.CheckIfAreaExists(area_id))
                {
                    return HttpNotFound();
                }

                return View("Index", DbLayer.getPostsForArea(area_id));
            }
            else if (Place == "Locale")
            {
                if (!DbLayer.CheckIfLocaleExists(area_id))
                {
                    return HttpNotFound();
                }

                return View("Index", DbLayer.getPostsForLocale(area_id));
            }

            return HttpNotFound();
        }

        [ActionName("IndexGivenTypeOnly")]
        public ActionResult Index(string Place, string Type, string category_id)
        {
            //handle errors and edgecases

            if (category_id == null || Type == null || Place != null)
            {
                return HttpNotFound();
            }

            if (Type == "Category")
            {
                if (!DbLayer.CheckIfCategoryExists(category_id))
                {
                    return HttpNotFound();
                }

                return View("Index", DbLayer.getPostsForCategory(category_id));
            }
            else if (Type == "SubCategory")
            {
                if (!DbLayer.CheckIfSubCategoryExists(category_id))
                {
                    return HttpNotFound();
                }

                return View("Index", DbLayer.getPostsForSubCategory(category_id));
            }

            return HttpNotFound();
        }

        //viewing a post
        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            /**
            //handle errors and edgecases
            if (area_id == null || category_id == null)
            {
                return HttpNotFound();
            }
            else if (!DbLayer.CheckIfAreaExists(area_id) || !DbLayer.CheckIfCategoryExists(category_id))
            {
                return HttpNotFound();
            }
    **/
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (!DbLayer.CheckIfPostsExists((int)id))
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

        //GET Posts/Respond/5
        public ActionResult Respond(int? id)
        {
            //handle errors
            if (id == null)
            {
                return HttpNotFound();
            }
            if (!DbLayer.CheckIfPostsExists((int)id))
            {
                return HttpNotFound();
            }

            Post post = DbLayer.getPost((int)id);
            return View(post);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Respond([Bind(Include = "messageID,messageTimestamp,senderID,receiverID,body")] Message message, string area_id, string category_id, int? id)
        {
            //handle errors
            if (id == null)
            {
                return HttpNotFound();
            }
            if (!DbLayer.CheckIfPostsExists((int)id))
            {
                return HttpNotFound();
            }

            Post post = DbLayer.getPost((int)id);
            ViewBag.Message = message;

            if(ModelState.IsValid)
            {
                DbLayer.addMessageForPost((int)id, message);
                DbLayer.addMessageForUser(message.senderID, message);
                return RedirectToAction("Details", new { area_id = area_id, category_id = category_id, id = id });
            }
            return View(post);
        }
    }
}
