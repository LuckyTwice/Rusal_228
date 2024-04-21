using Microsoft.Data.SqlClient;
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
            /*Electrolysis_WND di = new Electrolysis_WND();
            di.Show();*/
            Delivery_WND deli = new Delivery_WND();
            deli.Show();
            /* Admin_Rules_WND bucket = new Admin_Rules_WND();
             bucket.Show();*/
            /* if (Login.Text == "Admin")
             {
                 Admin_WND dialog1 = new();
                 dialog1.Show();
             }
             else
             {
                 Profession_WND dialog1 = new();
                 dialog1.Read.Items.Add("Электролизный цех");
                 dialog1.Read.Items.Add("Управление ковшами");
                 dialog1.Read.Items.Add("Управление поставкой");
                 dialog1.Show();
             }*/


            //Close();

            /*  using (var db = new AluminContext())
              {
                  bool isConnected = db.Database.CanConnect();
                  if (isConnected)
                  {
                      try
                      {
                          string username = Login.Text;
                          string password = Password.Password;
                          int id = -1;
                          id = VerifyLogin(db, username, password);
                          if (id > -1)
                          {
                              GetProffFromTable2(db, username);
                              if (GetProffFromTable2(db, username) == 1) //Админ
                              {
                                  OpenWindow1(db, id);
                              }
                              else if (GetProffFromTable2(db, username) == 0) //Сисадмин
                              {
                                  OpenWindow2(db, id);
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
                      catch (Exception)
                      {
                          MessageBox.Show("Неверно введены логин или пароль", "Ошибка");
                      }
                  }
                  else
                  {
                      MessageBox.Show("Отсутствует связь с сервером", "Ошибка");
                  }
              }*/

        }
       /* private int VerifyLogin(AluminContext db, string username, string password) //id человека
        {
            int id = db.Accounts.Where(p => p.Login == username && p.Password == password).Select(p => p.Id).Single();
            return id;
        }
        private int GetProffFromTable2(AluminContext db, string username) //id профессии
        {
            int id1 = db.Accounts.Where(p => p.Login == username).Select(p => p.Id).Single();
            int id = db.Personals.Where(p => p.Id == id1).Select(p => p.ProfId).Single();
            return id;
        }

        private string VerifyProff(AluminContext db, int proff)
        {
            var prof = db.Professions.Where(p => p.Id == proff).Select(p => p.Personals).First();
            return prof.ToString();
        }
        private void OpenWindow1(AluminContext db, int id) // открытие окна админа
        {
            var fio = db.Personals.Where(p => p.Id == id).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
            Delivery_WND admin = new Delivery_WND();
            //
            int[] windows = { 0 }; //через запрос сделать выборку из базы

            Profession_WND admin1 = new();
            admin1.Pers_Id = id;
            foreach (int window in windows)
            {
                Prof_Choice item = new Prof_Choice { Id = window };
                admin1.Read.Items.Add(item);
            }
            admin1.ShowDialog();
            //
            admin.Name.Text = $"{fio.Surname} {fio.Name} {fio.Patronymic}";
            admin.ShowDialog();
        }
        private void OpenWindow2(AluminContext db, int id) // открытие окна сисадмина
        {
            var fio = db.Personals.Where(p => p.Id == id).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
            Admin_WND sysadmin = new Admin_WND();
            sysadmin.Name.Text = $"{fio.Surname} {fio.Name} {fio.Patronymic}";
            sysadmin.ShowDialog();
        }*/

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /*private void Message(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Соединение с базой установлено");
        }*/
    }
}
