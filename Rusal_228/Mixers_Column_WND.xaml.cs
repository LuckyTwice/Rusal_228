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
    /// Логика взаимодействия для Mixers_Column_WND.xaml
    /// </summary>
    public partial class Mixers_Column_WND : Window
    {
        Button[] Mixers;
        public int type { get; set; }

        public Mixers_Column_WND()
        {
            InitializeComponent();
            Mixers = new Button[] { Mixer1, Mixer2, Mixer3 };
            AddEventButton();
            using(var db = new AluminContext())
            {
                var list = db.Reports.Where(p => p.Ready == null && p.FromId == 7 && p.ToId == null).Select(p => new Report
                {
                    Id = p.Id,
                    FromNumber = p.FromNumber,
                    ToId = p.ToId,
                }).ToList();
                Bucket.ItemsSource = list;
            }
            UpdateListBoxData();
        }
        private void UpdateListBoxData()
        {
            using (var db = new AluminContext())
            {
                var list = db.Reports.Where(p => p.Ready == false && p.FromId == 8).Select(p => new Report
                {
                    Id = p.Id,
                    PersWId = p.PersWId,
                    FromId = p.FromId,
                    FromNumber = p.FromNumber,
                    Count = p.Count,
                    ToId = p.ToId,//наверное не надл
                    ToNumber = p.ToNumber,
                    Date = p.Date,
                    Time = p.Time,
                }).ToList();
                /*var list2 = db.Reports.Where(p => p.Ready == false && p.FromId == 7).Select(p => new Report
                {
                    Id = p.Id,
                    PersWId = p.PersWId,
                    FromId = p.FromId,
                    FromNumber = p.FromNumber,
                    Count = p.Count,
                    ToId = p.ToId,//наверное не надл
                    ToNumber = p.ToNumber,
                    Date = p.Date,
                    Time = p.Time,
                }).ToList();
                list.AddRange(list2); //подкорректировать взятие информации*/
                Documents.ItemsSource = list;
            }
        }
        private void AddEventButton()
        {
            for (int i = 0; i < Mixers.Length; i++)
            {
                Button button = Mixers[i];
                Mixers[i].Tag = new Tuple<int>(i);
                button.Click -= Button_Click;
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;
            using(AluminContext db = new AluminContext())
            {
                var l = db.Reports.Where(p => p.FromId == null && p.ToId == 8).OrderByDescending(p=>p.Id).Single();
                if (l.Ready == null)
                {
                    // сделать проверку, что миксер запущен
                    // Если да, то
                    Mixers_Column_Mixers_Full_WND dialog = new Mixers_Column_Mixers_Full_WND();

                    dialog.number = number;
                    dialog.type = type;
                    dialog.Fill.Text = db.Reports.Where(p => p.FromId == null && p.ToId == 8 && p.ToNumber == number && p.Ready == null).Select(p => p.Count).ToString();
                    dialog.Time.Text = db.Reports.Where(p => p.FromId == null && p.ToId == 8 && p.ToNumber == number && p.Ready == null).Select(p => p.Time).ToString();

                    dialog.ShowDialog();
                }
                else if (l.Ready == true)
                {
                    // если нет, то
                    Mixers_Column_Mixers_Empty_WND dialog1 = new Mixers_Column_Mixers_Empty_WND();

                    dialog1.number = number;
                    dialog1.type = type;
                    dialog1.Fill.Text = db.Reports.Where(p => p.FromId == 7 && p.ToId == 8 && p.ToNumber == number && p.Ready == null).Select(p => p.Count).Sum().ToString();
                    dialog1.Rest.Text = Convert.ToString(30000 - Convert.ToInt32(dialog1.Fill));
                    dialog1.ShowDialog();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (type == 0)
                TypeName.Content = "Столбы.";
            else
                TypeName.Content = "Чушки." ;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Mixers_Column_Mixers_WND dialog = new Mixers_Column_Mixers_WND();
            var k = (Report)Bucket.SelectedItem;
            var d = k.Id;
            dialog.id = d;
            dialog.type = type;
            dialog.ShowDialog();

        }
    }
}
