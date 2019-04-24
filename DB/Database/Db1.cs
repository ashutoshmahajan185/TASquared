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
        public DbSet<User> Users { get; set; }
    }

    public class Db1
    {

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
