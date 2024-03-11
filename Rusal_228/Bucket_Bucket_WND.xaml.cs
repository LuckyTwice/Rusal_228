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
    /// Логика взаимодействия для Bucket_Bucket_WND.xaml
    /// </summary>
    public partial class Bucket_Bucket_WND : Window
    {
        public int number { get; set; }

        public Bucket_Bucket_WND()
        {
            InitializeComponent();
            Bucket.Items.Add("Линия чушек");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Bucket_Numb.Text = "Ковш "+ (number+1)+".";
        }
    }
}
