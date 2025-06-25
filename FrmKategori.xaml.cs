using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for FrmKategori.xaml
    /// </summary>
    public partial class FrmKategori : Window
    {
        public FrmKategori()
        {
            InitializeComponent();
            Listele();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
            
        void Listele()
        {
            dgGoster.ItemsSource = db.Tbl_Kategori.ToList();
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.AD = txtKategoriAd.Text;
            db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
            Listele();
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(txtKategoriID.Text);
            var ktgr = db.Tbl_Kategori.Find(x);
            db.Tbl_Kategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
            Listele();
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(txtKategoriID.Text);
            var ktgr = db.Tbl_Kategori.Find(x);
            ktgr.AD = txtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
            Listele();
        }

        private void btnCikis_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void dgGoster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            //DataRowView dataRow = data.SelectedItem as DataRowView;
            DataRowView dataRow = dgGoster.SelectedItem as DataRowView;
            if (dataRow != null)
            {
                txtKategoriID.Text = dataRow["ID"].ToString();
                txtKategoriAd.Text = dataRow["AD"].ToString();               
            }
        }
    }
}
