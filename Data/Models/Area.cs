﻿
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
    public class Area
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Add back database generated 
        public String areaID { get; set; }

        [Required]
        public String name
        {
            get; set;
        }

        [DefaultValue(false)]
        public bool isDeletedOrHidden { get; set; }

        public ICollection<Locale> locales
        {
            get; set;

        }
    }
}
