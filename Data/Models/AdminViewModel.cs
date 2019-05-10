using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Post> posts { get; set; }

        public IEnumerable<User> users { get; set; }
    }
}
