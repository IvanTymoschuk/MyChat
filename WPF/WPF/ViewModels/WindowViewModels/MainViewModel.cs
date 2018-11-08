using Models;
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

        public MainViewModel(IMockData<User> mock)
        {
            Users = new ObservableCollection<User>();
            foreach(var item in mock.GetMock())
            {
                Users.Add(item);
            }
            ActiveUsers = Users.Count;
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
