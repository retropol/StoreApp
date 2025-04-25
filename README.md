# E-Ticaret Mağazası Uygulaması

ASP.NET Core ile geliştirilmiş modern temel bir e-ticaret web uygulaması.

## 🚀 Özellikler

- Ürün kataloğu ve kategori yönetimi
- Sepet işlemleri (ekleme, çıkarma, miktar güncelleme)
- Oturum tabanlı sepet yönetimi
- Responsive tasarım

## 🛠️ Kullanılan Teknolojiler

- **Backend**: ASP.NET Core 9.0 (MVC, Razor Pages)
- **Veritabanı**: SQLite + Entity Framework Core
- **Frontend**: Bootstrap 5
- **Mimari**: Clean Architecture, Repository Pattern

## 📦 Proje Yapısı

```
StoreApp/
├── Controllers/     # MVC Kontrolcüleri
├── Models/         # Veri Modelleri
├── Views/          # Razor Görünümleri
├── Pages/          # Razor Sayfaları
├── Components/     # Görünüm Bileşenleri
├── Data/           # Veri Erişim Katmanı
└── wwwroot/        # Statik Dosyalar
```

## 🚀 Başlangıç

1. Projeyi klonlayın
```bash
git clone [repository-url]
```

2. Bağımlılıkları yükleyin
```bash
dotnet restore
```

3. Veritabanını güncelleyin
```bash
dotnet ef database update
```

4. Uygulamayı başlatın
```bash
dotnet run
```

