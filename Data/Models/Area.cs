
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Area
    {
        [Key]
        //Add back database generated 
        public String areaID { get; set; }

        [Required]
        public String name
        {
            get; set;
        }

        public ICollection<Locale> locales
        {
            get; set;

        }
    }
}
