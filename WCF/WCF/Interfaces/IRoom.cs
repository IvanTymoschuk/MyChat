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
    public interface IRoom
    {
        [OperationContract]
        void CreateRoom(RoomDTO room);
        [OperationContract]
        void SendMessageAllUsersInRoom(RoomDTO room);
        [OperationContract]
        void ExitFromRoom(int your_id, int room_id);
        [OperationContract]
        void JoinInRoom(int your_id, int room_id);
        [OperationContract]
        ICollection<RoomDTO> GetRooms(int your_id);
        [OperationContract]
        ICollection<RoomDTO> getSearchRooms(string Name);

    }
}
