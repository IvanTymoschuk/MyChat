using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {

        public Room()
        {
            Messages = new List<Message>();
            Users = new List<User>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

       

        public List<Message> Messages { get; set; }
        public ICollection<User> Users { get; set; }
        public bool IsPublish { get; set; }


    }
}
