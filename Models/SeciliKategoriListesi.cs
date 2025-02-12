namespace İlanSistemi.Models
{
    public class SeciliKategoriListesi
    {
        public List<Kategoriler> Kategoriler { get; set; }

        public List<İlanlarKategorilerLeftJoin> İlanlar { get; set; }
    }
}
