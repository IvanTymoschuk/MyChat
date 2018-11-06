using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Message
    {
        public Message()
        {
            Attaches = new List<Attach>();
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime DateTimeSended { get; set; }

        public User Sender { get; set; }

        public Room Room { get; set; }

        public List<Attach> Attaches { get; set; }


    }
}
