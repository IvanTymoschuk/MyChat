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
        public ObservableCollection<User> Users { get; set; }

        public ObservableCollection<Message> Messages { get; set; }

        public ObservableCollection<Room> Rooms  { get; set; }



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

       


        public string Message { get; set; }

        public MainViewModel(IMockData<User> usermock,IMockData<Message>messagemock,IMockData<Room>roommock)
        {
            Users = new ObservableCollection<User>();
            foreach(var item in usermock.GetMock())
            {
                Users.Add(item);
            }

            Messages = new ObservableCollection<Message>();
            foreach (var item in messagemock.GetMock())
            {
                Messages.Add(item);
            }

            Rooms = new ObservableCollection<Room>();
            foreach (var item in roommock.GetMock())
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
                   MessageBox.Show((obj as User).Name);
               }));
            }
        }


    }
}
