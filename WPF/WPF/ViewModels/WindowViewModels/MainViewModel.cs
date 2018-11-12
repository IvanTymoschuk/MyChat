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

namespace WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<User> Friends { get; set; }

        public ObservableCollection<Message> Messages { get; set; }

        public ObservableCollection<Room> Rooms  { get; set; }


        public Room SelectedRoom { get; set; }



        private string message;
        public string MessageBody
        {
            get { return message;}
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


            Friends = new ObservableCollection<User>();
            foreach (var item in user.Friends)
            {
              Friends.Add(item);
            }

            Rooms = new ObservableCollection<Room>();
            foreach (var item in user.Rooms)
            {
                Rooms.Add(item);
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
