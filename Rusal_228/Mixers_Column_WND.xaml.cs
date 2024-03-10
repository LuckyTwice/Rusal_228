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
    /// Логика взаимодействия для Mixers_Column_WND.xaml
    /// </summary>
    public partial class Mixers_Column_WND : Window
    {
        Button[] Mixers;
        public int type { get; set; }

        public Mixers_Column_WND()
        {
            InitializeComponent();
            Mixers = new Button[] { Mixer1, Mixer2, Mixer3 };
            AddEventButton();
        }
        private void AddEventButton()
        {
            for (int i = 0; i < Mixers.Length; i++)
            {
                Button button = Mixers[i];
                Mixers[i].Tag = new Tuple<int>(i);
                button.Click -= Button_Click;
                button.Click += Button_Click;
            }
        }
        private void Bucket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mixers_Column_Mixers_WND dialog = new Mixers_Column_Mixers_WND();
            dialog.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;

            // сделать проверку, что миксер запущен
            // Если да, то
            Mixers_Column_Mixers_Full_WND dialog = new Mixers_Column_Mixers_Full_WND();

            dialog.number = number;
            dialog.type = type;

            dialog.ShowDialog();
            // если нет, то
            Mixers_Column_Mixers_Empty_WND dialog1 = new Mixers_Column_Mixers_Empty_WND();

            dialog1.number = number;
            dialog.type = type;

            dialog1.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (type == 0)
                TypeName.Content = "Столбы.";
            else
                TypeName.Content = "Чушки." ;
        }
    }
}
