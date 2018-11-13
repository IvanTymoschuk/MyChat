using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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




    public class Sign_upViewModel: ViewModelBase
    {



        string warning;
        public string Warning { get { return warning; } set { warning = value; RaisePropertyChanged(); } }


        string login;
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

        string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        private RelayCommand sendCommand;
        public RelayCommand SendCommand
        {
            get
            {

                return sendCommand ??

               (sendCommand = new RelayCommand(obj =>
               {
                   if(name==null)
                   {
                       Warning = "name is empty";
                       return;
                   }
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
                   if (email == null)
                   {
                       Warning = "email is empty";
                       return;
                   }



                   UserClient userClient = new UserClient(new InstanceContext(new CallBackHandler()));
                   Mapper.Reset();
                   Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
                   UserDTO us = (userClient.Registration(email, name, password, login));
                   User user;
                   if (us!=null)
                       user = Mapper.Map<UserDTO, User>(us as UserDTO);
                   else
                   {
                       Warning = "Login is used";
                       return;
                   }



                   UserInfo sign=new UserInfo(){DataContext=new Sign_inViewModel()};
                   sign.Show();
                   App.Current.MainWindow.Close();
                   App.Current.MainWindow = sign;
                   
                   
               }));
            }
        }


    }
}
