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
    /// Interaction logic for FrmGiris.xaml
    /// </summary>
    public partial class FrmGiris : Window
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnTemizle_Click(object sender, RoutedEventArgs e)
        {
            DbEntityUrunEntities db = new DbEntityUrunEntities();
            var sorgu = from x in db.Tbl_Admin where x.Kullanıcı == txtKullaniciAdi.Text && x.Sifre == txtKullaniciSifre.Text select x;
            if (sorgu.Any())
            {
                FrmAnaSayfa fr = new FrmAnaSayfa();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
