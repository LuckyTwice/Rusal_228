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

namespace Rusal_228
{
    /// <summary>
    /// Логика взаимодействия для Admin_Rules_WND.xaml
    /// </summary>
    public partial class Admin_Rules_WND : Window
    {
        public Admin_Rules_WND()
        {
            InitializeComponent();

            using (var db = new AluminContext())
            {
                var persons = db.Personals.Select(p => new {Fullname = p.Surname + " " + p.Name + " " + p.Patronymic + " " }).ToList();
                Department.ItemsSource = persons.Select(p=>p.Fullname).ToList();
            }
        }

        private void Add_Empl_Click(object sender, RoutedEventArgs e)
        {
            Admin_NewEmployee_WND dialog = new Admin_NewEmployee_WND();
            dialog.ShowDialog();
        }

        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Admin_Employee_WND dialog = new Admin_Employee_WND();
            dialog.ShowDialog();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Department.Items.Clear();
            Department.Items.Add("Петренко Максим Леонидович");

            //Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*Department.Items.Add("Комаровский Ярослав Сергеевич");
            Department.Items.Add("Курьян Илья Сергеевич");
            Department.Items.Add("Петренко Максим Леонидович");*/
        }
    }
}
