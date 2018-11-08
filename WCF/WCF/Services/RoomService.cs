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
    public class RoomServices : IRoom
    {
        public void CreateRoom(RoomDTO room)
        {
            throw new NotImplementedException();
        }

        public void SendMessageAllUsersInRoom(RoomDTO room)
        {
            foreach(var el in room.users)
            {
                el.callback.GetMessage(room.Messages[room.Messages.Count - 1]);
            }
        }
    }
}
