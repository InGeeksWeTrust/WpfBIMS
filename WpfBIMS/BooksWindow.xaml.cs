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

using System.Data.SqlClient;

namespace WpfBIMS
{
    /// <summary>
    /// Interaction logic for BooksWindow.xaml
    /// </summary>
    public partial class BooksWindow : Window
    {
        public BooksWindow()
        {
            InitializeComponent();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow home = new HomeWindow();
            home.Show();
            this.Hide();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source = geekserver.database.windows.net; Initial Catalog = CIS4910C; Persist Security Info = True; User ID = admin1; Password = password1%"))
            {
                String query = "INSERT INTO dbo.Books (title, firstname, lastname, genre) VALUES (@title, @firstname, @lastname, @genre)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", txtBxTitle.Text);
                    command.Parameters.AddWithValue("@firstname", txtBxFirstName.Text);
                    command.Parameters.AddWithValue("@lastname", txtBxLastName.Text);
                    command.Parameters.AddWithValue("@genre", txtBxGenre.Text);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    MessageBox.Show("Information successfully stored!", "BIMS");
                }
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBxTitle.Text = string.Empty;
            txtBxFirstName.Text = string.Empty;
            txtBxLastName.Text = string.Empty;
            txtBxGenre.Text = string.Empty;
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
