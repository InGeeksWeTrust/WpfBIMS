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
using System.Data;

namespace WpfBIMS
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        string connectionString = @"Data Source = geekserver.database.windows.net; Initial Catalog = CIS4910C; Persist Security Info = True; User ID = admin1; Password = password1%";
        public ListWindow()
        {
            InitializeComponent();
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT BookId, title, firstname, lastname, genre FROM dbo.Books";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable table = new DataTable("dbo.Books");
                sda.Fill(table);
                dataGrid1.ItemsSource = table.DefaultView;
                sda.Update(table);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
