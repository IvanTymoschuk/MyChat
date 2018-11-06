using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Classes
{
    [DataContract]
    public class MessageDTO
    {
        public MessageDTO()
        {
            Attaches = new List<AttachDTO>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public DateTime DateTimeSended { get; set; }
        [DataMember]
        public UserDTO Sender { get; set; }
        [DataMember]
        public RoomDTO Room { get; set; }
        [DataMember]
        public List<AttachDTO> Attaches { get; set; }
    }
}
