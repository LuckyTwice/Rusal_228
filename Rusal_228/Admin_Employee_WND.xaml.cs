using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Admin_Employee_WND.xaml
    /// </summary>
    public partial class Admin_Employee_WND : Window
    {
        public Admin_Employee_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Surname.Text = "Комаровский Ярослав Сергеевич";
            ID_Empl.Text = "228337";
            Rules.Items.Add("Администратор");
            Department.Items.Add("Работник поставки");
            Department.Items.Add("Работник ковшевой");
        }
    }
}
