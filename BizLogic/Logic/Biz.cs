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
        public static IEnumerable<Area> SortAreas(IEnumerable<Area> Areas)
        {
            var OrderedAreas = Areas.OrderBy(x => x.name);
            return OrderedAreas;
        }

        public static IEnumerable<Locale> SortLocales(IEnumerable<Locale> Locales)
        {
            var Orderedlocales = Locales.OrderBy(x => x.name);
            return Orderedlocales;
        }

        public static IEnumerable<Category> SortCategories(IEnumerable<Category> Categories)
        {
            var OrderedCategories = Categories.OrderBy(x => x.name);
            return OrderedCategories;
        }

        public static IEnumerable<Subcategory> SortSubCategories(IEnumerable<Subcategory> SubCategories)
        {
            var OrderedSubCategories = SubCategories.OrderBy(x => x.name);
            return OrderedSubCategories;
        }

        public static IEnumerable<Post> OrderPosts(IEnumerable<Post> Posts)
        {
            var OrderedPosts = Posts.OrderBy(x => x.postTimestamp);
            return OrderedPosts.Reverse();
        }

        public static IEnumerable<Message> OrderMessages(IEnumerable<Message> Messages)
        {
            var OrderedMessages = Messages.OrderBy(x => x.messageTimestamp);
            return OrderedMessages.Reverse();
        }

        public static void SetPostExpirationTime(Post post)
        {
            post.postExpiration = post.postTimestamp.AddDays(10); 
        }

        public static bool IsExampleValid(Example p)
        {
            return true;
        }
    }
}
