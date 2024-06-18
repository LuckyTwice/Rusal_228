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
    /// Логика взаимодействия для WorkerMain.xaml
    /// </summary>
    public partial class WorkerMain : Window
    {
        public WorkerMain()
        {
            InitializeComponent();
            Documents.Items.Add("Отчет о загрузке ванны 32");
            Documents.Items.Add("Отчет о поступлении фторсолей");
/*            Baths.Items.Add("Корпус 8. Ванна 47");
            Baths.Items.Add("Корпус 8. Ванна 24");*/
        }
    }
}
