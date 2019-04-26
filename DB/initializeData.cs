using Data.Models;
using DB.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class initializeData : DropCreateDatabaseIfModelChanges <ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            seedAreas(context);
            context.SaveChanges();
            base.Seed(context);
        }

        private void seedAreas(ApplicationDbContext context)
        {
            var areas = new List<Area>
            {
                new Area
                {
                    name = "New York",
                },
                new Area
                {
                    name = "Chicago",
                },
                new Area
                {
                    name = "Los Angeles",
                },
                new Area
                {
                    name = "Albany",
                },
                new Area
                {
                    name = "San Francisco",
                }
            };
            areas.ForEach(area => context.Areas.Add(area));
            context.SaveChanges();
        }

        //Database.SetInitializer<ApplicationDbContext>(new initializeData()); 
    }
}
