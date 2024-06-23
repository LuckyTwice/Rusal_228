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
                var persons = db.Personals.Select(p => new { Id = p.Id, Fullname = p.Surname + " " + p.Name + " " + p.Patronymic }).ToList();
                Department.ItemsSource = persons;
                Department.DisplayMemberPath = "Fullname";
            }
        }

        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Department.SelectedItem != null)
            {
                var selectedPerson = (dynamic)Department.SelectedItem;
                Admin_Employee_WND dialog = new Admin_Employee_WND();
                dialog.id = selectedPerson.Id;
                dialog.ShowDialog();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var persons = db.Personals.Where(p => p.Surname.TrimStart().StartsWith(Name.Text)).Select(p => new { Id = p.Id, Fullname = p.Surname + " " + p.Name + " " + p.Patronymic }).ToList();
                Department.ItemsSource = persons;
                Department.DisplayMemberPath = "Fullname";
            }
        }

        private void Add_Empl_Click(object sender, RoutedEventArgs e)
        {
            Admin_NewEmployee_WND dialog = new Admin_NewEmployee_WND();
            dialog.ShowDialog();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
