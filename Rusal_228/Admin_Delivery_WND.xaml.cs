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
    /// Логика взаимодействия для Admin_Delivery_WND.xaml
    /// </summary>
    public partial class Admin_Delivery_WND : Window
    {
        public Admin_Delivery_WND()
        {
            InitializeComponent();

            using (var db = new AluminContext())
            {
                for (int i = 0; i < 6; i++)
                {
                    Type.Items.Add(db.Places.Where(p => p.Id == i).Select(p => p.Name).Single().ToString());
                }
            }
        }


        private void Date_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DateTo != null && DateFrom != null)
            {
                DateTime Date1 = DateFrom.SelectedDate.HasValue ? DateFrom.SelectedDate.Value : DateTime.MinValue;
                DateTime Date2 = DateTo.SelectedDate.HasValue ? DateTo.SelectedDate.Value : DateTime.MinValue;

                using (var db = new AluminContext())
                {
                    Alumina.Text = db.Reports.Where(p => p.FromId == null && p.ToId == 6 && p.TypeId == 0 && p.Date >= Date1 && p.Date <= Date2).Select(p => p.Count).Sum().ToString();
                    Anode.Text = db.Reports.Where(p => p.FromId == null && p.ToId == 6 && p.TypeId == 1 && p.Date >= Date1 && p.Date <= Date2).Select(p => p.Count).Sum().ToString();
                    Salt.Text = db.Reports.Where(p => p.FromId == null && p.ToId == 6 && p.TypeId == 2 && p.Date >= Date1 && p.Date <= Date2).Select(p => p.Count).Sum().ToString();
                    Count.Text = db.Reports.Where(p => p.FromId == null && p.ToId == 6 && p.Date >= Date1 && p.Date <= Date2).Count().ToString();
                }
            }
        }

        private void SendMaterials()
        {
            if (Type != null && DateToSend != null && DateFromSend != null)
            {
                DateTime SendDate1 = DateFromSend.SelectedDate.HasValue ? DateFromSend.SelectedDate.Value : DateTime.MinValue;
                DateTime SendDate2 = DateToSend.SelectedDate.HasValue ? DateToSend.SelectedDate.Value : DateTime.MinValue;

                using (var db = new AluminContext())
                {
                    AluminaSend.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == Type.SelectedIndex && p.TypeId == 0 && p.Date >= SendDate1 && p.Date <= SendDate2).Select(p => p.Count).Sum().ToString();
                    AnodeSend.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == Type.SelectedIndex && p.TypeId == 1 && p.Date >= SendDate1 && p.Date <= SendDate2).Select(p => p.Count).Sum().ToString();
                    SaltSend.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == Type.SelectedIndex && p.TypeId == 2 && p.Date >= SendDate1 && p.Date <= SendDate2).Select(p => p.Count).Sum().ToString();
                    CountSend.Text = db.Reports.Where(p => p.FromId == 6 && p.ToId == Type.SelectedIndex && p.Date >= SendDate1 && p.Date <= SendDate2).Count().ToString();
                }
            }
        }


        private void DateSend_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SendMaterials();
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SendMaterials();
        }


    }
}
