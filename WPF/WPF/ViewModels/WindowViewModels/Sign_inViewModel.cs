using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.Commands;
using WPF.MockModuls;

namespace WPF.ViewModels.WindowViewModels
{
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
                 
                   MessageBox.Show(login);
               }));
            }
        }


    }
}
