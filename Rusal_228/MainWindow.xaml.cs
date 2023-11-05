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
            /*using (AdminContext db  = new AdminContext()) 
            {
                var phones = db.Personals.ToList();
                string message = "";
                foreach(var person in phones) 
                {
                    message += $"Имя:{person.Имя}, Фамилия:{person.Фамилия}{Environment.NewLine}";
                }
                MessageBox.Show(message,"Список");
            }*/
            
            int username = Convert.ToInt32(Login.Text);
            int password = Convert.ToInt32(Password.Password);

            if (VerifyLogin(username, password))
            {
                MessageBox.Show("11");
                int proff = GetProffFromTable2(username);
                if (VerifyProff(proff) == "Работник")
                {
                    OpenWindow1(username);
                }
                else if (VerifyProff(proff) == "Админ")
                {
                    OpenWindow2(username);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        private bool VerifyLogin(int username, int password)
        {
            using(AdminContext db = new AdminContext()) 
            {
                int verify = db.Passwords.Count(p => p.Id == username && p.Password1 == password);
                return verify > 0;
            }
            /*using (connection = new OdbcConnection(connectionString))
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
            }*/
        }
        private int GetProffFromTable2(int username)
        {
            using (AdminContext db = new AdminContext())
            {
                //Возможно использование First это костыль
                var id = db.Personals.Where(p => p.Id == username).Select(p=> p.Профессия ).First();
                return Convert.ToInt32(id);
            }
            /*using (connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT \"Профессия\" FROM \"Rusal_Shema\".\"Personal\" WHERE \"Id\" = '{username}'";

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    try
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                        MessageBox.Show("An error occurred while retrieving Proff from Table2.");
                        return -1;
                    }
                }
            }*/
        }

        private string VerifyProff(int proff)
        {
            using (AdminContext db = new AdminContext())
            {
                var prof = db.Professia.Where(p => p.Id == proff).Select(p => p.Професия).First();
                return prof.ToString();
            }
            /*using (connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT \"Профессия\" FROM \"Rusal_Shema\".\"Professia\" WHERE \"Id\" = '{proff}'";

                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    try
                    {
                        return command.ExecuteScalar()?.ToString();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception
                        MessageBox.Show("An error occurred while verifying Proff in Table3.");
                        return null;
                    }
                }
            }*/
        }
        private void OpenWindow1(int id)
        {
            AdminContext db = new AdminContext();
            var fio = db.Personals.Where(p => p.Id == id).Select(p => new { p.Фамилия, p.Имя, p.Отчество }).First();
            WorkerMain worker = new WorkerMain();
            worker.Name.Text = $"{fio.Фамилия} {fio.Имя} {fio.Отчество}";
            worker.ShowDialog();
        }
        private void OpenWindow2(int id)
        {
            AdminContext db = new AdminContext();
            var fio = db.Personals.Where(p => p.Id == id).Select(p => new {p.Фамилия, p.Имя, p.Отчество }).First();
            AdminMain admin = new AdminMain();
            admin.Name.Text = $"{fio.Фамилия} {fio.Имя} {fio.Отчество}";
            admin.ShowDialog();
        }
    }
}
