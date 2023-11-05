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

namespace Rusal_228
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            using (AdminContext db  = new AdminContext()) 
            {
                /*var users = db.Personals.ToList();
                ///Console.WriteLine("список");
                foreach (var user in users) 
                {
                    Console.WriteLine($"{user.Id}.{user.Имя}.{user.Фамилия} - {user.Профессия}");
                }*/
                var phones = db.Personals.ToList();
                string message = "";
                foreach(var person in phones) 
                {
                    message += $"Имя:{person.Имя}, Фамилия:{person.Фамилия}{Environment.NewLine}";
                }
                MessageBox.Show(message,"Список");
            }
           /* string username = Login.Text;
            string password = Password.Password;

            if (VerifyLogin(username, password))
            {
                MessageBox.Show("11");
                int proff = GetProffFromTable2(username);
                if (VerifyProff(proff) == "Работник")
                {
                    OpenWindow1();
                }
                else if (VerifyProff(proff) == "Админ")
                {
                    OpenWindow2();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }*/
        }
        /*private bool VerifyLogin(string username, string password)
        {
            string connectionString = "Dsn=Rusal;data source=localhost;database=Rusal;user id=postgres;schema=Rusal_Schema"; // Replace with your actual connection string

            using (connection = new OdbcConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM \"Rusal_Shema\".\"Password\" WHERE \"Id\" = '{username}' AND \"Password\" = '{password}'";
                    using (OdbcCommand command = new OdbcCommand(query, connection))
                    {
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    MessageBox.Show("An error occurred while connecting to the database.");
                    return false;
                }
            }
        }
        private int GetProffFromTable2(string username)
        {
            string connectionString = "Dsn=Rusal;data source=localhost;database=Rusal;user id=postgres;schema=Rusal_Schema"; // Replace with your actual connection string

            using (connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT \"Профессия\" FROM \"Rusal_Shema\".\"Personal\" WHERE \"Id\" = '{username}'";

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {*/
                    /* try
                     {*//*
                    return Convert.ToInt32(command.ExecuteScalar());
                    *//* }*/
                    /* catch (Exception ex)
                     {
                         // Handle the exception
                         MessageBox.Show("An error occurred while retrieving Proff from Table2.");
                         return -1;
                     }*//*
                }
            }
        }

        private string VerifyProff(int proff)
        {
            string connectionString = "Dsn=Rusal;data source=localhost;database=Rusal;user id=postgres;schema=Rusal_Schema"; // Replace with your actual connection string

            using (connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT \"Профессия\" FROM \"Rusal_Shema\".\"Professia\" WHERE \"Id\" = '{proff}'";

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    *//*                try
                                    {*//*
                    return command.ExecuteScalar()?.ToString();
                    *//* }
                     catch (Exception ex)
                     {
                         // Handle the exception
                         MessageBox.Show("An error occurred while verifying Proff in Table3.");
                         return null;
                     }*//*
                }
            }
        }
        private void OpenWindow1()
        {
            WorkerMain worker = new WorkerMain();
            worker.ShowDialog();
        }
        private void OpenWindow2()
        {
            AdminMain admin = new AdminMain();
            admin.ShowDialog();
        }*/
                }
            }
