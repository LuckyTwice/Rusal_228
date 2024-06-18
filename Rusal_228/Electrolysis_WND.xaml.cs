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
    /// Логика взаимодействия для Electrolysis_WND.xaml
    /// </summary>
    public partial class Electrolysis_WND : Window
    {
        private Button[] Baths;
        public int corpus { get; set; }

        public Electrolysis_WND()
        {
            InitializeComponent();
            /*Documents.Items.Add("Отчет о получении сырья");
            Documents.Items.Add("Отчет о загрузке 14 ванны");
            Documents.Items.Add("Отчет об окончании электролиза в 14 ванной");*/
            using (var db = new AluminContext())
            {
                Alumina.Text = db.GeneralStorages.Where(p => p.TypeId == 0 && p.PlacesId== corpus).Select(p => p.Count).Single().ToString();
                Salt.Text = db.GeneralStorages.Where(p => p.TypeId == 2  && p.PlacesId == corpus).Select(p => p.Count).Single().ToString();
                Anode.Text = db.GeneralStorages.Where(p => p.TypeId == 1 && p.PlacesId == corpus).Select(p => p.Count).Single().ToString();
            }
            UpdateListBoxData();
        }
        private void UpdateListBoxData()
        {
            using (var db = new AluminContext())
            {
                var list = db.Reports.Where(p => !p.Ready && new int?[] { 0, 1, 2, 3, 4, 5 }.Contains(p.ToId) && p.PrevId!=null).Select(p => new Report //сделать привязку к цеху ToId==corpus
                {
                    Id = p.Id,
                    TypeId = p.TypeId,
                    FromId = p.FromId,
                    FromNumber = p.FromNumber,
                    ToId = p.ToId,
                    ToNumber = p.ToNumber
                }).ToList();//проверить какие данные пихать в list
                Documents.ItemsSource = list;
            }
        }
        private void When_Window_Closed(object sender, EventArgs e)
        {
            UpdateListBoxData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Baths = new Button[] { Corpus_1, Corpus_2, Corpus_3, Corpus_4, Corpus_5, Corpus_6, Corpus_7, Corpus_8, Corpus_9, Corpus_10, Corpus_11, Corpus_12, Corpus_13, Corpus_14, Corpus_15, Corpus_16, Corpus_17, Corpus_18, Corpus_19, Corpus_20 };

            int BathCount = 97;

            int change = (int)Math.Ceiling((double)BathCount / Baths.Length);

            for (int j = 0; j < Baths.Length; j++)
            {
                if (change * j + 1 > BathCount)
                    Baths[j].Visibility = Visibility.Hidden;
                else
                if (change * j + 1 == BathCount)
                {
                    Baths[j].Content = (change * j + 1).ToString() + " ванна";
                    Baths[j].Tag = new Tuple<int, int>(change * j + 1, 0);
                }
                else
                if (change * (1 + j) > BathCount)
                {
                    Baths[j].Content = (change * j + 1).ToString() + " - " + (BathCount).ToString() + " ванны";
                    Baths[j].Tag = new Tuple<int, int>(change * j + 1, BathCount);
                }
                else
                {
                    Baths[j].Content = (change * j + 1).ToString() + " - " + (change * (1 + j)).ToString() + " ванны";
                    Baths[j].Tag = new Tuple<int, int>(change * j + 1, change * (1 + j));
                }
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
            Tuple<int, int> tag = (Tuple<int, int>)button.Tag;
            int start = tag.Item1;
            int finish = tag.Item2;

            
            Electrolysis_Bath_WND dialog = new Electrolysis_Bath_WND();

            dialog.start = start;
            dialog.finish = finish;
            dialog.corpus = 10;
            //dialog.corpus = corpus;

            dialog.ShowDialog();
            

        }

        private void Documents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Documents.Items.Count > 0 && Documents.SelectedIndex > -1)
            {
                var post = (Report)Documents.SelectedItem;
                if (post != null)
                {
                    if (post.FromId == 6)
                    {
                        Electrolysis_Report_Come_WND dialog = new Electrolysis_Report_Come_WND(post.Id);
                        using (var db = new AluminContext())
                        {
                            //dialog.Type_Material.Text = db.Materials.Where(p => p.Id == post.TypeId).Select(p => p.Name).Single().ToString();
                            dialog.Quantity_Material.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Count).Single().ToString();
                            dialog.Date.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Date).Single().ToString(); 
                            dialog.Time.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Time).Single().ToString();
                            var personal = db.Personals.Where(p => p.Id == post.PersWId).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
                            dialog.NameWrite.Text = $"{personal.Surname} {personal.Name} {personal.Patronymic}";
                        }
                        dialog.Closed += When_Window_Closed;
                        // сделать перенос фио в окно отчета
                        dialog.ShowDialog();
                    }
                    else if (post.FromId==null && post.ToNumber!=null)
                    {
                        /*Electrolysis_Report_Load_WND dialog = new Electrolysis_Report_Load_WND(post.Id);
                        using (var db = new AluminContext())
                        {
                            var place = db.Reports.Where(p => p.Id == post.Id).Select(p => new { p.ToId, p.ToNumber }).Single();
                            dialog.Corpus_Bath.Text = $"Корпус {place.ToId} ванна {place.ToNumber}";
                            dialog.Alumina.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Count).Single().ToString();
                            dialog.Salt.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.SaltCount).Single().ToString();
                            dialog.Anode.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.CryoCount).Single().ToString();
                            dialog.Date.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Date).Single().ToString(); // дата поступает вместе со временем, исправить
                            dialog.Time.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Time).Single().ToString();
                            var personal = db.Personals.Where(p => p.Id == post.PersWId).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
                            dialog.NameWrite.Text = $"{personal.Surname} {personal.Name} {personal.Patronymic}";
                        }
                        dialog.Closed += When_Window_Closed;
                        // сделать перенос фио в окно отчета
                        dialog.ShowDialog();*/
                    }
                    else
                    {
                       /* Electrolysis_Report_Unload_WND dialog = new Electrolysis_Report_Unload_WND(post.Id);
                        using (var db = new AluminContext())
                        {
                            var place = db.Reports.Where(p => p.Id == post.Id).Select(p => new { p.ToId, p.ToNumber }).Single();
                            dialog.Corpus_Bath.Text = $"Корпус {place.ToId} ванна {place.ToNumber}";
                            var component = db.Reports.Where(p => p.ToId == post.Id).Select(p => new { p.Count, p.CryoCount, p.SaltCount }).Single();
                            dialog.Components.Text =$"Глинозем = {component.Count} кг, фторсоли = {component.SaltCount} кг, криолит = {component.CryoCount} кг";
                            dialog.Date.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Date).Single().ToString(); // дата поступает вместе со временем, исправить
                            dialog.Time.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Time).Single().ToString();
                            var personal = db.Personals.Where(p => p.Id == post.PersWId).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
                            dialog.NameWrite.Text = $"{personal.Surname} {personal.Name} {personal.Patronymic}";
                        }
                        dialog.Closed += When_Window_Closed;
                        // сделать перенос фио в окно отчета
                        dialog.ShowDialog();*/
                    }
                }
            }
        }
    }
}
