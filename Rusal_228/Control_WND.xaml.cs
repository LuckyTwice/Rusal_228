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
    /// Логика взаимодействия для Control_WND.xaml
    /// </summary>
    public partial class Control_WND : Window
    {
        public Control_WND()
        {
            InitializeComponent();
            Check.Items.Add("Партия №8923");
            Check.Items.Add("Партия №8924");
            Check.Items.Add("Партия №8925");
            Check.Items.Add("Партия №8926");

            Defective.Items.Add("Партия №8920 (1,5)");
            Defective.Items.Add("Партия №8922 (3,4)");

            Normal.Items.Add("Партия №8920 (2,3,4,6)");
            Normal.Items.Add("Партия №8921");
            Normal.Items.Add("Партия №8922 (1,2,5,6)");

            Documents.Items.Add("Отчет о получении партии №8927");
            Documents.Items.Add("Отчет об отправлении партии №8918 в хранилище ");
            Documents.Items.Add("Отчет об отправлении партии №8919 (1,2) на переплавку");
        }
    }
}
