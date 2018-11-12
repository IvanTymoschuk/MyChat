using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;

namespace WCF.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IUserCallback))]
    public interface IUser
    {
        [OperationContract]
        UserDTO SignIn(string EmailOrLogin = "Admin1", string password="Admin1");
        [OperationContract]
        UserDTO Registration(string Email, string Password, string Login);
        [OperationContract]
        bool Confirming(int user_id, int Code);
        [OperationContract]
        bool ResendCode(int user_id);
        [OperationContract]
        IEnumerable<UserDTO> getSeachPeople(string Name);
        [OperationContract]
        void Add_Friend(int your_id, int friend_id);
        [OperationContract]
        void Add_Room(int your_id, int room_id);
        [OperationContract]
        void RemoveFriend(int your_id, int friend_id);
        [OperationContract]
        void RemoveRoom(int your_id, int room_id);
    }
}
