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
    /// Логика взаимодействия для Bucket_Baths_Lower_WND.xaml
    /// </summary>
    public partial class Bucket_Baths_Lower_WND : Window
    {
        public int start { get; set; }
        public int finish { get; set; }
        public int corpus { get; set; }

        Button[] Baths;
        public Bucket_Baths_Lower_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Name_Corpus.Content = "Корпус " + (corpus +7);
            Baths = new Button[] { Corpus_1, Corpus_2, Corpus_3, Corpus_4, Corpus_5 };



            for (int i = 0; i < Math.Abs(finish - start) + 1; i++)
            {
                Baths[i].Tag = new Tuple<int>(start + i);

                Baths[i].Visibility = Visibility.Visible;
                Baths[i].Content = (start + i).ToString() + " ванна";
            }
            AddEventButton();

        }
        private void AddEventButton()
        {
            for (int i = 0; i < Baths.Length; i++)
            {
                Button button = Baths[i];
                button.Click -= Button_Click;
                button.Click += Button_Click;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;

            using (AluminContext db = new AluminContext())
            {
                var l = db.Reports.Where(p => p.ToId == corpus && p.ToNumber == number && p.PrevId != null).OrderByDescending(p => p.Id).Select(p => new Report
                {
                    Id = p.Id,
                    Time = p.Time,
                    Count = p.Count,
                    SaltCount = p.SaltCount,
                    CryoCount = p.CryoCount,
                    Ready = p.Ready,
                }).FirstOrDefault();
                bool r = false;
                if (l != null)
                {
                    r = db.Reports.Any(p => p.FromId == corpus && p.FromNumber == number && p.ToId == 7 && p.PrevId == l.Id && p.Ready==true);
                }
                if (l != null && l.Ready==true && r == false)
                {
                    // сделать проверку, что в выбранной ванне закончен процесс электролиза
                    // Если да, то
                    Bucket_Bath_WND dialog = new Bucket_Bath_WND();

                    dialog.number = number;
                    dialog.corpus = corpus;

                    dialog.Time.Text = l.Time.ToString();
                    dialog.Alumina.Text = l.Count.ToString();
                    dialog.Salt.Text = l.SaltCount.ToString();
                    dialog.Anode.Text = l.CryoCount.ToString();

                    dialog.ShowDialog();
                    // если нет, то
                    // MessageBox.Show("Ванна не готова к выгрузке", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Ванна не готова к выгрузке", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            

        }
    }
}
