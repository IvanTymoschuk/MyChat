using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Models;
using MahApps.Metro.Controls;
using WPF.MockModuls;
using WPF.ViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainViewModel Mvm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Mvm = new MainViewModel(new UserMocks());
            this.DataContext = Mvm;

            //List<Room> rooms = new List<Room>();
            //rooms.Add(new Room() { Name = "Room1", IsPublish = false});

            //List<Message> messages = new List<Message>();
            //messages.Add(new Message() { Body = "Hello", DateTimeSended = DateTime.Now, Sender = users[0], Room = rooms[0] });




        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("lul");
        }

    }
}
