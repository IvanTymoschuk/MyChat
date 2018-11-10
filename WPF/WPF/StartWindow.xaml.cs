using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : MetroWindow
    {
        public StartWindow()
        {
            InitializeComponent();

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Sign_in window=new Sign_in();
            this.Close();
            Application.Current.MainWindow = window;
            window.ShowDialog();
            
        }


        private void BtnUp_OnClick(object sender, RoutedEventArgs e)
        {
            Sign_up window = new Sign_up();
            this.Close();
            Application.Current.MainWindow = window;
            window.ShowDialog();
        }
    }
}
