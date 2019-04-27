using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic.Logic
{
    public static class Biz
    {

        /*SortAreas: sort areas by alphabetical name */
        public static IEnumerable<Area> SortAreas(IEnumerable<Area> Areas)
        {
            var OrderedAreas = Areas.OrderBy(x => x.name);
            return OrderedAreas;
        }
        /*SortLocales: sort locales by alphabetical name */
        public static IEnumerable<Locale> SortLocales(IEnumerable<Locale> Locales)
        {
            var Orderedlocales = Locales.OrderBy(x => x.name);
            return Orderedlocales;
        }
        /* SortCategories: returns all categories in sorted alphabetical order */
        public static IEnumerable<Category> SortCategories(IEnumerable<Category> Categories)
        {
            var OrderedCategories = Categories.OrderBy(x => x.name);
            return OrderedCategories;
        }
        /*SortSubCategories: returns all subcategories in sorted alphabetical order */
        public static IEnumerable<Subcategory> SortSubCategories(IEnumerable<Subcategory> SubCategories)
        {
            var OrderedSubCategories = SubCategories.OrderBy(x => x.name);
            return OrderedSubCategories;
        }
        /* OrderPosts: returns all posts by time stamp with most recent post first */
        public static IEnumerable<Post> OrderPosts(IEnumerable<Post> Posts)
        {
            var OrderedPosts = Posts.OrderBy(x => x.postTimestamp);
            return OrderedPosts.Reverse();
        }
        /* OrderMessages: returns all messages by time stamp with most recent message first */
        public static IEnumerable<Message> OrderMessages(IEnumerable<Message> Messages)
        {
            var OrderedMessages = Messages.OrderBy(x => x.messageTimestamp);
            return OrderedMessages.Reverse();
        }
        /*SetPostExpirationTime: sets the expiration time of the post 10 days from post time creation */
        public static void SetPostExpirationTime(Post post)
        {
            post.postExpiration = post.postTimestamp.AddDays(10); 
        }

       
    }
}
