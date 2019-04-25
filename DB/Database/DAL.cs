﻿using Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLogic.Logic;
using System.Data.Entity;

namespace DB.Database
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
        public DbSet<User> User { get; set; }
    }

    public class DbLayer
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static IEnumerable<Area> GetAllAreas()
        {
            var Areas = from area in db.Areas
                        select area;

            //add bizlogic here to sort before returning
            var orderedAreas = Biz.SortAreas(Areas.ToList());

            return orderedAreas;
        }

        public static IEnumerable<Locale> GetAllLocales()
        {
            var Locales = from locale in db.Locales
                        select locale;

            //add bizlogic here to sort before returning
            var orderedlocales = Biz.SortLocales(Locales.ToList());

            return orderedlocales;
        }

        public static IEnumerable<Category> GetAllCategories()
        {
            var Categories = from category in db.Categories
                          select category;

            //add bizlogic here to sort before returning
            var orderedCategories = Biz.SortCategories(Categories.ToList());

            return orderedCategories;
        }

        public static IEnumerable<Subcategory> GetAllSubCategories()
        {
            var SubCategories = from subcategory in db.SubCategories
                             select subcategory;

            //add bizlogic here to sort before returning
            var orderedSubCategories = Biz.SortSubCategories(SubCategories.ToList());

            return orderedSubCategories;
        }

        //Andrew how does this work?

        //cID can be either categoryID or subcategoryID and lID can be either localeID or areaID
        public static IEnumerable<Post> GetAllPosts(string cID, string lID)
        {
            var Posts = from post in db.Posts
                        where post.locale == lID && post.category == cID
                        select post;

            //bizlogic to sort according to most recent time
            var orderedPosts = Biz.OrderPosts(Posts.ToList());

            return orderedPosts;

        }

        public static IEnumerable<Post> GetAllPosts(string userID)
        {
            var Posts = from post in db.Posts
                        select post;

            //bizlogic to sort according to most recent time
            var orderedPosts = Biz.OrderPosts(Posts.ToList());

            return orderedPosts;
        }
        
        public static IEnumerable<Post> GetAllUnexpiredPosts(string userID)
        {
            var Posts = from post in db.Posts
                        where !post.isDeletedOrHidden
                        select post;

            //bizlogic to sort according to most recent time
            var orderedPosts = Biz.OrderPosts(Posts.ToList());

            return orderedPosts;
        }

        public static IEnumerable<Post> GetAllExpiredPosts(string userID)
        {
            var Posts = from post in db.Posts
                        where post.isDeletedOrHidden
                        select post;

            //bizlogic to sort according to most recent time
            var orderedPosts = Biz.OrderPosts(Posts.ToList());

            return orderedPosts;
        }

        public static IEnumerable<Message> GetMessagesToPost(string postID)
        {
            //handle error cases
            var Post = db.Posts.Find(postID);
            var Messages = Post.messages;

            //bizlogic to sort
            var orderedMessages = Biz.OrderMessages(Messages.ToList());

            return orderedMessages;
        }

        public static IEnumerable<Message> GetMessagesFromUser(string userID)
        {
            //handle error cases
            var User = db.User.Find(userID);
            var Messages = User.messages;

            //bizlogic to sort
            var orderedMessages = Biz.OrderMessages(Messages.ToList());

            return orderedMessages;
        }

        public static void SavePost(Post post)
        {
            //bizlogic to compute expiration time
            Biz.SetPostExpirationTime(post);

            db.Posts.Add(post);
            db.SaveChanges();
        }


        /*addMessageForPost: adding a message for a specific posting*/
        public static void addMessageForPost(string postId, Message msg)
        {
            var post = db.Posts.Find(postId);
            post.messages.Add(msg);
            db.SaveChanges();
        }
        /*addMessageForUser: adding a message for a specific user*/
        public static void addMessageForUser(string userId, Message msg)
        {
            var user = db.User.Find(userId);
            user.messages.Add(msg);
            db.SaveChanges();
        }
        /*changeUserRole: changing the role of the user to Administrator */
        public static void changeUserRole(string userId)
        {
            var user = db.User.Find(userId);
            user.userRole = "Admin";
            db.SaveChanges();
        }
        /* deletePost: setting the isDeletedorHidden property to true from db */
        public static void deletePost(string postId)
        {
            var post = db.Posts.Find(postId);
            post.isDeletedOrHidden = true;
            db.SaveChanges();
        }
        /*expirePost: Checking if current time is greater than or equal to post's expiration time
         * in which it is "removed" from the database */
        public static void expirePost(string postId)
        {
            var post = db.Posts.Find(postId);
            if (post.postExpiration <= DateTime.Now)
            {
                post.isDeletedOrHidden = true;
            } else
            {
                return;
            }
            db.SaveChanges();
        }

        /*getPosts: gets the list of posts by a specific user*/
        public static IEnumerable<Post> getPosts(string userId)
        {
            IEnumerable<Post> lst;
            var entities = from entity in db.Posts
                           where userId == entity.ownerID
                           select entity;
            lst = entities;
            return lst;
        }
        /* addCategory: adding a new category */
        public static void addCategory(Category cat)
        {
            db.Categories.Add(cat);
            db.SaveChanges();
        }
        /* addSubcategory: adding a new subcategory */
        public static void addSubcategory(Subcategory sub)
        {
            db.SubCategories.Add(sub);
            db.SaveChanges();
        }
        /* addArea: adding a new area */
        public static void addArea(Area area)
        {
            db.Areas.Add(area);
            db.SaveChanges();
        }
        /* addLocale: adding a new locale */
        public static void addLocale(Locale loc)
        {
            db.Locales.Add(loc);
            db.SaveChanges();
        }

        /* getAllUsers: Returns a list of all users
         * Checks to see if the user is an administrator
         * before allowing access to users list */
        public IEnumerable<User> getAllUsers(User user)
        {
            
            if (user.userRole != "Admin")
            {
                return null;
            }
            var users = from customer in db.User
                        select customer;

            IEnumerable<User> lst = users.ToList();
            return lst;
        }


        /*AddUser: adding a new user */
        public static void AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }


        public static void DoDatabaseOperation()
        {
            // You can place your models into ApplicationDbContext
            // or create your own context
            using (var db = new ApplicationDbContext())
            {
                // Create and manipulate your model
                Example ex = new Example();
                ex.Name = "Hello";

                // Call into biz logic
                Biz.IsExampleValid(ex);

                // Do something useful here

                db.SaveChanges();
            }
        }

    }
}
