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
    /// Логика взаимодействия для Admin_Electrolysis_WND.xaml
    /// </summary>
    public partial class Admin_Electrolysis_WND : Window
    {
        Button[,] Corpuses;

        public Admin_Electrolysis_WND()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Corpuses = new Button[,] { { Corpus7_1, Corpus7_2, Corpus7_3, Corpus7_4, Corpus7_5, Corpus7_6, Corpus7_7, Corpus7_8, Corpus7_9, Corpus7_10 },
            { Corpus8_1, Corpus8_2, Corpus8_3, Corpus8_4, Corpus8_5, Corpus8_6, Corpus8_7, Corpus8_8, Corpus8_9, Corpus8_10 },
            { Corpus9_1, Corpus9_2, Corpus9_3, Corpus9_4, Corpus9_5, Corpus9_6, Corpus9_7, Corpus9_8, Corpus9_9, Corpus9_10 },
            { Corpus10_1, Corpus10_2, Corpus10_3, Corpus10_4, Corpus10_5, Corpus10_6, Corpus10_7, Corpus10_8, Corpus10_9, Corpus10_10 },
            { Corpus11_1, Corpus11_2, Corpus11_3, Corpus11_4, Corpus11_5, Corpus11_6, Corpus11_7, Corpus11_8, Corpus11_9, Corpus11_10 },
            { Corpus12_1, Corpus12_2, Corpus12_3, Corpus12_4, Corpus12_5, Corpus12_6, Corpus12_7, Corpus12_8, Corpus12_9, Corpus12_10 } };

            int[] baths = new int[] { 100, 90, 81, 91, 75, 88 };

            for (int i = 0; i < Corpuses.GetLength(0); i++)
            {
                double change = Math.Ceiling((double)baths[i] / Corpuses.GetLength(1));

                for (int j = 0; j < Corpuses.GetLength(1); j++)
                {
                    if (j != Corpuses.GetLength(1) - 1)
                        Corpuses[i, j].Content = (change * j + 1).ToString() + " - " + (change * (1 + j)).ToString() + " ванны";
                    else
                        if (change * j + 1 > baths[i])
                        Corpuses[i, j].Visibility = Visibility.Hidden;
                    else
                        if (change * j + 1 == baths[i])
                        Corpuses[i, j].Content = (change * j + 1).ToString() + " ванна";
                    else
                        Corpuses[i, j].Content = (change * j + 1).ToString() + " - " + (baths[i]).ToString() + " ванны";
                }
            }
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton != null)
            {
                string[] subs = clickedButton.Content.ToString().Replace(" ", "").Replace("ванна", "").Replace("ванны", "").Split('-');

                Admin_Electrolysis_Bath_WND dialog = new Admin_Electrolysis_Bath_WND();

                dialog.start = Convert.ToInt32(subs[0]);
                if (subs.Length > 1)
                dialog.finish = Convert.ToInt32(subs[1]);
                else
                dialog.start = Convert.ToInt32(subs[0]);

                if (dialog.ShowDialog() == true) // Диалог завершен с кнопкой OK
                {

                }
            }
        }
    }
}
