using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для Mixers_Column_Mixers_WND.xaml
    /// </summary>
    public partial class Mixers_Column_Mixers_WND : Window
    {
        public int id {  get; set; }
        public int type {  get; set; }
        Button[] Mixers;

        public Mixers_Column_Mixers_WND()
        {
            InitializeComponent();
            Mixers = new Button[] { Mixer1, Mixer2, Mixer3 };
            for (int i = 0; i < Mixers.Length; i++)
            {
                Button button = Mixers[i];
                Mixers[i].Tag = new Tuple<int>(i+1);
                button.Click -= Mixer_Click;
                button.Click += Mixer_Click;
            }
        }

        private async void Mixer_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;
            using (var db = new AluminContext())
            {
                var send = db.Reports.Single(r => r.Id == id);
                if (send != null)
                {
                    send.Ready = true;
                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show("Изменения данных о ковше были внесены в базу");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Изменения данных о ковше не сохранились");
                    }
                    var send2 = new Report
                    {
                        PrevId = send.Id,
                        Ready = false,
                        FromId = send.FromId,
                        FromNumber = send.FromNumber,
                        ToId = send.ToId,
                        ToNumber = number,
                        Count = send.Count,
                        Date = DateTime.Today,
                        Time = DateTime.Now.TimeOfDay
                    };
                    db.Reports.Add(send2);
                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show($"Информация о получении алюминия из ковша {send2.ToNumber} в миксер {send2.ToNumber} поступила в базу");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Информация о получении алюминия из ковша {send2.ToNumber} в миксер {send2.ToNumber} не сохранилась в базе");
                    }
                    Close();
                }
            }
        }
    }
}
