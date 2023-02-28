using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data.Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Windows.Documents;

namespace DPOService
{
    public partial class MainWindow : Window
    {

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string Form_Role = Properties.Settings.Default.User_Role;
            if (Form_Role == "Администратор")
            {
                addButton.IsEnabled = true;
                addButton.IsEnabled = true;

                addButton.Visibility = Visibility.Visible;
                actions.Visibility = Visibility.Visible;
            }
            if (Form_Role == "Редактор")
            {
                addButton.IsEnabled = true;
                addButton.IsEnabled = true;

                addButton.Visibility = Visibility.Visible;
                actions.Visibility = Visibility.Visible;
            }
            if (Form_Role == "Участник")
            {
                addButton.IsEnabled = false;
                addButton.IsEnabled = false;

                addButton.Visibility = Visibility.Hidden;
                actions.Visibility = Visibility.Hidden;
            }
            DBLoad();
            WeeklyStatisticUpdate();
            AutoCheckDays();
            DBCount();
        }

        string connectionString = Properties.Settings.Default.connectionString;
        int currentRowIndex;
        public MainWindow()
        {
            InitializeComponent();
			//Пример для коммита!
			//Пример для второго коммита!
        }

        private bool IsMaximize = false;

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            
        }

        public void DBLoad()
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT ID, CONCAT(SURNAME,' ',NAME,' ',MIDDLENAME)FULLNAME, NAMEORGANIZATION, PHONENUMBER, EDUPROGRAM, EDUDATE, EXPCERTIFICATE FROM main";                        
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);
            TabelMain.ItemsSource = dt.AsDataView();
            dbConnection.Close();

        }

        public void AutoCheckDays()
        {
            DateTime today = DateTime.Today;
            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                SqlConnection dbConnection = new SqlConnection(connectionString);

                dbConnection.Open();
                string query = "SELECT AlreadyChecked FROM AutoCheckDay";
                SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
                adapter.Fill(dt);
                dbConnection.Close();

                string result = dt.Rows[0][0].ToString();

                if (result == "Нет")
                {
                    SqlConnection dbConnection1 = new SqlConnection(connectionString);

                    // обнуляем
                    dbConnection1.Open();
                    string query1 = $"UPDATE AutoCheckDay SET AlreadyChecked = 'Да'";
                    SqlCommand dbCommand1 = new SqlCommand(query1, dbConnection1);
                    dbCommand1.ExecuteNonQuery();

                    string query4 = $"UPDATE DayWeekAdded SET AddedCount = '0'";
                    SqlCommand dbCommand4 = new SqlCommand(query4, dbConnection1);
                    dbCommand4.ExecuteNonQuery();

                    dbConnection1.Close();
                }
            }
            else
            {
                SqlConnection dbConnection2 = new SqlConnection(connectionString);

                dbConnection2.Open();
                string query2 = $"UPDATE AutoCheckDay SET AlreadyChecked = 'Нет'";
                SqlCommand dbCommand2 = new SqlCommand(query2, dbConnection2);
                dbCommand2.ExecuteNonQuery();

                dbConnection2.Close();
            }
        }

        public void AddedCountWeekly()
        {
            string dayweek = "";
            DateTime today = DateTime.Today;
            if (today.DayOfWeek == DayOfWeek.Monday)
                dayweek = "Понедельник";
            if (today.DayOfWeek == DayOfWeek.Tuesday)
                dayweek = "Вторник";
            if (today.DayOfWeek == DayOfWeek.Wednesday)
                dayweek = "Среда";
            if (today.DayOfWeek == DayOfWeek.Thursday)
                dayweek = "Четверг";
            if (today.DayOfWeek == DayOfWeek.Friday)
                dayweek = "Пятница";
            if (today.DayOfWeek == DayOfWeek.Saturday)
                dayweek = "Суббота";
            if (today.DayOfWeek == DayOfWeek.Sunday)
                dayweek = "Воскресенье";

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT AddedCount FROM DayWeekAdded WHERE DayWeek = '{dayweek}'";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);

            int result = Convert.ToInt32(dt.Rows[0][0]);

            string query2 = $"UPDATE DayWeekAdded SET AddedCount = '{result + 1}' WHERE DayWeek = '{dayweek}'";
            SqlCommand dbCommand2 = new SqlCommand(query2, dbConnection);
            dbCommand2.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void WeeklyStatisticUpdate()
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT DayWeek, AddedCount FROM DayWeekAdded";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);

            MondayNum.Text = dt.Rows[0][1].ToString();
            TuesdayNum.Text = dt.Rows[1][1].ToString();
            WednesdayNum.Text = dt.Rows[2][1].ToString();
            ThursdayNum.Text = dt.Rows[3][1].ToString();
            FridayNum.Text = dt.Rows[4][1].ToString();
            SaturdayNum.Text = dt.Rows[5][1].ToString();
            SundayNum.Text = dt.Rows[6][1].ToString();

            int summWeeklyAdded = Convert.ToInt32(MondayNum.Text) + Convert.ToInt32(TuesdayNum.Text) + Convert.ToInt32(WednesdayNum.Text) + Convert.ToInt32(ThursdayNum.Text) + Convert.ToInt32(FridayNum.Text) + Convert.ToInt32(SaturdayNum.Text) + Convert.ToInt32(SundayNum.Text);
            // 250 = 100%
            //double sssd = Math.Round((Convert.ToDouble(MondayNum.Text) / summWeeklyAdded) * 250);
            //System.Windows.MessageBox.Show(sssd.ToString());
            MondayGraph.Height = Math.Round((Convert.ToDouble(MondayNum.Text) / summWeeklyAdded) * 250);
            TuesdayGraph.Height = Math.Round((Convert.ToDouble(TuesdayNum.Text) / summWeeklyAdded) * 250);
            WednesdayGraph.Height = Math.Round((Convert.ToDouble(WednesdayNum.Text) / summWeeklyAdded) * 250);
            ThursdayGraph.Height = Math.Round((Convert.ToDouble(ThursdayNum.Text) / summWeeklyAdded) * 250);
            FridayGraph.Height = Math.Round((Convert.ToDouble(FridayNum.Text) / summWeeklyAdded) * 250);
            SaturdayGraph.Height = Math.Round((Convert.ToDouble(SaturdayNum.Text) / summWeeklyAdded) * 250);
            SundayGraph.Height = Math.Round((Convert.ToDouble(SundayNum.Text) / summWeeklyAdded) * 250);
            // 2.5 = 1% MondayGraph




        }

        public void DBSearchQuery(string SearchKey)
        {
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT ID, CONCAT(SURNAME,' ',NAME,' ',MIDDLENAME)FULLNAME, NAMEORGANIZATION, PHONENUMBER, EDUPROGRAM, EDUDATE, EXPCERTIFICATE FROM main WHERE ID LIKE '{search.Text}%' OR SURNAME LIKE '{search.Text}%'";                           
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(dt);
            TabelMain.ItemsSource = dt.AsDataView();
            dbConnection.Close();

        }

        public void DBCount()
        {
            
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT Count(*) FROM main";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            int count = (Int32)dbCommand.ExecuteScalar();

            CountUsers.Number = count.ToString();
            //MaxYvalue.MaxValue = count;

            dbConnection.Close();
            

        }

       

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ExitButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Environment.Exit(0);
        }

        private void Logo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ekb-dpo.ru");
        }
      
        private void delButton1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Вы точно хотите удалить запись?","Уведомление!",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                DataRowView row = TabelMain.SelectedItem as DataRowView;
                string index = row.Row.ItemArray[0].ToString();

                SqlConnection dbConnection = new SqlConnection(connectionString);

                dbConnection.Open();
                string query = $"DELETE FROM main WHERE ID LIKE {index}";
                SqlCommand dbCommand = new SqlCommand(query, dbConnection);
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();

                DBCount();
                DBSearchQuery(search.Text);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addPage.Visibility = Visibility.Visible;
            MainPage.Visibility = Visibility.Hidden;
        }

        private void TabelMain_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void search_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DBSearchQuery(search.Text);
            }
        }

        private void addButtonConf_Click(object sender, RoutedEventArgs e)
        {
            string currDate = DateTime.Today.ToString("dd-MM-yyyy");
            string ClientSurName = addSurNameTextBox.Text;
            string ClientName = addNameTextBox.Text;
            string ClientMiddleName = addMiddleNameTextBox.Text;
            string ClientNameOrg = addOrganizationTextBox.Text;
            string ClientPhone = addPhoneNumberTextBox.Text;
            string ClientEduProg = addEduProgramTextBox.Text;
            string ClientEduDate = addEduDateTextBox.Text;
            string ClientExpDate = addExpDateTextBox.Text;

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"INSERT INTO main (SURNAME, NAME, MIDDLENAME, NAMEORGANIZATION, PHONENUMBER, EDUPROGRAM, EDUDATE, EXPCERTIFICATE, logs) VALUES ('{ClientSurName}','{ClientName}','{ClientMiddleName}','{ClientNameOrg}','{ClientPhone}','{ClientEduProg}','{ClientEduDate}','{ClientExpDate}','{currDate + " Пользователь : " + Properties.Settings.Default.UserName}')";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            dbCommand.ExecuteNonQuery();


            addNameTextBox.Text = "";
            addSurNameTextBox.Text = "";
            addMiddleNameTextBox.Text = "";
            addOrganizationTextBox.Text = "";
            addPhoneNumberTextBox.Text = "";
            addEduProgramTextBox.Text = "";
            addEduDateTextBox.Text = "";
            addExpDateTextBox.Text = "";


            dbConnection.Close();
            DBLoad();
            DBCount();
            AddedCountWeekly();
            WeeklyStatisticUpdate();
        }

        private void addButtonBack_Click(object sender, RoutedEventArgs e)
        {
            addPage.Visibility = Visibility.Hidden;
            MainPage.Visibility = Visibility.Visible;

            addNameTextBox.Text = "";
            addSurNameTextBox.Text = "";
            addMiddleNameTextBox.Text = "";
            addOrganizationTextBox.Text = "";
            addPhoneNumberTextBox.Text = "";
            addEduProgramTextBox.Text = "";
            addEduDateTextBox.Text = "";
            addExpDateTextBox.Text = "";
        }

        string indexedit;
        private void editButton1_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = TabelMain.SelectedItem as DataRowView;
            indexedit = row.Row.ItemArray[0].ToString();

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT SURNAME, NAME, MIDDLENAME, NAMEORGANIZATION, PHONENUMBER, EDUPROGRAM, EDUDATE, EXPCERTIFICATE, logs FROM main WHERE ID LIKE {indexedit}";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            dbCommand.ExecuteNonQuery();

            DataTable querrytabel = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            adapter.Fill(querrytabel);

            dbConnection.Close();

            string ClientName = querrytabel.Rows[0][1].ToString();
            string ClientSurName = querrytabel.Rows[0][0].ToString();
            string ClientMiddleName = querrytabel.Rows[0][2].ToString();
            string ClientNameOrg = querrytabel.Rows[0][3].ToString();
            string ClientPhone = querrytabel.Rows[0][4].ToString();
            string ClientEduProg = querrytabel.Rows[0][5].ToString();
            string ClientEduDate = querrytabel.Rows[0][6].ToString();
            string ClientExpDate = querrytabel.Rows[0][7].ToString();
            string ClientLogs = querrytabel.Rows[0][8].ToString();


            editNameTextBox.Text = ClientName;
            editSurNameTextBox.Text = ClientSurName;
            editMiddleNameTextBox.Text = ClientMiddleName;
            editOrganizationTextBox.Text = ClientNameOrg;
            editPhoneNumberTextBox.Text = ClientPhone;
            editEduProgramTextBox.Text = ClientEduProg;
            editEduDateTextBox.Text = ClientEduDate;
            editExpDateTextBox.Text = ClientExpDate;
            logsadd.Text = "Запись добавили: " + ClientLogs;
            editPage.Visibility = Visibility.Visible;
            MainPage.Visibility = Visibility.Hidden;

        }

        private void editButtonBack_Click(object sender, RoutedEventArgs e)
        {
            editPage.Visibility = Visibility.Hidden;
            MainPage.Visibility = Visibility.Visible;

            editNameTextBox.Text = "";
            editSurNameTextBox.Text = "";
            editMiddleNameTextBox.Text = "";
            editOrganizationTextBox.Text = "";
            editPhoneNumberTextBox.Text = "";
            editEduProgramTextBox.Text = "";
            editEduDateTextBox.Text = "";
            editExpDateTextBox.Text = "";
        }

        private void editButtonConf_Click(object sender, RoutedEventArgs e)
        {
            string ClientName = editNameTextBox.Text;
            string ClientSurName = editSurNameTextBox.Text;
            string ClientMiddleName = editMiddleNameTextBox.Text;
            string ClientNameOrg = editOrganizationTextBox.Text;
            string ClientPhone = editPhoneNumberTextBox.Text;
            string ClientEduProg = editEduProgramTextBox.Text;
            string ClientEduDate = editEduDateTextBox.Text;
            string ClientExpDate = editExpDateTextBox.Text;

            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();
            string query = $"UPDATE main SET SURNAME = '{ClientSurName}', NAME = '{ClientName}', MIDDLENAME = '{ClientMiddleName}', NAMEORGANIZATION = '{ClientNameOrg}', PHONENUMBER = '{ClientPhone}', EDUPROGRAM = '{ClientEduProg}', EDUDATE = '{ClientEduDate}', EXPCERTIFICATE = '{ClientExpDate}' WHERE ID LIKE '{indexedit}'";
            SqlCommand dbCommand = new SqlCommand(query, dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
            DBLoad();

        }

        private void StatisticPageButton_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
