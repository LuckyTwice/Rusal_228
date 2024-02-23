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
    /// Логика взаимодействия для Admin_Mixer_WND.xaml
    /// </summary>
    public partial class Admin_Mixer_WND : Window
    {
        private Button[,] Mixers;
        public Admin_Mixer_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Mixers = new Button[,] { {Column_Mixer1,Column_Mixer2,Column_Mixer3  },
            { Tshaped_Mixer1,Tshaped_Mixer2,Tshaped_Mixer3 } };
            AddEventButton();
        }
        private void AddEventButton()
        {
            for (int i = 0; i < Mixers.GetLength(0); i++)
            {
                for (int j = 0; j < Mixers.GetLength(1); j++)
                {
                    Button button = Mixers[i, j];
                    button.Tag = new Tuple<int, int>(i, j);
                    button.Click -= Button_Click; 
                    button.Click += Button_Click; 
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int, int> tag = (Tuple<int, int>)button.Tag;
            int type = tag.Item1;
            int number = tag.Item2;

            Button clickedButton = Mixers[type, number];

            if (clickedButton != null)
            {
                // Сделать проверку о том, запущен миксер или нет
                // если да, то
                Admin_Mixers_Full_WND dialog = new Admin_Mixers_Full_WND();
                dialog.Type = type;
                dialog.Number = number;
                dialog.ShowDialog();
                // если нет, то
                Admin_Mixers_Empty_WND dialog1 = new Admin_Mixers_Empty_WND();
                dialog1.Type = type;
                dialog1.Number = number;
                dialog1.ShowDialog();
            }
        }
    }
}
