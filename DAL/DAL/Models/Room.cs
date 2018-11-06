using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Room
    {

        public Room()
        {
            Messages = new List<Message>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public List<Message> Messages { get; set; }

        public bool IsPublish { get; set; }


    }
}
