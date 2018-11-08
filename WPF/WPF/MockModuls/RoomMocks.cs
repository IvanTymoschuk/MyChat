using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MockModuls
{
    public class RoomMocks : IMockData<Room>
    {
        public IEnumerable<Room> GetMock()
        {
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room() { Name = "Lox Victor" ,Messages=new MessageMocks().GetMock().ToList(),User=new UserMocks().GetMock().ToList()[0]});
            return rooms;
        }
    }
}
