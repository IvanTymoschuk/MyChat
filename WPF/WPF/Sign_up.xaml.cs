using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using WPF.ViewModels.WindowViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Sign_up.xaml
    /// </summary>
    public partial class Sign_up : MetroWindow
    {
        public Sign_up()
        {
            InitializeComponent();

            var Supvm = new Sign_upViewModel();
            this.DataContext = Supvm;
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            StartWindow window=new StartWindow();
            this.Close();

            window.Show();
        }

       
    }
}
