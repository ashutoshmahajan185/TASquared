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
    public class Post
    {

        [Key]
         //Add back database generated 
        public int ID { get; set; }

        [Required]
        public int postNumber { get; set; }

        [Required]
        public DateTime postTimestamp { get; set; }

        [Required]
        public DateTime postExpiration { get; set; }

        [Required]
        public String ownerID { get; set; }

        [Required]
        public String title { get; set; }

        [DefaultValue("")]
        public String body { get; set; }

        [Required]
        public String area { get; set; }

        [DefaultValue("")]
        public String locale { get; set; }

        [Required]
        public String category { get; set; }

        [DefaultValue("")]
        public String subcategory { get; set; }

        [DefaultValue(false)]
        public bool isDeletedOrHidden { get; set; }

        [DefaultValue(true)]
        public bool canBeModified { get; set; }

        public ICollection<Message> messages { get; set; }

    }
}
