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
        
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Admin_WND dialog = new Admin_WND();
            dialog.Show();
            Close();
            /*using (var db = new AdminContext())
            {
                bool isConnected = db.Database.CanConnect();
                if (isConnected)
                {
                    try
                    {
                        int username = Convert.ToInt32(Login.Text);
                        int password = Convert.ToInt32(Password.Password);
                        if (VerifyLogin(db, username, password))
                        {
                            int proff = GetProffFromTable2(db, username);
                            if (VerifyProff(db, proff) == "Работник")
                            {
                                OpenWindow1(db, username);
                            }
                            else if (VerifyProff(db, proff) == "Админ")
                            {
                                OpenWindow2(db, username);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверно введены логин или пароль");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Логин и пароль дожны быть введены цифрами");
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует связь с сервером", "Ошибка");
                }
            }*/
           
        }
        /*private bool VerifyLogin(AdminContext db, int username, int password)
        {
                int verify = db.Passwords.Count(p => p.Id == username && p.Password1 == password);
                return verify > 0;
        }
        private int GetProffFromTable2(AdminContext db, int username)
        {
                //Возможно использование First это костыль
                var id = db.Personals.Where(p => p.Id == username).Select(p=> p.Профессия ).First();
                return Convert.ToInt32(id);
        }

        private string VerifyProff(AdminContext db, int proff)
        {
                var prof = db.Professia.Where(p => p.Id == proff).Select(p => p.Професия).First();
                return prof.ToString();
        }
        private void OpenWindow1(AdminContext db, int id)
        {
            var fio = db.Personals.Where(p => p.Id == id).Select(p => new { p.Фамилия, p.Имя, p.Отчество }).First();
            Delivery_WND worker = new Delivery_WND();
            worker.Name.Text = $"{fio.Фамилия} {fio.Имя} {fio.Отчество}";
            worker.ShowDialog();
        }
        private void OpenWindow2(AdminContext db, int id)
        {
            var fio = db.Personals.Where(p => p.Id == id).Select(p => new {p.Фамилия, p.Имя, p.Отчество }).First();
            Admin_WND admin = new Admin_WND();
            admin.Name.Text = $"{fio.Фамилия} {fio.Имя} {fio.Отчество}";
            admin.ShowDialog();
        }*/

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
