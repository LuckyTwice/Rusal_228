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
    /// Логика взаимодействия для Delivery_WND.xaml
    /// </summary>
    public partial class Delivery_WND : Window
    {
        public Delivery_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new MaterialContext()) 
            {
                var marka = db.MarkaMaterials.Select(x => x.Name).ToList();
                var company = db.Companies.Select(x => x.Name).ToList();
                var unit = db.Units.Select(x => x.Name).ToList();
                var type = db.TypeMaterials.Select(x => x.Name).ToList();
                Companyy.ItemsSource = company;
                Type.ItemsSource = type;
                Type_Material.ItemsSource = type;
                Grade.ItemsSource = marka;
                Unit.ItemsSource = unit;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var db = new MaterialContext();
            int unit = db.Units.Where(p=>p.Name == Unit.SelectedItem.ToString()).Select(p=>p.Id).Single();
            int marka = db.MarkaMaterials.Where(p => p.Name == Grade.SelectedItem.ToString()).Select(p => p.Id).Single();
            int type = db.TypeMaterials.Where(p => p.Name == Type.SelectedItem.ToString()).Select(p => p.Id).Single();
            int company = db.Companies.Where(p => p.Name == Companyy.SelectedItem.ToString()).Select(p => p.Id).Single();
            int number = Convert.ToInt32(Delivery_Num.Text);
            int quant = Convert.ToInt32(Quantity.Text);
            DateTime date = Date.SelectedDate.Value;
            TimeSpan time = TimeSpan.Parse(Time.Text);
            var data = new Post
            {
                NumberPost = number,
                TypeMaterial = type,
                MarkaMaterial = marka,
                Count = quant,
                Date = date,
                Company = company,
                Unit = unit,
                Time = time
            };
            db.Posts.Add(data);
            db.SaveChanges();
            MessageBox.Show("Данные успешно внесены");
        }
    }
}
