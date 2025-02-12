using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Dapper;
using İlanSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace İlanSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnection _connection;

        public HomeController(IDbConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            var ilanList = _connection.Query<İlanlarKategorilerLeftJoin>("SELECT i.Id AS IlanId, i.KategoriId, i.Baslik, i.Fiyat, i.ListeGorselURL,i.DetayGorselURL ,İ.EklenmeTarihi, i.DetayYazisi, k.KategoriAdi  FROM İlanlar i LEFT JOIN Kategoriler k ON i.KategoriId = k.Id ORDER BY i.EklenmeTarihi DESC").ToList();
            var kategoriList = _connection.Query<Kategoriler>("SELECT * FROM Kategoriler").ToList();

            var model = new IndexViewModel() { Kategoriler = kategoriList, İlanlar = ilanList };

            return View(model);
        }



        public IActionResult Editor()
        {
            var kategoriList = _connection.Query<Kategoriler>("SELECT * FROM Kategoriler").ToList();
            var ilanList = _connection.Query<İlanlar>("SELECT * FROM İlanlar").ToList();
            var model = new EditorViewModel()
            {
                Kategoriler = kategoriList,
                İlanlar = ilanList
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateKategori(int Id)
        {
            var selectedKategori = _connection.QuerySingleOrDefault<Kategoriler>("SELECT * FROM Kategoriler Where Id=@Id", new { Id });
            return View(selectedKategori);
        }
        [HttpPost]
        public IActionResult UpdateKategori(Kategoriler kategoriler)
        {
            var updateKategori = _connection.Execute(@"UPDATE Kategoriler SET KategoriAdi = @KategoriAdi , KategoriGorselURL = @KategoriGorselURL WHERE Id=@Id", kategoriler);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteKategori(int Id)
        {
            var deleteKategori = _connection.Execute("DELETE Kategoriler Where Id=@Id", new { Id });

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult InsertKategori(Kategoriler kategori)
        {

            var insertKategori = _connection.Execute(
                                                        @"INSERT INTO Kategoriler
                                                         (KategoriAdi)
                                                         VALUES
                                                         (@KategoriAdi)", kategori
                                                    );

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Updateİlan(int Id)
        {
            var selectedİlan = _connection.QueryFirstOrDefault<İlanlar>("SELECT * FROM İlanlar WHERE Id=@Id", new { Id });
            var kategoriList = _connection.Query<Kategoriler>("SELECT * FROM Kategoriler").ToList();

            var model = new UpdateİlanViewModel()
            {
                Kategoriler = kategoriList,
                İlan = selectedİlan
            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Updateİlan(İlanlar ilan)
        {
            var GuncelDate = DateTime.Now;
            var updateİlan = _connection.Execute
                (
                   @"UPDATE İlanlar 
                    SET
                   KategoriId = @KategoriId,
                   Baslik = @Baslik,
                   Fiyat = @Fiyat,
                   ListeGorselURL = @ListeGorselURL,
                   DetayGorselURL = @DetayGorselURL,
                   GuncellemeTarihi = @GuncellemeTarihi,
                   DetayYazisi = @DetayYazisi
                   WHERE Id=@Id", new
                   {
                       Id = ilan.IlanId,
                       KategoriId = ilan.KategoriId,
                       Baslik = ilan.Baslik,
                       Fiyat = ilan.Fiyat,
                       ListeGorselURL = ilan.ListeGorselURL,
                       DetayGorselURL = ilan.DetayGorselURL,
                       GuncellemeTarihi = GuncelDate,
                       DetayYazisi = ilan.DetayYazisi
                   }
                 );


            return RedirectToAction("Index");
        }


        public IActionResult Deleteİlan(int Id)
        {
            var deleteİlan = _connection.Execute("DELETE İlanlar WHERE Id=@Id", new { Id });

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Insertİlan(İlanlar ilan)
        {
            var created = DateTime.Now;
            var insertİlan = _connection.Execute(@"INSERT INTO İlanlar (KategoriId,Baslik,Fiyat,ListeGorselURL,DetayGorselURL,EklenmeTarihi,DetayYazisi) VALUES (@KategoriId,@Baslik,@Fiyat,@ListeGorselURL,@DetayGorselURL,@EklenmeTarihi,@DetayYazisi)", new
            {
                KategoriId = ilan.KategoriId,
                Baslik = ilan.Baslik,
                Fiyat = ilan.Fiyat,
                ListeGorselURL = ilan.ListeGorselURL,
                DetayGorselURL = ilan.DetayGorselURL,
                EklenmeTarihi = created,
                DetayYazisi = ilan.DetayYazisi,

            });
            return RedirectToAction("Index");
        }

        public IActionResult SeciliKategoriListesi(int Id) 
        {
            var KategoriİlanList = _connection.Query<İlanlarKategorilerLeftJoin>("SELECT i.Id AS IlanId, i.KategoriId, i.Baslik, i.Fiyat, i.ListeGorselURL,i.DetayGorselURL ,İ.EklenmeTarihi, i.DetayYazisi, k.KategoriAdi  FROM İlanlar i LEFT JOIN Kategoriler k ON i.KategoriId = k.Id WHERE i.KategoriId = @KategoriId  ORDER BY i.EklenmeTarihi DESC ", new { KategoriId = Id }).ToList();
            var kategoriList = _connection.Query<Kategoriler>("SELECT * FROM Kategoriler").ToList();

            var model = new SeciliKategoriListesi() { Kategoriler = kategoriList, İlanlar = KategoriİlanList };


            return View(model);
        }

        public IActionResult İlanDetay(int Id) 
        {
            var ilan = _connection.QueryFirstOrDefault<İlanlar>("SELECT * FROM İlanlar WHERE Id = @Id", new { Id = Id });
            return View(ilan);
        }




    }
}
