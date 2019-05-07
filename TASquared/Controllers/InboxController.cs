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
    //Inbox(GetPostsWithMessages, ViewMessagesForPost)
    public class InboxController : Controller
    {
        public InboxController()
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

        // GET: Inbox, GetPostsWithMessages
        public ActionResult Index(string userid)
        {
            //handle errors
            if (userid == null)
            {
                return HttpNotFound();
            }
            else if (!DbLayer.CheckIfUserExists(userid))
            {
                return HttpNotFound();
            }

            var postsWithResponses = DbLayer.getAllPostsWithResponsesForUser(userid);
            var postsRespondedTo = DbLayer.getPostsUserRespondedTo(userid);

            //need to make a viewmodel and combine results from  postsWithResponses and postsRespondedTo and pass it to view
            return View();
        }

        //view messages to a post
        //handle case if it is a thread a user responded to. in that case show only user's message
        // GET: Inbox/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!DbLayer.CheckIfPostsExists((int)id))
            {
                return HttpNotFound();
            }

            return View(DbLayer.GetMessagesToPost((int)id));
        }


        //do not need to following actions
        /**
        // GET: Inbox/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inbox/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "messageID,messageTimestamp,senderID,receiverID,body")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Inbox/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Inbox/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "messageID,messageTimestamp,senderID,receiverID,body")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Inbox/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Inbox/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        **/
    }
}
