using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFTestConsole.ServiceReference1;

namespace WCFTestConsole
{

    public class CallBackHandler : WCFTestConsole.ServiceReference1.IUserCallback, IMessageCallback, IRoomCallback
    {
        public void GetMessage(MessageDTO msg)
        {
            Console.WriteLine("sender: "+ msg.Sender.Name
                );
            Console.WriteLine("body:" + msg.Body);
            Console.WriteLine("Time: "+ msg.DateTimeSended);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //try
            ////{
           CallBackHandler callBackHandler = new CallBackHandler();
          UserClient userClient = new UserClient(new InstanceContext(callBackHandler));
                RoomClient roomClient = new RoomClient(new InstanceContext(callBackHandler));
            RoomDTO room = new RoomDTO() { Id = 1, IsPublish = true, Name = "Room", Users = null };
            roomClient.CreateRoom(room);
            roomClient.JoinInRoom(1, 1);
            roomClient.JoinInRoom(2, 1);



            //var users = userClient.getSearchPeople("Lox");
            //foreach (var el in users)
            //{
            //    Console.WriteLine(el.Name);
            //}



            MessageClient message = new MessageClient(new InstanceContext(new CallBackHandler()));
            message.SendMessage("asd", room, userClient.GetUserId(1),null);
           
            //MessageDTO msg = new MessageDTO() { Body = "123", DateTimeSended = DateTime.Now, Room = room, Sender = userClient.GetUserId(1) };
           //roomClient.SendMessageAllUsersInRoom(room,msg);
            Console.WriteLine("Done");
            var l = roomClient.getSearchRooms("Room");
            foreach (var el in l)
            {
                Console.WriteLine(el.Name);
            }

            Console.ReadLine();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    Console.ReadLine();
            //}
        }
    }
}
