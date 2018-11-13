using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public User()
        {
            Rooms = new List<Room>();
            Friends = new List<User>();
        }

        public int Id { get; set; }
      
        public string Login { get; set; }
      
        public string Password { get; set; }
       
        public List<Room> Rooms { get; set; }
        
        public bool IsConfirmed { get; set; }
        
        public List<User> Friends { get; set; }
      
        public string Email { get; set; }
    }
}
