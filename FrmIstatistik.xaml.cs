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
    /// Interaction logic for FrmIstatistik.xaml
    /// </summary>
    public partial class FrmIstatistik : Window
    {
        public FrmIstatistik()
        {
            InitializeComponent();
            Listele();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        void Listele()
        {
            LblKategoriSayısı.Text = db.Tbl_Kategori.Count().ToString();
            LblToplamÜrün.Text = db.Tbl_Urun.Count().ToString();
            LblAktifMüşteri.Text = db.Tbl_Musteri.Count(x => x.DURUM == true).ToString();
            LblPasifMüşteri.Text = db.Tbl_Musteri.Count(x => x.DURUM == true).ToString();
            LblToplamStok.Text = db.Tbl_Urun.Sum(x => x.STOK).ToString();
            LblKasadakiTutar.Text = db.Tbl_Satis.Sum(x => x.FİYAT).ToString() + " TL";
            LblEnYüksekFiyatlıÜrün.Text = (from x in db.Tbl_Urun orderby x.FİYAT descending where x.DURUM == true select x.URUNAD).FirstOrDefault();
            LblEnDüşükFiyatlıÜrün.Text = (from x in db.Tbl_Urun orderby x.FİYAT ascending where x.DURUM == true select x.URUNAD).FirstOrDefault();
            LblBeyazEşya.Text = db.Tbl_Urun.Count(x => x.KATEGORİ == 1).ToString();
            //bu sorgu toplam beyaz eşya sayısını döndürür.
            //LblBeyazEşya.Text = (from x in db.Tbl_Urun where x.URUNAD == "Buzdolabı Makinesi" select x.STOK).ToList().Sum(a => a.Value).ToString();
            //bu sorgu beyaz eşyalardan adı "buzdolabı makinesi" olanları bize döndürür
            LblToplamBuzdolabıSayısı.Text = db.Tbl_Urun.Count(x => x.URUNAD == "Buzdolabı").ToString();
            LblŞehir.Text = (from x in db.Tbl_Musteri select x.SEHİR).Distinct().Count().ToString();
            //LblEnFazlaÜrünlüMarka.Text = db.markagetir().FirstOrDefault();
            //bu prosedür oluşturularak yapılan sorgu
            LblEnFazlaÜrünlüMarka.Text = (from z in db.Tbl_Urun orderby z.URUNAD descending select z.MARKA).FirstOrDefault();
            // bu kod satırı ise prosedür kullanılmadan yapılmıştır.
        }

    }
}
