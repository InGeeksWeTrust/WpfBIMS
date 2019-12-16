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

namespace WpfBIMS
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow home = new HomeWindow();
            home.Show();
            this.Hide();
        }

        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            var signOut = MessageBox.Show("Do you want to log off?", "BIMS", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (signOut == MessageBoxResult.Yes)
            {
                this.Close();
                MainWindow home = new MainWindow();
                home.Show();
                MessageBox.Show("Successfully signed out.", "BIMS");
            }
        }
    }
}
