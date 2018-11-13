using AutoMapper;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Commands;
using WPF.MockModuls;
using WPF.Service;

namespace WPF.ViewModels.WindowViewModels
{
    public class CallBackHandler :IUserCallback, IMessageCallback, IRoomCallback
    {
        public void GetMessage(MessageDTO msg)
        {
            MessageBox.Show(msg.Body);
        }
    }

    public class Sign_inViewModel: ViewModelBase
    {

        string login;
        string warning;
        public string Warning { get { return warning; } set { warning = value; RaisePropertyChanged(); } }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;   
            }
        }

        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public Sign_inViewModel()
        {
            if (File.Exists("CurrentUser.json"))
            {
                using (StreamReader file =
                new System.IO.StreamReader(@"CurrentUser.json", true))
                {
                    User user = JsonConvert.DeserializeObject<User>(file.ReadToEnd());
                    login = user.Login;
                    password = user.Password;

                }
            }
           // SendCommand.Execute(new object());
        }


        private RelayCommand sendCommand;
        public RelayCommand SendCommand
        {
            get
            {

                return sendCommand ??

               (sendCommand = new RelayCommand(obj =>
               {
                   
                   if (login == null)
                   {
                       Warning = "login is empty";
                       return;
                   }
                   if (password == null)
                   {
                       Warning = "password is empty";
                       return;
                   }

                   if (File.Exists("CurrentUser.json"))
                   {
                       File.Delete("CurrentUser.json");
                      
                   }

                   using (System.IO.StreamWriter file =
                      new System.IO.StreamWriter("CurrentUser.json", true))
                   {
                       file.WriteLine(JsonConvert.SerializeObject(new User() { Login = login, Password = password }));
                   }



                   UserClient userClient = new UserClient(new InstanceContext(new CallBackHandler()));
                   Mapper.Reset();
                   Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
                   User user = Mapper.Map<UserDTO,User>(userClient.SignIn(login,password));


                   MainWindow sign = new MainWindow() { DataContext = new MainViewModel(user) };
                   sign.Show();
                   App.Current.MainWindow.Close();
                   App.Current.MainWindow = sign;


               }));
            }
        }


    }
}
