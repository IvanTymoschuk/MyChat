using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MockModuls
{
    public class UserMocks : IMockData<User>
    {
        private static List<User> Users;

        static UserMocks()
        {
            Users = new List<User>();
            Users.Add(new User() { Name = "Lox Victor", Email = "victorlox@gmail.com", Login = "Maryana", Password = "1111", IsConfirmed = true});
            Users.Add(new User() { Name = "Lox Vasya", Email = "victorlox@gmail.com", Login = "Maryana", Password = "1111", IsConfirmed = true });
            Users.Add(new User() { Name = "Lox Vadim", Email = "victorlox@gmail.com", Login = "Maryana", Password = "1111", IsConfirmed = true });
            Users[0].Rooms = new RoomMocks().GetMock().ToList();
            Users[0].Friends.Add(Users[0]);
            Users[0].Friends.Add(Users[1]);
            Users[0].Friends.Add(Users[2]);

        }

        public IEnumerable<User> GetMock()
        {
           

            return Users;
        }
    }
}
