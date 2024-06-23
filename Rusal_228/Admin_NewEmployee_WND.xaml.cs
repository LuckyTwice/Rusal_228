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
    /// Логика взаимодействия для Admin_NewEmployee_WND.xaml
    /// </summary>
    public partial class Admin_NewEmployee_WND : Window
    {
        public Admin_NewEmployee_WND()
        {
            InitializeComponent();
            using (var db = new AluminContext())
            {
                var Proff = db.Professions.Select(p => new { Profession = p.Name }).ToList();
                Rules.ItemsSource = Proff.Select(p => p.Profession).ToList();
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var postav = new Personal
            {
                Surname = Surname.Text,
                Name = Name.Text,
                Patronymic = Mid_Name.Text,
                ProfId = Rules.SelectedIndex
            };
            using (var db = new AluminContext())
            {
                db.Personals.Add(postav);
                try
                {
                    await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                    MessageBox.Show("Информация о работнике была внесена в базу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Информация не сохранилась");
                }
            }
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
