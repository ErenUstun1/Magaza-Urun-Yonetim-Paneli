using System;
using System.CodeDom;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Listele();

        }
        DbEntityUrunEntities urun = new DbEntityUrunEntities();

        void Listele()
        {
            dgGoster.ItemsSource = (from x in urun.Tbl_Urun
                                    select new
                                    {
                                        x.URUNID,
                                        x.URUNAD,
                                        x.MARKA,
                                        x.STOK,
                                        x.FİYAT,
                                        x.Tbl_Kategori.AD,
                                        x.DURUM
                                    }).ToList();

        }
        private void btnTemizle_Click(object sender, RoutedEventArgs e)
        {
            txtUrunAd.Text = "";
            txtStokSayisi.Text = "";
            txtFiyat.Text = "";
            txtMarka.Text = "";
            txtDurum.Text = "";
            txtKategori.Text = "";
            txtUrunAd.Focus();
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.URUNAD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.STOK = short.Parse(txtStokSayisi.Text);
            t.KATEGORİ = int.Parse(txtKategori.Text);
            t.FİYAT = decimal.Parse(txtFiyat.Text);
            t.DURUM = true;
            urun.Tbl_Urun.Add(t);
            urun.SaveChanges();
            MessageBox.Show("Ürün Sisteme Eklendi.");
            Listele();
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(txtUrunId.Text);
            var urunx = urun.Tbl_Urun.Find(x);
            urun.Tbl_Urun.Remove(urunx);
            urun.SaveChanges();
            MessageBox.Show("Ürün Silindi.");
            Listele();
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            //Tbl_Urun urunx = dgGoster.SelectedItem as Tbl_Urun;
            //urun.Tbl_Urun.First(x => x.URUNID == 1);
            //urunx.URUNAD = txtUrunAd.Text;
            //urunx.MARKA = txtMarka.Text;
            //urunx.STOK = short.Parse(txtStokSayisi.Text);
            //urunx.KATEGORİ = short.Parse(txtKategori.Text);
            //urunx.FİYAT = decimal.Parse(txtFiyat.Text);
            //urunx.DURUM = bool.Parse(txtDurum.Text);
            //urun.SaveChanges();
            //MessageBox.Show("Ürün Güncellendi.");
            //Listele();


            int x = Convert.ToInt32(txtUrunId.Text);
            var urunx = urun.Tbl_Urun.Find(x);
            urunx.URUNAD = txtUrunAd.Text;
            urunx.MARKA = txtMarka.Text;
            urunx.STOK = short.Parse(txtStokSayisi.Text);
            urunx.KATEGORİ = short.Parse(txtKategori.Text);
            urunx.FİYAT = decimal.Parse(txtFiyat.Text);
            urunx.DURUM = bool.Parse(txtDurum.Text);
            urun.SaveChanges();
            MessageBox.Show("Ürün Güncellendi.");
            Listele();
        }

        private void btnCikis_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }         

        private void dgGoster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            DataRowView dataRow = data.SelectedItem as DataRowView;            
                
            if (dataRow != null)
            {
                txtUrunId.Text = dataRow["URUNID"].ToString();
                txtUrunAd.Text = dataRow["URUNAD"].ToString();
                txtMarka.Text = dataRow["STOK"].ToString();
                txtStokSayisi.Text = dataRow["FİYAT"].ToString();
                txtDurum.Text = dataRow["DURUM"].ToString();
                txtKategori.Text = dataRow["KATEGORİ"].ToString();
            }

        }
    }
}
