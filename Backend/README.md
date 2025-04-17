# EComCore Backend

## 📋 Proje Hakkında

EComCore Backend, e-ticaret platformunun temel iş mantığını ve API'lerini içeren .NET Core tabanlı bir uygulamadır. Clean Architecture prensiplerine uygun olarak geliştirilmiştir.

## 🏗️ Proje Yapısı

### EComCore.Domain

- Entity sınıfları (Product, Order, User, vb.)
- Repository interface'leri
- Enum'lar ve sabitler
- Domain event'ler

### EComCore.Application

- CQRS pattern implementasyonu
- MediatR komutları ve sorguları
- AutoMapper profilleri
- FluentValidation kuralları
- DTO'lar

### EComCore.Infrastructure

- Entity Framework Core implementasyonu
- Repository implementasyonları
- Veritabanı migration'ları
- JWT Authentication servisleri
- Email servisleri

### EComCore.API

- REST API endpoints
- Controller'lar
- Middleware'ler
- Swagger/OpenAPI dökümantasyonu
- CORS konfigürasyonları

## 🚀 Başlangıç

### Gereksinimler

- .NET 6.0 SDK
- SQL Server
- Visual Studio 2022 veya VS Code

### Kurulum

1. Projeyi klonlayın:

```bash
git clone [repository-url]
```

2. Backend klasörüne gidin:

```bash
cd Backend
```

3. Bağımlılıkları yükleyin:

```bash
dotnet restore
```

4. Veritabanını oluşturun:

```bash
dotnet ef database update --project EComCore.Infrastructure
```

5. Uygulamayı çalıştırın:

```bash
dotnet run --project EComCore.API
```

## 📦 Özellikler

- JWT tabanlı kimlik doğrulama
- Rol tabanlı yetkilendirme
- Ürün ve varyant yönetimi
- Sipariş işlemleri
- Ödeme entegrasyonları
- Kargo takip sistemi
- Kullanıcı yönetimi
- Kategori yönetimi
- Ürün değerlendirme sistemi

## 🛠️ Teknolojiler

- ASP.NET Core 6.0
- Entity Framework Core
- SQL Server
- MediatR
- AutoMapper
- FluentValidation
- JWT Authentication
- Swagger/OpenAPI
- Docker

## 🔄 API Endpoints

### Siparişler (Orders)

- `GET /api/orders` - Tüm siparişleri listeler
- `GET /api/orders/{id}` - Belirli bir siparişi getirir
- `POST /api/orders` - Yeni sipariş oluşturur
- `PUT /api/orders/{id}` - Sipariş durumunu günceller
- `DELETE /api/orders/{id}` - Siparişi iptal eder

## 📝 Lisans

Bu proje [MIT] lisansı altında lisanslanmıştır.
