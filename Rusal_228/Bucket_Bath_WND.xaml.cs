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
    /// Логика взаимодействия для Bucket_Bath_WND.xaml
    /// </summary>
    public partial class Bucket_Bath_WND : Window
    {
        public int number { get; set; }
        public int corpus { get; set; }
        public Bucket_Bath_WND()
        {
            InitializeComponent();
            Update_Buck();
            
        }
        private void Update_Buck()
        {
            using (AluminContext db = new AluminContext())
            {
                var l = db.Reports.Where(p => (p.FromId == 7 || p.ToId == 7) && !p.Ready).Select(p => p.FromId == 7 ? p.FromNumber : p.ToNumber).ToList();
                for (int i = 1; i < 25; i++)
                {
                    if (!l.Contains(i))
                        Bucket.Items.Add(i);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Case_Numb.Text = "Корпус " + (corpus +7)+ ". Ванна "+number+".";
        }

        private async void Stop_Click(object sender, RoutedEventArgs e)
        {
            var buckLoad = new Report
            {
                Count = Convert.ToInt32(Alumina.Text) + Convert.ToInt32(Salt.Text) + Convert.ToInt32(Anode.Text),
                PersWId = 2, // надо брать откуданибудь
                Date = DateTime.Today,
                Time = DateTime.Now.TimeOfDay,
                FromId=corpus,
                FromNumber=number,
                ToId = 7,
                ToNumber = Convert.ToInt32(Bucket.SelectedItem),
                Ready = false,
            };
            using (var db = new AluminContext())
            {
                buckLoad.PrevId=db.Reports.Where(p => p.ToId == corpus && p.ToNumber == number && p.PrevId != null && p.Ready).OrderByDescending(p => p.Id).Select(p=>p.Id).First();
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
