using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WCF.Interfaces;

namespace WCF.Classes
{
    [DataContract]
    public class UserDTO
    {
        public UserDTO()
        {
            Rooms = new List<RoomDTO>();
            Friends = new List<UserDTO>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<RoomDTO> Rooms { get; set; }
        [DataMember]
        public bool IsConfirmed { get; set; }
        [DataMember]
        public List<UserDTO> Friends { get; set; }
        [DataMember]
        public string Email { get; set; }
        public IUserCallback callback { get; set; }
    }
}
