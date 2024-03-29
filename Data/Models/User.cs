﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [Required]
        [Key]

        public String userID
        {
            get; set;
        }

        [Required]
        public string userRole
        {
            get; set;

        }
        [Required]
        public int phoneNumber
        {
            get; set;
        }
        [DefaultValue("")]
        public String email
        {
            get; set;
        }

        public ICollection<Message> messages
        {
            get; set;
        }

    }
}