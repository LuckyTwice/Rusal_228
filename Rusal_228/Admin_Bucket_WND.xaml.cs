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
    /// Логика взаимодействия для Admin_Bucket_WND.xaml
    /// </summary>
    public partial class Admin_Bucket_WND : Window
    {
        Button[] Buckets;
        public Admin_Bucket_WND()
        {
            InitializeComponent();
            Load.Text = "68 ковшей загружено сегодня";
            Unload.Text = "52 ковшей выгружено сегодня";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Buckets = new Button[] { Bucket1, Bucket2, Bucket3, Bucket4, Bucket5, Bucket6, Bucket7, Bucket8, Bucket9, Bucket10, Bucket11, Bucket12, Bucket13, Bucket14, Bucket15, Bucket16, Bucket17, Bucket18, Bucket19, Bucket20, Bucket21, Bucket22, Bucket23, Bucket24 };
            AddEventButton();

        }
        private void AddEventButton()
        {
            for (int i = 0; i < Buckets.Length; i++)
            {
                Button button = Buckets[i];
                button.Tag = new Tuple<int>(i);
                button.Click -= Button_Click;
                button.Click += Button_Click;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int> tag = (Tuple<int>)button.Tag;
            int Number = tag.Item1;

            // сделать проверку, что выбранный ковш загружен
            // Если да, то
            Admin_Bucket_Bucket_WND dialog = new Admin_Bucket_Bucket_WND();
            dialog.Number = Number + 1;
            dialog.ShowDialog();
            // если нет, то
            MessageBox.Show("Выбранный вами ковш не загружен", "Информационное окно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
