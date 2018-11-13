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
        UserDTO SignIn(string EmailOrLogin, string password);
        [OperationContract]
        UserDTO Registration(string Email,string Name, string Password, string Login);
        [OperationContract]
        bool Confirming(int user_id, int Code);
        [OperationContract]
        bool ResendCode(int user_id);
        [OperationContract]
        IEnumerable<UserDTO> getSearchPeople(string Name);
        [OperationContract]
        void Add_Friend(int your_id, int friend_id);
        [OperationContract]
        void RemoveFriend(int your_id, int friend_id);
        [OperationContract]
        UserDTO GetUserId(int id);
        [OperationContract]
        IEnumerable<UserDTO> GetFriends(int id);

    }
}
