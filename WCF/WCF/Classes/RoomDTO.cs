using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Classes
{
    [DataContract]
    public class RoomDTO
    {
        public RoomDTO()
        {
            Messages = new List<MessageDTO>();
            users = new List<UserDTO>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public UserDTO User { get; set; }
        [DataMember]
        public List<UserDTO> users { get; set; }
        public List<MessageDTO> Messages { get; set; }
        [DataMember]
        public bool IsPublish { get; set; }

    }
}
