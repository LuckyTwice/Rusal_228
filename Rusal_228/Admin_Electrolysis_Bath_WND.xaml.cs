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
    /// Логика взаимодействия для Admin_Electrolysis_Bath_WND.xaml
    /// </summary>
    public partial class Admin_Electrolysis_Bath_WND : Window
    {
        public int start { get; set; }
        public int finish { get; set; }


        public Admin_Electrolysis_Bath_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Button[] Baths = new Button[] { Corpus_1, Corpus_2, Corpus_3, Corpus_4, Corpus_5, Corpus_6, Corpus_7, Corpus_8, Corpus_9, Corpus_10 };

            int var1 = start;
            int var2 = finish;

            if (var2 == 0)
            {
                Baths[0].Visibility = Visibility.Visible;
                Baths[0].Content = start.ToString() + " ванна";
            }
            else
                for (int i = 0; i < var2 + 1 - var1; i++)
                {
                    Baths[i].Visibility = Visibility.Visible;
                    Baths[i].Content = (start + i).ToString() + " ванна";
                }

            //DialogResult = true;
            MessageBox.Show(var1.ToString() + "   " + var2.ToString());
        }
    }
}
