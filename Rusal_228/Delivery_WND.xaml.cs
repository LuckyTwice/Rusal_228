using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Delivery_WND.xaml
    /// </summary>
    public partial class Delivery_WND : Window
    {
        public Delivery_WND()
        {
            InitializeComponent();
            using (var db = new AluminContext()) //Можно оптимизировать циклы используя плюшки  в запросах
            {
                for(int i = 0; i < 3; i++)
                {
                    Type.Items.Add(db.Materials.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                    Type_Material.Items.Add(db.Materials.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                }
                for(int i = 0;i < 6; i++)
                {
                    Direction_Material.Items.Add(db.Places.Where(p=>p.Id==i).Select(p=>p.Name).Single().ToString());
                }
                UpdateListBoxData();
            }
            /*Type.Items.Add("Фторсоли");
            Type_Material.Items.Add("Аннодная масса");
            Direction_Material.Items.Add("Цех №12");*/
            //Documents.Items.Add("Отчет о поставке фторсолей");
            //Documents.Items.Add("Отчет о снабжении цеха №10");
        }
        private void UpdateListBoxData()
        {
            using (var db = new AluminContext())
            {
                var list = db.Reports.Where(p => p.Ready == false && (p.FromId == null || p.FromId == 2)).Select(p => new Report
                {
                    PostNumb = p.PostNumb,
                    Id = p.Id,
                    TypeId = p.TypeId,
                    PersWId = p.PersWId,
                    FromId = p.FromId,
                    ToId = p.ToId
                }).ToList();
                Documents.ItemsSource = list;
            }
        }
        private void When_Window_Closed(object sender, EventArgs e)
        {
            UpdateListBoxData();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var postav = new Report
            {
                PostNumb = Convert.ToInt32(Delivery_Num.Text),
                TypeId = Type.SelectedIndex,
                Count = Convert.ToInt32(Quantity.Text),
                ToId = 6,
                PersWId = 2,/// двойка взята для пример, реализовать взятие айди из проги
                Ready = false,
                Date = Date.SelectedDate.Value,
                Time = TimeSpan.Parse(Time.Text)
            };
            using (var db = new AluminContext())
            {
                db.Reports.Add(postav);
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
        }

        private void Documents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           /* if (Documents.Items.Count > 0 && Documents.SelectedIndex > -1)
            {
                var post = (Report)Documents.SelectedItem;
                if (post != null)
                {
                    if (post.ToId == 6)
                    {
                        Delivery_Report_WND dialog = new Delivery_Report_WND(post.Id);
                        dialog.Delivery_Num.Text = post.PostNumb.ToString();
                        using (var db = new AluminContext())
                        {
                            dialog.Type.Text = db.GeneralStorages.Where(p => p.Id == post.TypeId).Select(p => p.Name).Single().ToString();
                            dialog.Quantity.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Count).Single().ToString();
                            dialog.Date.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Date).Single().ToString(); // дата поступает вместе со временем, исправить
                            dialog.Time.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Time).Single().ToString();
                            var personal = db.Personals.Where(p => p.Id == post.PersWId).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
                            dialog.NameTake.Text = $"{personal.Surname} {personal.Name} {personal.Patronymic}";
                        }
                        dialog.Closed += When_Window_Closed;
                        // сделать перенос фио в окно отчета
                        dialog.ShowDialog();
                    }
                    else
                    {
                        Delivery_Supply_Report_WND dialog = new Delivery_Supply_Report_WND(post.Id);
                        using (var db = new AluminContext())
                        {
                            dialog.Type_Material.Text = db.GeneralStorages.Where(p => p.Id == post.TypeId).Select(p => p.Name).Single().ToString();
                            dialog.Direction_Material.Text = db.Places.Where(p => p.Id == post.ToId).Select(p => p.Name).Single().ToString();
                            dialog.Quantity_Material.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Count).Single().ToString();
                            dialog.Date.Text = db.Reports.Where(p => p.Id == post.TypeId).Select(p => p.Date).Single().ToString(); // дата поступает вместе со временем, исправить
                            dialog.Time.Text = db.Reports.Where(p => p.Id == post.Id).Select(p => p.Time).Single().ToString();
                            var personal = db.Personals.Where(p => p.Id == post.PersWId).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
                            dialog.NameSend.Text = $"{personal.Surname} {personal.Name} {personal.Patronymic}";
                        }
                        dialog.Closed += When_Window_Closed;
                        // сделать перенос фио в окно отчета
                        dialog.ShowDialog();
                    }
                }
            }*/
        }
        /*  public void UpdateComponent(object sender, EventArgs e)
          {
              this.Documents.InvalidateVisual(); //придумать как работает метод
          }*/

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            var send = new Report
            {
                TypeId = Type_Material.SelectedIndex,
                FromId = 6, // также можно оставить это поле пустым, разницы не будет
                ToId = Direction_Material.SelectedIndex,
                Count = Convert.ToInt32(Quantity_Material.Text),
                Date = DateTime.Today,
                Time = DateTime.Now.TimeOfDay,
                PersWId = 2,//поменять получение
                Ready = false
            };
            using (var db = new AluminContext())
            {
                db.Reports.Add(send);
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
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Alert_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
