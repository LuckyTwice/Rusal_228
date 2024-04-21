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
    /// Логика взаимодействия для Admin_Storage_WND.xaml
    /// </summary>
    public partial class Admin_Storage_WND : Window
    {
        public Admin_Storage_WND()
        {
            InitializeComponent();
            using (var db = new AluminContext())
            {
                Access_Col.Text = db.GeneralStorages.Where(p => p.Id == 3).Select(p => p.Count).Single().ToString();
                Access_Tsh.Text = db.GeneralStorages.Where(p => p.Id == 4).Select(p => p.Count).Single().ToString();
            }
        }
    }
}
