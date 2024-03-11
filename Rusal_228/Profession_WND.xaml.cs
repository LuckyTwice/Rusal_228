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
    /// Логика взаимодействия для Profession_WND.xaml
    /// </summary>
    public partial class Profession_WND : Window
    {
        public Profession_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Read.Items.Add("Администратор");
            Read.Items.Add("Работник электролизного цеха №8");
            Read.Items.Add("Работник электролизного цеха №7");
        }
    }
}
