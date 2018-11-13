using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Commands;

namespace Models
{
    public class User 
    {
        public User()
        {
            Rooms = new List<Room>();
            Friends = new List<User>();
            IFriend = new List<User>();
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<Room> Rooms { get; set; }

        public bool IsConfirmed { get; set; }

        public List<User> Friends { get; set; }
        public ICollection<User> IFriend { get; set; }

        public string Email { get; set; }

        private RelayCommand userInfoCommand;
        public RelayCommand UserInfoCommand
        {
            get
            {

                return userInfoCommand ??

                       (userInfoCommand = new RelayCommand(obj =>
                       {
                           MessageBox.Show(obj.ToString());
                       }));
            }
        }

    }
}
