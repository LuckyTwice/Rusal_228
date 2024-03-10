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
    /// Логика взаимодействия для Bucket_Baths_WND.xaml
    /// </summary>
    public partial class Bucket_Baths_WND : Window
    {
        public int corpus { get; set; }
        Button[] Baths;
        public Bucket_Baths_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameCorpus.Content = "Корпус " + (corpus +7)+ ".";

            Baths = new Button[] { Corpus_1, Corpus_2, Corpus_3, Corpus_4, Corpus_5, Corpus_6, Corpus_7, Corpus_8, Corpus_9, Corpus_10, Corpus_11, Corpus_12, Corpus_13, Corpus_14, Corpus_15, Corpus_16, Corpus_17, Corpus_18, Corpus_19, Corpus_20 };

            int BathCount = 97;

            int change = (int)Math.Ceiling((double)BathCount / Baths.Length);

            for (int j = 0; j < Baths.Length; j++)
            {
                if (change * j + 1 > BathCount)
                    Baths[j].Visibility = Visibility.Hidden;
                else
                if (change * j + 1 == BathCount)
                {
                    Baths[j].Content = (change * j + 1).ToString() + " ванна";
                    Baths[j].Tag = new Tuple<int, int>(change * j + 1, 0);
                }
                else
                if (change * (1 + j) > BathCount)
                {
                    Baths[j].Content = (change * j + 1).ToString() + " - " + (BathCount).ToString() + " ванны";
                    Baths[j].Tag = new Tuple<int, int>(change * j + 1, BathCount);
                }
                else
                {
                    Baths[j].Content = (change * j + 1).ToString() + " - " + (change * (1 + j)).ToString() + " ванны";
                    Baths[j].Tag = new Tuple<int, int>(change * j + 1, change * (1 + j));
                }
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
            int start = tag.Item1;
            int finish = tag.Item2;


            Bucket_Baths_Lower_WND dialog = new Bucket_Baths_Lower_WND();

            dialog.start = start;
            dialog.finish = finish;
            dialog.corpus = corpus;

            dialog.ShowDialog();


        }
    }
}
