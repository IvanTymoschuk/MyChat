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
using MahApps.Metro.Controls;
using WPF.MockModuls;
using WPF.ViewModels.WindowViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Sign_in.xaml
    /// </summary>
    public partial class Sign_in : MetroWindow
    {
        public Sign_in()
        {
            InitializeComponent();

            var Sinvm = new Sign_inViewModel();
            this.DataContext = Sinvm;

        }
        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            StartWindow window = new StartWindow();
            this.Close();

            window.Show();
        }
    }
}
