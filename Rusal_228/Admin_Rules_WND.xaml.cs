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
    /// Логика взаимодействия для Admin_Rules_WND.xaml
    /// </summary>
    public partial class Admin_Rules_WND : Window
    {
        public Admin_Rules_WND()
        {
            InitializeComponent();
        }

        private void Add_Empl_Click(object sender, RoutedEventArgs e)
        {
            Admin_NewEmployee_WND dialog = new Admin_NewEmployee_WND();
            dialog.ShowDialog();
        }

        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Admin_Employee_WND dialog = new Admin_Employee_WND();
            dialog.ShowDialog();
        }
    }
}
