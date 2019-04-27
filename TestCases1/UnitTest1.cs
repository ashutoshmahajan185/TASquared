using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BizLogic.Logic;
using DB.Database;
using System.Linq;
using System.Collections.Generic;

namespace TestCases1
{
    [TestClass]
    public class UnitTest1
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // Sort Areas
        [TestMethod]
        public void Test_SortAreas()
        {
            List<String> listAreas = new List<String> {
                "Chicago", "Los Angeles", "New York", "San Francisco", "Seattle"
            };

            var areas = from area in db.Areas
                        select area;

            var output = Biz.SortAreas(areas.ToList());

            List<String> AreaNames = new List<String>();

            foreach (var item in output)
            {
                AreaNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listAreas, AreaNames);

        }
        // Sort Locales
        [TestMethod]
        public void Test_SortLocales()
        {
            List<String> listLocales = new List<String> {
                "Balboa Park", "Brooklyn", "Nob Hill", "Pike Place", "South Side"
            };

            var locales = from locale in db.Locales
                          select locale;
            var output = Biz.SortLocales(locales.ToList());

            List<String> LocaleNames = new List<String>();

            foreach (var item in output)
            {
                LocaleNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listLocales, LocaleNames);
        }

        // Sort Categorys
        [TestMethod]
        public void Test_sortCategories()
        {
            List<String> listCategories = new List<String> {
                "Electronics", "For Sale", "Gigs", "Housing", "Jobs"
            };

            var cats = from cat in db.Categories
                       select cat;
            var output = Biz.SortCategories(cats.ToList());

            List<String> CatNames = new List<String>();

            foreach (var item in output)
            {
                CatNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listCategories, CatNames);
        }
        // Sort Subcategories
        [TestMethod]
        public void Test_sortSubcategories()
        {
            List<String> listSubcategories = new List<String> {
                "Apartments", "Bands", "Computer Parts", "Resume Workshops", "Vehicles"
            };

            var subs = from sub in db.SubCategories
                       select sub;
            var output = Biz.SortSubCategories(subs.ToList());

            List<String> SubCatNames = new List<String>();

            foreach (var item in output)
            {
                SubCatNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listSubcategories, SubCatNames);
        }



        // Order Posts
        [TestMethod]
        public void Test_orderPosts()
        {

            List<String> listPosts = new List<String> {
                "14", "24", "52"
            };

            var posts = from post in db.Posts
                        select post;
            var output = Biz.OrderPosts(posts.ToList());
            List<String> postNames = new List<String>();

            foreach (var item in output)
            {
                postNames.Add(item.postNumber.ToString());
            }

            CollectionAssert.AreEqual(listPosts, postNames);

        }
        // order Messages
        [TestMethod]
        public void Test_orderMessages()
        {
            List<String> listMessages = new List<String> {
                "4", "62", "23", "17"
            };
            var msgs = from msg in db.Messages
                       select msg;
            var output = Biz.OrderMessages(msgs.ToList());
            List<String> messagesNames = new List<String>();

            foreach (var item in output)
            {
                messagesNames.Add(item.senderID.ToString());
            }

            CollectionAssert.AreEqual(listMessages, messagesNames);
        }

        // Post expiration
        [TestMethod]
        public void Test_postExpiration()
        {
            // Redundant test case
        }

        [TestMethod]
        public void Test_getAllAreas()
        {
            List<String> listAreas = new List<String> {
                "Chicago", "Los Angeles", "New York", "San Francisco", "Seattle"
            };
            var result = DbLayer.GetAllAreas();
            List<String> AreaNames = new List<String>();

            foreach (var item in result)
            {
                AreaNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listAreas, AreaNames);


        }

        [TestMethod]
        public void Test_getAllLocales()
        {

            List<String> listLocales = new List<String> {
                "Balboa Park", "Brooklyn", "Nob Hill", "Pike Place", "South Side"
            };

            var result = DbLayer.GetAllLocales();

            List<String> LocaleNames = new List<String>();

            foreach (var item in result)
            {
                LocaleNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listLocales, LocaleNames);

        }

        [TestMethod]
        public void Test_getAllCategories()
        {

            List<String> listCategories = new List<String> {
                "Electronics", "For Sale", "Gigs", "Housing", "Jobs"
            };

            var result = DbLayer.GetAllCategories();

            List<String> CatNames = new List<String>();

            foreach (var item in result)
            {
                CatNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listCategories, CatNames);

        }
        [TestMethod]
        public void Test_getAllSubCategories()
        {
            List<String> listSubcategories = new List<String> {
                "Apartments", "Bands", "Computer Parts", "Resume Workshops", "Vehicles"
            };

            var result = DbLayer.GetAllSubCategories();

            List<String> SubCatNames = new List<String>();

            foreach (var item in result)
            {
                SubCatNames.Add(item.name);
            }

            CollectionAssert.AreEqual(listSubcategories, SubCatNames);
        }

        [TestMethod]
        // Testing only for user. Other combinations like getAllPost based on
        // 2. Area
        // 3. Locale
        // 4. Category
        // 5. Subcategory
        public void Test_getAllPosts() 
        {
            List<String> listPosts = new List<String> {
                "14"
            };

            var result = DbLayer.GetAllPosts("323534");
            List<String> postNames = new List<String>();

            foreach (var item in result)
            {
                postNames.Add(item.postNumber.ToString());
            }

            CollectionAssert.AreEqual(listPosts, postNames);
        }

        [TestMethod]
        public void Test_getAllExpiredPosts()
        {
            List<String> listPosts = new List<String> {
                "24"
            };

            var result = DbLayer.GetAllExpiredPosts("14342423");
            List<String> postNames = new List<String>();

            foreach (var item in result)
            {
                postNames.Add(item.postNumber.ToString());
            }

            CollectionAssert.AreEqual(listPosts, postNames);

        }


        [TestMethod]
        public void Test_getAllUnExpiredPosts()
        {
            List<String> listPosts = new List<String> {
                "52"
            };

            var result = DbLayer.GetAllUnexpiredPosts("4233543");
            List<String> postNames = new List<String>();

            foreach (var item in result)
            {
                postNames.Add(item.postNumber.ToString());
            }

            CollectionAssert.AreEqual(listPosts, postNames);

        }

        [TestMethod]
        public void Test_getMessagesToPost()
        {
            // Cannot implement the test case at this stage.
            // Database connection needs to be done
        }

        [TestMethod]
        public void Test_getMessageFromUser()
        {
            // Cannot implement the test case at this stage.
            // Database connection needs to be done
        }

        [TestMethod]
        public void Test_checkExpirePost()
        {
            // Cannot implement the test case at this stage.
            // Database connection needs to be done
        }

    }
}
