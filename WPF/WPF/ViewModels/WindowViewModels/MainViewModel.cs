﻿using Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Commands;
using WPF.MockModuls;
using WPF.Service;
using System.ServiceModel;
using WPF.ViewModels.WindowViewModels;
using AutoMapper;

namespace WPF.ViewModels
{

    public class ConfirmCode
    { }



    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<User> Friends { get; set; }

        public ObservableCollection<Message> Messages { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }


        public Room SelectedRoom { get; set; }






        private string message;
        public string MessageBody
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged();
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {


                _selectedUser = value;

                RaisePropertyChanged();
            }
        }

        private int _activeUsers;
        public int ActiveUsers
        {
            get
            {
                return _activeUsers;
            }
            set
            {
                _activeUsers = value;
                RaisePropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ActiveUsers"));
            }
        }






        public MainViewModel(User user)
        {
            



           

           

            UserClient userClient = new UserClient(new InstanceContext(new CallBackHandler()));
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
             //userClient.Add_Friend(user.Id,2);
             //userClient.Add_Friend(user.Id,3);
              Friends = new ObservableCollection<User>();
            foreach (var item in userClient.GetFriends(user.Id).ToList())
            {

                Friends.Add(Mapper.Map<UserDTO, User>(item as UserDTO));
            }



            RoomClient roomClient = new RoomClient(new InstanceContext(new CallBackHandler()));
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<RoomDTO, Room>());


           
            

            Rooms = new ObservableCollection<Room>();
            foreach (var item in roomClient.GetRooms(user.Id))
            {
                Rooms.Add(Mapper.Map<RoomDTO, Room>(item as RoomDTO));
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

                   //Messages.Add(new Message(){Sender = Users[0],Body = message,DateTimeSended = DateTime.Now});

               }));
            }
        }

        private RelayCommand findUser;
        public RelayCommand FindUser
        {
            get
            {

                return findUser ??

                       (findUser = new RelayCommand(obj =>
                       {
                           MessageBox.Show("ldldl");
                       }));
            }
        }

        private RelayCommand usersignout;
        public RelayCommand UserSignOut
        {
            get
            {

                return usersignout ??

                       (usersignout = new RelayCommand(obj =>
                       {

                           StartWindow sign = new StartWindow();
                           sign.Show();
                           App.Current.MainWindow.Close();
                           App.Current.MainWindow = sign;
                       }));
            }
        }

        




    }
}
