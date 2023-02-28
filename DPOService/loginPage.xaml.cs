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
using System.Data.Sql;
using System.Data;
using System.Data.Common;


namespace DPOService
{
    /// <summary>
    /// Логика взаимодействия для loginPage.xaml
    /// </summary>
    public partial class loginPage : Window
    {
        string connectionString = Properties.Settings.Default.connectionString;

        public loginPage()
        {
            InitializeComponent();
        }
        void userRole()
        {
            string UserName = loginTextbox.Text; ;

            string sql = "SELECT User_Role FROM Users WHERE Login = @un";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlParameter nameParam = new SqlParameter("@un", UserName);

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(nameParam);

            string Form_Role = command.ExecuteScalar().ToString();

            Properties.Settings.Default.User_Role = Form_Role;

            switch (Form_Role)
            {
                case "Администратор": this.Visibility = Visibility.Collapsed; MainWindow MainWindowAdmin = new MainWindow(); MainWindowAdmin.Show(); break;
                case "Редактор": this.Visibility = Visibility.Collapsed; MainWindow MainWindowEditor = new MainWindow(); MainWindowEditor.Show(); break;
                case "Участник": this.Visibility = Visibility.Collapsed; MainWindow MainWindowUser = new MainWindow(); MainWindowUser.Show(); break;
            }

            conn.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Login = @un and Password= @up";
            SqlConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar, 50);
            command.Parameters.Add("@up", SqlDbType.VarChar, 50);

            command.Parameters["@un"].Value = loginTextbox.Text;
            command.Parameters["@up"].Value = passwordTextbox.Password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                userRole(); // метод, который будет открывать разные формы в зависимости от пользователя

                Properties.Settings.Default.UserName = loginTextbox.Text;
                Properties.Settings.Default.Password = passwordTextbox.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Данные для входа не верны!","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            dbConnection.Close();
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            loginTextbox.Text = Properties.Settings.Default.UserName;
            passwordTextbox.Password = Properties.Settings.Default.Password;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Environment.Exit(0);
        }
    }
}
