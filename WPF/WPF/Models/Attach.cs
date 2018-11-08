using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Attach
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }

        public Message Message { get; set; }
    }
}
