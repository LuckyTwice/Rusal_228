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
    /// Логика взаимодействия для Admin_Mixers_Empty_WND.xaml
    /// </summary>
    public partial class Admin_Mixers_Empty_WND : Window
    {
        public int Type { get; set; }
        public int Number { get; set; }
        public Admin_Mixers_Empty_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int TypeMixer = Type;
            int NumberMixer = Number+1;

            if (TypeMixer == 0)
                Mixer_Numb.Text = "Столбы. Миксер " + NumberMixer + ".";
            else
                Mixer_Numb.Text = "Чушки. Миксер " + NumberMixer + ".";

        }
    }
}
