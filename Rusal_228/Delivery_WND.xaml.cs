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
    /// Логика взаимодействия для Delivery_WND.xaml
    /// </summary>
    public partial class Delivery_WND : Window
    {
        public Delivery_WND()
        {
            InitializeComponent();
            using (var db = new AluminContext())
            {
                for(int i = 0; i < 3; i++)
                {
                    Type.Items.Add(db.GeneralStorages.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                    Type_Material.Items.Add(db.GeneralStorages.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                }
                for(int i = 0;i < 6; i++)
                {
                    Direction_Material.Items.Add(db.Places.Where(p=>p.Id==i).Select(p=>p.Name).Single().ToString());
                }
                var list = db.Reports.Where(p => p.Ready == false).Select(p => new { p.PostNumb, p.Id}).ToList();
                foreach(var i in list)
                {
                    Documents.Items.Add(list);
                }
            }
            /*Type.Items.Add("Фторсоли");
            Type_Material.Items.Add("Аннодная масса");
            Direction_Material.Items.Add("Цех №12");*/
            //Documents.Items.Add("Отчет о поставке фторсолей");
            //Documents.Items.Add("Отчет о снабжении цеха №10");
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
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
                db.Reports.Add(postav);
                try
                {
                    await db.SaveChangesAsync();
                    MessageBox.Show("Информация о поставке была внесена в базу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Информация не сохранилась");
                }
            }
        }

        private void Documents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Documents.Items.Count>0)
            {
                Delivery_Report_WND dialog = new Delivery_Report_WND();
                var post = (Report)Documents.SelectedItem;
                using(var db = new AluminContext())
                {
                    Delivery_Num.Text = post.PostNumb.ToString();
                }
                dialog.ShowDialog();
            }
        }
    }
}
