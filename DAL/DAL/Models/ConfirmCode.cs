using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

    public class ConfirmCode
    {
      
        public int Id { get; set; }
  
        public User user { get; set; }
     
        public int code { get; set; }
    }
}
