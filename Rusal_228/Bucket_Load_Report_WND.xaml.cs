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
    /// Логика взаимодействия для Bucket_Load_Report_WND.xaml
    /// </summary>
    public partial class Bucket_Load_Report_WND : Window
    {
        private int Id;
        public Bucket_Load_Report_WND(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AluminContext())
            {
                var come = db.Reports.Single(r => r.Id == Id);
                if (come != null)
                {
                    come.PersRId = 2;//поменять на получение Id из проги
                    come.Ready = null;

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
