
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    class Category
    {
        [DefaultValue("")]
        public String name
        {
            get; set;
        }
        public ICollection<Subcategory> subcategories
        {
            get; set;
        }

    }
}

