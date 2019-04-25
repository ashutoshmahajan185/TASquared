using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BizLogic.Logic;
using DB.Database;


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
            Biz.SortAreas(db.Areas);
        }
        // Sort Locales
        [TestMethod]
        public void Test_SortLocales()
        {
            Biz.SortLocales(db.Locales);
        }

        // Sort Categorys
        [TestMethod]
        public void Test_sortCategories()
        {
            Biz.SortCategories(db.Categories);
        }
        // Sort Subcategories
        [TestMethod]
        public void Test_sortSubcategories()
        {
            Biz.SortSubCategories(db.SubCategories);
        }



        // Order Posts
        [TestMethod]
        public void Test_orderPosts()
        {
            Biz.OrderPosts(db.Posts);
        }
        // order Messages
        [TestMethod]
        public void Test_orderMessages()
        {
            Biz.OrderMessages(db.Messages);
        }

        // Post expiration
        [TestMethod]
        public void Test_postExpiration()
        {
            // Redundant test case
        }
    }
}
