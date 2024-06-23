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
    /// Логика взаимодействия для Admin_Stat_WND.xaml
    /// </summary>
    public partial class Admin_Stat_WND : Window
    {
        public Admin_Stat_WND()
        {
            InitializeComponent();
            using (var db = new AluminContext())
            {
                for (int i = 0; i < 3; i++)
                {
                    TypeOut.Items.Add(db.Materials.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                }
                for (int i = 0; i < 6; i++)
                {
                    TypeGraph.Items.Add(db.Places.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                }
                for (int i = 0; i < 4; i++)
                {
                    Type.Items.Add(db.SizeNames.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                }
            }
        }


        private void OutMaterials()
        {
            if (TypeOut != null && DateFromOut != null && DateToOut != null)
            {
                DateTime SendDate1 = DateFromOut.SelectedDate.HasValue ? DateFromOut.SelectedDate.Value : DateTime.MinValue;
                DateTime SendDate2 = DateToOut.SelectedDate.HasValue ? DateToOut.SelectedDate.Value : DateTime.MinValue;

                using (var db = new AluminContext())
                {
                    AluminaOut.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == TypeOut.SelectedIndex && p.TypeId == 0 && p.Date >= SendDate1 && p.Date <= SendDate2).Select(p => p.Count).Sum().ToString();
                    AnodeOut.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == TypeOut.SelectedIndex && p.TypeId == 1 && p.Date >= SendDate1 && p.Date <= SendDate2).Select(p => p.Count).Sum().ToString();
                    SaltOut.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == TypeOut.SelectedIndex && p.TypeId == 2 && p.Date >= SendDate1 && p.Date <= SendDate2).Select(p => p.Count).Sum().ToString();
                }
            }
        }


        private void TypeOut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OutMaterials();
        }

        private void DateOut_CalendarClosed(object sender, RoutedEventArgs e)
        {
            OutMaterials();
        }
    }
}
