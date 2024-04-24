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
    /// Логика взаимодействия для Delivery_Supply_Report_WND.xaml
    /// </summary>
    public partial class Delivery_Supply_Report_WND : Window
    {
        private int Id;
        public Delivery_Supply_Report_WND(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var send = db.Reports.Single(r => r.Id == Id);
                if (send != null)
                {
                    send.PersRId = 2;//поменять на получение Id из проги
                    send.Ready = true;
                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show("Информация о снабжении была внесена в базу");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Информация не сохранилась");
                    }
                    var send2 = new Report
                    {
                        PrevId= send.Id,
                        Ready= false,
                        TypeId = send.TypeId,
                        FromId = send.FromId,
                        ToId = send.ToId,
                        Count = send.Count,
                        Date = DateTime.Today,
                        Time = DateTime.Now.TimeOfDay
                    };
                    db.Reports.Add(send2);
                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show("Информация о подготовке приемки снабжения была внесена в базу");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Информация не сохранилась");
                    }
                    Close();
                }
            }
        }
    }
}
