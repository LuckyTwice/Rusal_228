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
    /// Логика взаимодействия для Electrolysis_Bath_Empty_WND.xaml
    /// </summary>
    public partial class Electrolysis_Bath_Empty_WND : Window
    {
        public int number { get; set; }
        public int corpus { get; set; }
        public Electrolysis_Bath_Empty_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Case_Numb.Text = "Корпус " + corpus + ". Ванна " + number + ".";

        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            var load = new Report
            {
                Count = Convert.ToInt32(Alumina.Text),
                SaltCount = Convert.ToInt32(Salt.Text),
                CryoCount = Convert.ToInt32(Anode.Text),
                PersWId = 2, // надо брать откуданибудь
                Date = DateTime.Today,
                Time = DateTime.Now.TimeOfDay,
                ToId = corpus,
                ToNumber = number,
                Ready = false
            };
            using (var db = new AluminContext())
            {
                db.Reports.Add(load);
                try
                {
                    await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                    MessageBox.Show("Информация о поставке была внесена в базу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Информация не сохранилась");
                }
            }
            Close(); 
        }
    }
}
