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
    /// Логика взаимодействия для Mixers_T_shaped_Mixers_Empty_WND.xaml
    /// </summary>
    public partial class Mixers_T_shaped_Mixers_Empty_WND : Window
    {
        public int type { get; set; }
        public int number { get; set; }
        public Mixers_T_shaped_Mixers_Empty_WND()
        {
            InitializeComponent();
        }

        private async void Go_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var send2 = new Report
                {
                    Ready = false,
                    PersWId = 2,
                    ToId = 9,
                    ToNumber = number,
                    Count = Convert.ToInt32(Fill),
                    Date = DateTime.Today,
                    Time = DateTime.Now.TimeOfDay
                };
                db.Reports.Add(send2);
                try
                {
                    await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                    MessageBox.Show($"Информация о получении алюминия из ковша {send2.ToNumber} поступила в базу");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Информация о получении алюминия из ковша {send2.ToNumber} не сохранилась в базе");
                }
                Close();
            }
        }
    }
}
