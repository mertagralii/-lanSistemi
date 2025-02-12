namespace İlanSistemi.Models
{
    public class IndexViewModel
    {
        public List<Kategoriler> Kategoriler { get; set; }

        public List<İlanlarKategorilerLeftJoin> İlanlar { get; set; }
    }
}
