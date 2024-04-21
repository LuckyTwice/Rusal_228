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
    /// Логика взаимодействия для Control_Report_Defects_WND.xaml
    /// </summary>
    public partial class Control_Report_Defects_WND : Window
    {
        public Control_Report_Defects_WND()
        {
            InitializeComponent();
           /* Column_Numb.Items.Add("6");
            Type_defect.Items.Add("Трещина");
            Defect_List.Items.Add("Балка №4 имеет дефект: Ожог длиной 7 см");
            Defect_List.Items.Add("Балка №6 имеет дефект: Трещина длиной 25 см");*/
           using(var db = new AluminContext())
            {
                //var numb = db.Products.Where(p=>p.StatusId==1).Select(p=>p.Id).ToList(); //Дополнить Where нормальным условием про статус после заполнения бд
                var def = db.DefTypes.Select(p=>p.Name).ToList();
                Type_defect.ItemsSource=def;
            }
        }
    }
}
