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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.Show();
            this.Hide();
        }

        private void BtnStorage_Click(object sender, RoutedEventArgs e)
        {
            BooksWindow books = new BooksWindow();
            books.Show();
            this.Hide();
        }

        private void BtnList_Click(object sender, RoutedEventArgs e)
        {
            ListWindow list = new ListWindow();
            list.Show();
            this.Hide();
        }

        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            var signOut = MessageBox.Show("Do you want to log off?", "BIMS", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(signOut == MessageBoxResult.Yes)
            {
                this.Close();
                MainWindow home = new MainWindow();
                home.Show();
                MessageBox.Show("Successfully signed out.", "BIMS");
            }
    
        }
    }
}
