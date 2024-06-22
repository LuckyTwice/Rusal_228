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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Rusal_228
{
    /// <summary>
    /// Логика взаимодействия для Mixers_T_shaped_Mixers_Full_WND.xaml
    /// </summary>
    public partial class Mixers_T_shaped_Mixers_Full_WND : Window
    {
        public int type { get; set; }
        public int number { get; set; }
        public Mixers_T_shaped_Mixers_Full_WND()
        {
            InitializeComponent();
        }

        private async void Go_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var send2 = new Report
                {
                    PrevId = db.Reports.Where(p => p.FromId == null && p.ToId == 8 && p.ToNumber == number && p.Ready == null).Select(p => p.Id).Single(),
                    Ready = false,
                    PersWId = 2,
                    FromId = 8,
                    FromNumber = number,
                    ToId = 8,
                    ToNumber = number,
                    Count = Convert.ToInt32(Fill.Text),
                    Date = DateTime.Today,
                    Time = DateTime.Now.TimeOfDay
                };
                db.Reports.Add(send2);
                var batch = new Batch
                {
                    ReportId = send2.Id,
                    SizeId = number - 1,
                };
                db.Batchs.Add(batch);
                try
                {
                    await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                    MessageBox.Show($"Информация о начале литья в миксере {number}, а также подготовке партии {batch.Id} передана в базу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Информация о начале литья в миксере {number} передана в базу");
                }
                Close();
            }
        }
    }
}
