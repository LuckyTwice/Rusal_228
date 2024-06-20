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
    /// Логика взаимодействия для Electrolysis_Report_Load_WND.xaml
    /// </summary>
    public partial class Electrolysis_Report_Load_WND : Window
    {
        private int Id;
        public Electrolysis_Report_Load_WND(int id)
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
                    come.Ready = true;

                    try
                    {
                        await db.SaveChangesAsync();// уточнить, есть ли необходимость в ассинхронности
                        MessageBox.Show("Информация о приёме сырья была внесена в базу");
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
