# İlan Sistemi

Bu proje, kullanıcıların ilanlar oluşturup, düzenleyip, silebildiği ve kategorilere göre ilanları listeleyebildiği bir ASP.NET Core MVC uygulamasıdır. Kullanıcılar, ilanın başlık, fiyat, görsel ve detay gibi bilgilerini yönetebilir. Ayrıca, kategori bazında ilanları görüntüleyebilirler.

Bu proje, Acun Medya Akademi Genişletilmiş Back-End Yazılım Uzmanlığı eğitiminin temel eğitiminden sonra, uzmanlık aşamasına geçiş sürecinde geliştirilmiştir.

## 🚀 Özellikler

 📋 **Kategori Listesi**: Kullanıcıların ilanları kategorilere göre listeleyebilmesi.

 ✏ **CRUD İşlemleri** : İlan oluşturma, düzenleme, silme ve kategorilere göre düzenleme.

🔍 **İlan Detay Sayfası**: Her bir ilanın detaylarıyla birlikte, ilanın ait olduğu kategori bilgisi.

📸 **Görsel Yönetimi**: İlanların görsellerinin URL'leri ile yönetilmesi.

🗂 **Kategori Yönetimi**: Yeni kategori ekleme, güncelleme ve silme işlemleri.

## 🛠 Kullanılan Teknolojiler

- **ASP.NET Core MVC**
- **Dapper** ve **SQLClient** 
- **MS SQL Server**
- **Bootstrap 5**

## 📌 Kurulum

1. **Projeyi klonlayın:**
   ```sh
   git clone https://github.com/mertagralii/IlanSistemi.git
   ```
2. **Bağımlılıkları yükleyin:**
   ```sh
   dotnet restore
   ```
3. **Veritabanını oluşturun ve güncelleyin:**
   - `appsettings.json` dosyasındaki **ConnectionString** değerini kendi veritabanınıza göre güncelleyin.
   - Aşağıdaki SQL script'ini kullanarak gerekli tabloları oluşturabilirsiniz:

   ```sql
   USE [İlanSistemiDB]
   GO
    /****** Object:  Table [dbo].[İlanlar]    Script Date: 13.02.2025 20:28:30 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[İlanlar](
    	[Id] [int] IDENTITY(1,1) NOT NULL,
    	[KategoriId] [int] NULL,
    	[Baslik] [varchar](50) NULL,
    	[Fiyat] [int] NULL,
    	[ListeGorselURL] [varchar](300) NULL,
    	[DetayGorselURL] [varchar](300) NULL,
    	[EklenmeTarihi] [datetime] NULL,
    	[GuncellemeTarihi] [datetime] NULL,
    	[DetayYazisi] [varchar](80) NULL,
     CONSTRAINT [PK_İlanlar] PRIMARY KEY CLUSTERED 
    (
    	[Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    /****** Object:  Table [dbo].[Kategoriler]    Script Date: 13.02.2025 20:28:30 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[Kategoriler](
    	[Id] [int] IDENTITY(1,1) NOT NULL,
    	[KategoriAdi] [varchar](50) NULL,
    	[KategoriGorselURL] [varchar](300) NULL,
     CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
    (
    	[Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
    SET IDENTITY_INSERT [dbo].[İlanlar] ON 
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (1, 1, N'Toyota Corolla', 5000, N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Toyota_Corolla_Limousine_Hybrid_Genf_2019_1Y7A5576.jpg/800px-Toyota_Corolla_Limousine_Hybrid_Genf_2019_1Y7A5576.jpg', N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Toyota_Corolla_Limousine_Hybrid_Genf_2019_1Y7A5576.jpg/800px-Toyota_Corolla_Limousine_Hybrid_Genf_2019_1Y7A5576.jpg', CAST(N'2025-02-12T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:36:55.117' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (2, 1, N'Mercedes C200', 6000, N'https://pladmin.mercedes-benz.com.tr/cdn/images/a-serisi.png', N'https://pladmin.mercedes-benz.com.tr/cdn/images/a-serisi.png', CAST(N'2020-02-12T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:37:10.587' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (3, 1, N'BMW İ20', 8000, N'https://i0.shbdn.com/photos/40/05/02/x5_1166400502s03.jpg', N'https://i0.shbdn.com/photos/40/05/02/x5_1166400502s03.jpg', CAST(N'2019-05-12T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:37:27.117' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (4, 2, N'İphone 16 Pro', 2000, N'https://bsimg.nl/images/apple-iphone-16-pro-128gb-zwart-eu_1.png/z3EBGhIBQcCUDb3cj0JaADp8MMU%3D/fit-in/257x400/filters%3Aformat%28png%29%3Aupscale%28%29', N'https://bsimg.nl/images/apple-iphone-16-pro-128gb-zwart-eu_1.png/z3EBGhIBQcCUDb3cj0JaADp8MMU%3D/fit-in/257x400/filters%3Aformat%28png%29%3Aupscale%28%29', CAST(N'2025-10-10T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:37:47.317' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (5, 3, N'Mac Pro', 9000, N'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp16-silver-select-202410?wid=904&hei=840&fmt=png-alpha&.v=1728916322497', N'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp16-silver-select-202410?wid=904&hei=840&fmt=png-alpha&.v=1728916322497', CAST(N'2022-11-06T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:38:21.940' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (6, 3, N'Huawei D16', 6000, N'https://consumer.huawei.com/dam/content/dam/huawei-cbg-site/common/mkt/pdp/admin-image/pc/matebook-d-16-2024/list/list-silver.png', N'https://consumer.huawei.com/dam/content/dam/huawei-cbg-site/common/mkt/pdp/admin-image/pc/matebook-d-16-2024/list/list-silver.png', CAST(N'2025-06-06T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:38:42.357' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (7, 4, N'İktidar', 50, N'https://img.kitapyurdu.com/v1/getImage/fn:11753520/wh:true/miw:200/mih:200', N'https://img.kitapyurdu.com/v1/getImage/fn:11753520/wh:true/miw:200/mih:200', CAST(N'2024-04-04T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:38:58.860' AS DateTime), NULL)
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (9, 4, N'Savaş ve Barış', 40, N'https://img.kitapyurdu.com/v1/getImage/fn:1186755/wh:true/wi:500', N'https://img.kitapyurdu.com/v1/getImage/fn:1186755/wh:true/wi:500', CAST(N'2020-08-11T00:00:00.000' AS DateTime), CAST(N'2025-02-12T14:42:04.910' AS DateTime), N'test')
    GO
    INSERT [dbo].[İlanlar] ([Id], [KategoriId], [Baslik], [Fiyat], [ListeGorselURL], [DetayGorselURL], [EklenmeTarihi], [GuncellemeTarihi], [DetayYazisi]) VALUES (12, 7, N'Test', 1000, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdSvbwKZZAqE8SmUV3QD5Qy6M_epQuKkrfWw&s', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSdSvbwKZZAqE8SmUV3QD5Qy6M_epQuKkrfWw&s', CAST(N'2025-02-12T16:23:34.623' AS DateTime), NULL, NULL)
    GO
    SET IDENTITY_INSERT [dbo].[İlanlar] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Kategoriler] ON 
    GO
    INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi], [KategoriGorselURL]) VALUES (1, N'Otomobil', N'https://www.shutterstock.com/image-vector/car-icon-editable-vector-isolated-600nw-2478885391.jpg')
    GO
    INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi], [KategoriGorselURL]) VALUES (2, N'Telefon', N'https://static.vecteezy.com/system/resources/thumbnails/003/720/476/small_2x/phone-icon-telephone-icon-symbol-for-app-and-messenger-vector.jpg')
    GO
    INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi], [KategoriGorselURL]) VALUES (3, N'Bilgisayar', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxXsF4PNq18RXAaW-iCW3GmZa3hIj5cD7Pbw&s')
    GO
    INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi], [KategoriGorselURL]) VALUES (4, N'Kitap', N'https://cdn-icons-png.flaticon.com/512/4/4259.png')
    GO
    INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi], [KategoriGorselURL]) VALUES (7, N'Çoçuk', N'https://cdn-icons-png.flaticon.com/512/4436/4436481.png')
    GO
    SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
    GO

   ```

4. **Projeyi çalıştırın:**
   ```sh
   dotnet run
   ```
---

🎯 Geliştirmelere katkıda bulunmak isterseniz pull request gönderebilirsiniz!

