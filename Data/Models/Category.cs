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
    public class Category
    {

        [Key]
        //Add back database generated 
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String categoryID { get; set; }

        [DefaultValue("")]
        public String name
        {
            get; set;
        }

        [DefaultValue(false)]
        public bool isDeletedOrHidden { get; set; }


        public virtual ICollection<Subcategory> subcategories
        {
            get; set;
        }

    }
}

