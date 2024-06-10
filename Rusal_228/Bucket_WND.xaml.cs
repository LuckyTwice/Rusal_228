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
    /// Логика взаимодействия для Bucket_WND.xaml
    /// </summary>
    public partial class Bucket_WND : Window
    {
        Button[] Buckets;
        Button[] Corpuses;
        public Bucket_WND()
        {
            InitializeComponent();
            
            Buckets = new Button[] { Bucket1, Bucket2, Bucket3, Bucket4, Bucket5, Bucket6, Bucket7, Bucket8, Bucket9, Bucket10, Bucket11, Bucket12, Bucket13, Bucket14, Bucket15, Bucket16, Bucket17, Bucket18, Bucket19, Bucket20, Bucket21, Bucket22, Bucket23, Bucket24 };
            Corpuses = new Button[] { Corpus7, Corpus8, Corpus9, Corpus10, Corpus11, Corpus12, Defective };
            AddEventButton();

            /*Documents.Items.Add("Отчет о загрузке 19 ковша");
            Documents.Items.Add("Отчет об отправлении  19 ковша");*/
        }
        private void AddEventButton()
        {
            for (int i = 0; i < Corpuses.Length; i++)
            {
                Button button = Corpuses[i];
                Corpuses[i].Tag = new Tuple<int>(i);
                button.Click -= Corpuses_Click;
                button.Click += Corpuses_Click;

            }
            for (int i = 0; i < Buckets.Length; i++)
            {
                Button button = Buckets[i];
                Buckets[i].Tag = new Tuple<int>(i);
                button.Click -= Buckets_Click;
                button.Click += Buckets_Click;
            }
            
        }
        private void Buckets_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;

            // сделать проверку, что в выбранном ковше есть алюминий
            // Если да, то
            Bucket_Bucket_WND dialog = new Bucket_Bucket_WND();
            dialog.number = number;
            dialog.ShowDialog();
            // если нет, то
            MessageBox.Show("В выбранном миксере недостаточно места", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void Corpuses_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int number = tag.Item1;
            
            if(number!= Corpuses.Length - 1)
            {
                Bucket_Baths_WND dialog = new Bucket_Baths_WND();
                dialog.corpus = number;
                dialog.ShowDialog();
            }
            else
            MessageBox.Show("НАДА СДЕЛАТЬ ДОП ОКНО ДЛЯ ДЕФЕКТОВ", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
