
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    class Area
    {
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
