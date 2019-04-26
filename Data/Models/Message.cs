using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Message
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int messageID { get; set; }

        [Required]
        public DateTime messageTimestamp { get; set; }

        [Required]
        public String senderID { get; set; }

        [Required]
        public String receiverID { get; set; }

        [Required]
        public String body { get; set; }


    }
}
