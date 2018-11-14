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




    public class UserInfoViewModel: ViewModelBase
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
                RaisePropertyChanged();

            }
        }

        List<User> friends;
        public List<User> Friends
        {
            get
            {
                return friends;
            }
            set
            {
                friends = value;
                RaisePropertyChanged();

            }
        }

        public UserInfoViewModel(int UserId)
        {



            UserClient userClient = new UserClient(new InstanceContext(new CallBackHandler()));
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
           
           
           var user= Mapper.Map<UserDTO, User>(userClient.GetUserId(UserId) as UserDTO);



            Name = user.Name;
            Login = user.Login;
            Email=user.Email ;
            Friends=user.Friends;

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
                RaisePropertyChanged();

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
                RaisePropertyChanged();

            }
        }

    }
}
