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
using System.Xml.Linq;

namespace Rusal_228
{
    /// <summary>
    /// Логика взаимодействия для Bucket_Bucket_WND.xaml
    /// </summary>
    public partial class Bucket_Bucket_WND : Window
    {
        public int number { get; set; }

        public Bucket_Bucket_WND()
        {
            InitializeComponent();
            using (AluminContext db = new AluminContext())
            {
                var l = db.Places.Where(p => p.Id == 8 || p.Id == 9).Select(p => new Place
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList();
                Bucket.ItemsSource = l;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Bucket_Numb.Text = "Ковш "+ (number+1)+".";
        }

        private async void Stop_Click(object sender, RoutedEventArgs e)
        {
            var buckLoad = new Report
            {
                Count = Convert.ToInt32(Weight.Text),
                PersWId = 2, // надо брать откуданибудь
                Date = DateTime.Today,
                Time = DateTime.Now.TimeOfDay,
                FromId = 7,
                FromNumber = number,
                ToId = Bucket.SelectedIndex+8,
                Ready = false,
            };
            using (var db = new AluminContext())
            {
                db.Reports.Add(buckLoad);
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
