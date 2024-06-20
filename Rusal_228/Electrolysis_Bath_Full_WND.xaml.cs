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
    /// Логика взаимодействия для Electrolysis_Bath_Full_WND.xaml
    /// </summary>
    public partial class Electrolysis_Bath_Full_WND : Window
    {
        public int number { get; set; }
        public int corpus { get; set; }
        public Electrolysis_Bath_Full_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Case_Numb.Text = "Корпус " + corpus + ". Ванна " + number + ".";
        }

        private async void Stop_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var l = db.Reports.Where(p => p.ToId == corpus && p.ToNumber == number && p.PrevId==null /*&& p.Ready*/).OrderByDescending(p => p.Id).FirstOrDefault();
                if (l != null)
                {
                    var finish = new Report
                    {
                        AddTime = DateTime.Now.TimeOfDay,
                        PrevId = l.Id,
                        AddDate = DateTime.Today,
                        Ready = false,
                        ToId = l.ToId,
                        Count = l.Count,
                        SaltCount = l.SaltCount,
                        CryoCount= l.CryoCount,
                        Date = l.Date,
                        Time = l.Time,
                        ToNumber = l.ToNumber,
                        PersWId=l.PersWId
                    };
                    db.Reports.Add(finish);
                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show("Информация о поставке была внесена в базу");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Информация не сохранилась");
                        throw ex;
                    }
                }
            }
            Close();
        }
    }
}
