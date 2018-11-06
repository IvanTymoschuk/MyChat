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
    public interface IUser
    {
        [OperationContract]
        UserDTO SignIn(string Email, string password);
        [OperationContract]
        UserDTO Registration(string Email, string Password, string Login);
        [OperationContract]
        bool Confirming(UserDTO user, int Code);
        [OperationContract]
        bool Add_Friend(string FriendLogin);
        [OperationContract]
        void Add_Room(RoomDTO room);
    }
}
