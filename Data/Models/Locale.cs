using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Locale
    {
        [Key]
        //Add back database generated 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String localeID { get; set; }

        [DefaultValue("")]
        public String name
        {
            get; set;
        }

        public ICollection<Post> posts
        {
            get; set;
        }
    }
}

