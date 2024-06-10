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
    /// Логика взаимодействия для Admin_WND.xaml
    /// </summary>
    public partial class Admin_WND : Window
    {
        public Admin_WND()
        {
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dialog = new MainWindow();
            dialog.Show();
            Close();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            //Реализовать не открывание нового окна, если одно уже открыто
            //if ()
            Admin_Rules_WND dialog = new Admin_Rules_WND();
            dialog.Show();
            //Close();
        }

        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            //Реализовать не открывание нового окна, если одно уже открыто
            Admin_Stat_WND dialog = new Admin_Stat_WND();
            dialog.Show();
        }

        private void Delivery_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Delivery_WND dialog = new Admin_Delivery_WND();  
            dialog.Show();
        }

        private void Electrolysis_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Electrolysis_WND dialog = new Admin_Electrolysis_WND();
            dialog.Show();
        }

        private void Bucket_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Bucket_WND dialog = new Admin_Bucket_WND();
            dialog.Show();
        }

        private void Mixer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Mixer_WND dialog = new Admin_Mixer_WND();
            dialog.Show();
        }

        private void Casting_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Casting_WND dialog = new Admin_Casting_WND();
            dialog.Show();
        }

        private void Control_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Control_WND dialog = new Admin_Control_WND();
            dialog.Show();
        }

        private void Storage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Admin_Storage_WND dialog = new Admin_Storage_WND();
            dialog.Show();
        }
    }
}
