using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    /// Логика взаимодействия для Bucket_Unload_Report_WND.xaml
    /// </summary>
    public partial class Bucket_Unload_Report_WND : Window
    {
        private int Id;
        private int? Numb;
        public Bucket_Unload_Report_WND(int id, int? numb)
        {
            InitializeComponent();
            Id = id;
            Numb = numb;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var come = db.Reports.Single(r => r.Id == Id);
                if (come != null)
                {
                    come.PersRId = 2;//поменять на получение Id из проги
                    come.Ready = true;
                    var l = db.Reports.Where(p => p.ToId == 7 && p.ToNumber == Numb && p.Ready == null);
                    foreach(var r in l)
                    {
                        r.Ready = true;
                    }
                    Report k = new Report //проверить работу потом
                    {
                        PersR = come.PersR,
                        PersW = come.PersW,
                        ToId = null,
                        ToNumber = come.ToNumber,
                        FromNumber = come.FromNumber,
                        FromId = come.FromId,
                        Date = come.Date,
                        Time = come.Time,
                        Count = come.Count,
                        Ready = null,
                        PrevId = come.PrevId,
                    };
                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show("Информация о загрузке кошва была внесена в базу");
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
