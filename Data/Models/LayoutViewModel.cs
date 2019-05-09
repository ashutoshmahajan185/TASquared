using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LayoutViewModel
    {
        public IEnumerable<Area> areas { get; set; }

        public IEnumerable<Locale> locales { get; set; }

        public IEnumerable<Category> categories { get; set; }

        public IEnumerable<Subcategory> subcategories { get; set; }

        public IEnumerable<Post> posts { get; set; }

        public IEnumerable<User> users { get; set; }

    }
}
