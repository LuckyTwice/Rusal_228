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
    /// Логика взаимодействия для Profession_WND.xaml
    /// </summary>
    public partial class Profession_WND : Window
    {
        public Profession_WND()
        {
            InitializeComponent();
        }

        public int Pers_Id { get; set; }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            if (Read.SelectedIndex > -1)
            {
                Prof_Choice item = (Prof_Choice)Read.SelectedItem;
                switch (item.Id)
                {
                    case 0:
                        Electrolysis_WND dialog = new Electrolysis_WND();
                        using (var db = new AluminContext())
                        {
                            var Name = db.Personals.Where(p => p.Id == Pers_Id).Select(p => new { p.Surname, p.Name, p.Patronymic }).Single();
                            dialog.Name.Text = $"{Name.Surname} {Name.Name} {Name.Patronymic}";
                        }
                        int sum = 7 + (int)item.Id;
                        dialog.Corpus_Name.Content += $" {sum}";
                        dialog.ShowDialog();
                        break;
                }
                Read.SelectedIndex = -1;
            }
        }
    }
}
