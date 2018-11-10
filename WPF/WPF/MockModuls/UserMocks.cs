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
        public IEnumerable<User> GetMock()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Name = "Lox Victor", Email = "victorlox@gmail.com", Login = "Maryana", Password = "1111", IsConfirmed = true ,Rooms = new RoomMocks().GetMock().ToList()});
            users.Add(new User() { Name = "Lox Vasya", Email = "victorlox@gmail.com", Login = "Maryana", Password = "1111", IsConfirmed = true });
            users.Add(new User() { Name = "Lox Vadim", Email = "victorlox@gmail.com", Login = "Maryana", Password = "1111", IsConfirmed = true });

            return users;
        }
    }
}
