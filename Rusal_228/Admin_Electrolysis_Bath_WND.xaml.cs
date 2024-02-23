using System;
using System.Collections.Generic;
using System.IO;
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
        public int corpus { get; set; }

        Button[] Baths;
        public Admin_Electrolysis_Bath_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Corpus_name.Content = "Корпус " + corpus;
            Baths = new Button[] { Corpus_1, Corpus_2, Corpus_3, Corpus_4, Corpus_5, Corpus_6, Corpus_7, Corpus_8, Corpus_9, Corpus_10 };

            int startBaths = start;
            int finishBaths = finish;
            int corpusBaths = corpus;

            for (int i = 0; i < Math.Abs(finishBaths - startBaths) + 1; i++)
            {
                Baths[i].Tag = new Tuple<int, int>(corpus, start + i);

                Baths[i].Visibility = Visibility.Visible;
                Baths[i].Content = (start + i).ToString() + " ванна";
            }
            AddEventButton();
        }

        private void AddEventButton()
        {
            for (int i = 0; i < Baths.Length; i++)
            {
                Button button = Baths[i];
                button.Click -= Button_Click;
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int, int> tag = (Tuple<int, int>)button.Tag;
            int Corpus = tag.Item1;
            int Bath = tag.Item2;
            //MessageBox.Show(Corpus.ToString() + "  " + Bath.ToString());

                // сделать проверку, что в выбранной ванне запущен процесс электролиза, но не закончен
                // Если да, то
                Admin_Electrolysis_Bath_Full_WND dialog = new Admin_Electrolysis_Bath_Full_WND();

                dialog.Corpus = Corpus;
                dialog.Bath = Bath;

                dialog.ShowDialog();
                // если нет, то
                MessageBox.Show("Выбранная вами ванна не запущена", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
