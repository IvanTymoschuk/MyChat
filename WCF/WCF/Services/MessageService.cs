using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;
using WCF.Interfaces;
namespace WCF
{
    public class MessageService : IMessage
    {

        public void SendMessage(string body, RoomDTO room, UserDTO sender, AttachDTO attach = null)
        {
            List<AttachDTO> attaches = null;
            if (attach != null)
            {
              attaches = new List<AttachDTO>();
                attaches.Add(attach);
            }
            MessageDTO message = new MessageDTO() {Body = body, DateTimeSended = DateTime.Now, Room = room, Sender = sender, Attaches = attaches };
        }
    }
}
