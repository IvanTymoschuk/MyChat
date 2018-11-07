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
    public interface IMessage
    {
        [OperationContract]
        void SendMessage(string body, RoomDTO room, UserDTO sender, AttachDTO attach=null);
    }
}
