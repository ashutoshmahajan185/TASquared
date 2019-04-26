
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Area
    {
        //[Key]
      
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
