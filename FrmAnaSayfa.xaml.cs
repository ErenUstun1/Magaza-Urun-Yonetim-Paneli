using Microsoft.SqlServer.Server;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for FrmAnaSayfa.xaml
    /// </summary>
    public partial class FrmAnaSayfa : Window
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnUrun_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fr = new MainWindow();
            fr.Show();
        }

        private void btnIstatistikler_Click(object sender, RoutedEventArgs e)
        {
            FrmIstatistik fr = new FrmIstatistik();
            fr.Show();
        }

        private void btnKategori_Click(object sender, RoutedEventArgs e)
        {
            FrmKategori fr = new FrmKategori();
            fr.Show();
        }
    }
}
