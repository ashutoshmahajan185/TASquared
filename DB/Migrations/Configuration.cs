namespace DB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DB.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DB.Database.ApplicationDbContext context)
        {

            DateTime dt = DateTime.Now;
            context.Areas.AddOrUpdate(x => x.areaID,
                new Area() { name = "New York", areaID = "0" },
                new Area() { name = "Chicago", areaID = "1" },
                new Area() { name = "Los Angeles", areaID = "2" },
                new Area() { name = "Seattle", areaID = "3" },
                new Area() { name = "San Francisco", areaID = "4" }
                );

            context.Locales.AddOrUpdate(x => x.localeID,
                new Locale() { name = "Brooklyn", localeID = "2" },
                new Locale() { name = "Pike Place", localeID = "5" },
                new Locale() { name = "Nob Hill", localeID = "7" },
                new Locale() { name = "South Side", localeID = "14" },
                new Locale() { name = "Balboa Park", localeID = "12" }
                );

            context.Categories.AddOrUpdate(x => x.categoryID,
               new Category() { name = "Housing", categoryID = "42" },
               new Category() { name = "Gigs", categoryID = "52" },
               new Category() { name = "For Sale", categoryID = "16" },
               new Category() { name = "Electronics", categoryID = "36" },
               new Category() { name = "Jobs", categoryID = "8" }
               );

            context.SubCategories.AddOrUpdate(x => x.subCategoryID,
              new Subcategory() { name = "Vehicles", subCategoryID = "55" },
              new Subcategory() { name = "Computer Parts", subCategoryID = "42" },
              new Subcategory() { name = "Apartments", subCategoryID = "19" },
              new Subcategory() { name = "Bands", subCategoryID = "31" },
              new Subcategory() { name = "Resume Workshops", subCategoryID = "76" }
              );

            context.Posts.AddOrUpdate(x => x.ID,
             new Post()
             {
                 ID = 23,
                 postNumber = 14,
                 postTimestamp = dt.AddDays(21),
                 postExpiration = dt.AddDays(15),
                 ownerID = "323534",
                 title = "Brand new car for sale",
                 area = "0",
                 category = "23"
             },
              new Post()
              {
                  ID = 42,
                  postNumber = 24,
                  postTimestamp = dt.AddDays(9),
                  postExpiration = dt.AddDays(19),
                  ownerID = "14342423",
                  title = "Looking for band mates",
                  area = "4",
                  category = "53"
              },
               new Post()
               {
                   ID = 232,
                   postNumber = 52,
                   postTimestamp = dt.AddDays(5),
                   postExpiration = dt.AddDays(22),
                   ownerID = "4233543",
                   title = "Looking for resume help",
                   area = "4",
                   category = "13"
               }
               );
             


            context.Messages.AddOrUpdate(x => x.messageID,
             new Message() { messageID = 321, messageTimestamp = dt.AddDays(24), senderID="4", receiverID="19", body = "Ouch that's expensive!" },
             new Message() { messageID = 41, messageTimestamp = dt.AddDays(9), senderID = "23", receiverID = "21", body = "I want a Tesla" },
             new Message() { messageID = 721, messageTimestamp = dt.AddDays(5), senderID = "17", receiverID = "43", body = "Let's play Rock Band" },
             new Message() { messageID = 32, messageTimestamp = dt.AddDays(12), senderID = "62", receiverID = "67", body = "I want to learn .NET" }
             
             );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
