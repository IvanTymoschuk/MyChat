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
using Models;
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
            //Mvm = new MainViewModel(new UserMocks(),new MessageMocks(),new RoomMocks());
            //this.DataContext = Mvm;

            




        }



        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("lul");
        }

        
    }
}
