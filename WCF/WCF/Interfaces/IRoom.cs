using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;

namespace WCF.Interfaces
{
    [ServiceContract]
    public interface IRoom
    {
        [OperationContract]
        void CreateRoom(RoomDTO room);
        [OperationContract]
        void SendMessageAllUsersInRoom(RoomDTO room);
    }
}
