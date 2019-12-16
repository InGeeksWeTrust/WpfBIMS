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

using System.Data.SqlClient;
using System.Data;

namespace WpfBIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      async private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Database connection
            SqlConnection conn = new SqlConnection(@"Data Source = geekserver.database.windows.net; Initial Catalog = CIS4910C; Persist Security Info = True; User ID = admin1; Password = password1%");
            //DB query
            String loginQuery = "SELECT * FROM [USERS] WHERE username = '" + txtBxUsername.Text + "' and password = '" + txtBxPassword.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(loginQuery, conn);
            //This will create the data table where the user login information is to be stored.
            DataTable userTable = new DataTable();
            sda.Fill(userTable);
            if (userTable.Rows.Count == 1)
            {
                HomeWindow home = new HomeWindow();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect. Please try again.", "BIMS");
            }
        }
    }
}
