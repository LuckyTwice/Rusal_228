using System;
using System.Collections;
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
    /// Логика взаимодействия для Admin_Electrolysis_Bath_Full_WND.xaml
    /// </summary>
    public partial class Admin_Electrolysis_Bath_Full_WND : Window
    {
        public int Corpus { get; set; }
        public int Bath { get; set; }

        public Admin_Electrolysis_Bath_Full_WND()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int CorpusUsed = Corpus;
            int BathUsed = Bath;
            Bath_Numb.Text = "Корпус " + CorpusUsed + ". Ванна " + BathUsed + ".";
            // Вытягивание из базы инфы загрузке ванны
        }
    }
}
