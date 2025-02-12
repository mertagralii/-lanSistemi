namespace İlanSistemi.Models
{
    public class İlanlarKategorilerLeftJoin
    {

        public int IlanId { get; set; }

        public int KategoriId { get; set; }

        public string Baslik { get; set; }

        public int Fiyat { get; set; }

        public string ListeGorselURL { get; set; }

        public string DetayGorselURL { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        public string DetayYazisi { get; set; }

        public string KategoriAdi { get; set; }
    }
}
