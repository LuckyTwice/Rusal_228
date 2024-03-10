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
    /// Логика взаимодействия для Mixers_Column_Mixers_Empty_WND.xaml
    /// </summary>
    public partial class Mixers_Column_Mixers_Empty_WND : Window
    {
        public int type { get; set; }
        public int number { get; set; }
        public Mixers_Column_Mixers_Empty_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (type == 0)
                Mixer_Numb.Text = "Столбы. " + (number +1)+ " миксер.";
            else
                Mixer_Numb.Text = "Чушки. " + (number + 1) + " миксер.";
        }
    }
}
