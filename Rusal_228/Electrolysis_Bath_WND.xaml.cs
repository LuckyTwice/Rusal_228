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
    /// Логика взаимодействия для Electrolysis_Bath_WND.xaml
    /// </summary>
    public partial class Electrolysis_Bath_WND : Window
    {
        public int start { get; set; }
        public int finish { get; set; }
        public int corpus { get; set; }

        Button[] Baths;
        public Electrolysis_Bath_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Name_Corpus.Content = "Корпус " + corpus;
            Baths = new Button[] { Corpus_1, Corpus_2, Corpus_3, Corpus_4, Corpus_5 };

            for (int i = 0; i < Math.Abs(finish - start) + 1; i++)
            {
                Baths[i].Tag = new Tuple<int>(start + i);

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
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;

            // сделать проверку, что в выбранной ванне запущен процесс электролиза
            // Если да, то
            Electrolysis_Bath_Full_WND dialog = new Electrolysis_Bath_Full_WND();

            dialog.number = number;
            dialog.corpus = corpus;

            dialog.ShowDialog();
            // если нет, то
            Electrolysis_Bath_Empty_WND dialog1 = new Electrolysis_Bath_Empty_WND();

            dialog1.number = number;
            dialog1.corpus = corpus;

            dialog1.ShowDialog();
        }
    }
}
