using Data.Models;
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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
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

            return Areas.ToList();
        }

        public static IEnumerable<Locale> GetAllLocales()
        {
            var Locales = from locale in db.Locales
                        select locale;

            //add bizlogic here to sort before returning

            return Locales.ToList();
        }

        public static IEnumerable<Category> GetAllCategories()
        {
            var Categories = from category in db.Categories
                          select category;

            //add bizlogic here to sort before returning

            return Categories.ToList();
        }

        public static IEnumerable<Subcategory> GetAllSubCategories()
        {
            var SubCategories = from subcategory in db.SubCategories
                             select subcategory;

            //add bizlogic here to sort before returning

            return SubCategories.ToList();
        }

        //cID can be either categoryID or subcategoryID and lID can be either localeID or areaID
        public static IEnumerable<Post> GetAllPosts(string cID, string lID)
        {
            var Posts = from post in db.Posts
                        where post.locale == lID && post.category == cID
                        select post;

            //bizlogic to sort according to most recent time

            return Posts.ToList();

        }

        public static IEnumerable<Post> GetAllPosts(string userID)
        {
            var Posts = from post in db.Posts
                        select post;

            //bizlogic to sort according to most recent time

            return Posts.ToList();
        }

        public static IEnumerable<Post> GetAllUnexpiredPosts(string userID)
        {
            var Posts = from post in db.Posts
                        where post.isDeletedOrHidden
                        select post;

            //bizlogic to sort according to most recent time

            return Posts.ToList();
        }

        public static IEnumerable<Post> GetAllExpiredPosts(string userID)
        {
            var Posts = from post in db.Posts
                        where !post.isDeletedOrHidden
                        select post;

            //bizlogic to sort according to most recent time

            return Posts.ToList();
        }

        public static void SavePost(Post post)
        {
            //bizlogic to compute expiration time

            db.Posts.Add(post);
            db.SaveChanges();
        }

        public static IEnumerable<Message> GetMessagesToPost(string postID)
        {
            //handle error cases
            var Post = db.Posts.Find(postID);
            var Messages = Post.messages;

            //bizlogic to sort

            return Messages.ToList();
        }

        public static IEnumerable<Message> GetMessagesFromUser(string userID)
        {
            //handle error cases
            var User = db.User.Find(userID);
            var Messages = User.messages;

            //bizlogic to sort

            return Messages.ToList();
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
                Biz1.IsExampleValid(ex);

                // Do something useful here

                db.SaveChanges();
            }
        }

    }
}
