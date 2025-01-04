# EComCore Backend Projesi

## 📋 Proje Hakkında

EComCore, modern e-ticaret uygulamaları için geliştirilmiş bir backend çözümüdür. Clean Architecture prensiplerine uygun olarak geliştirilmiş olup, modüler ve sürdürülebilir bir yapıya sahiptir.

## 🏗️ Proje Yapısı

Proje, Clean Architecture prensiplerine uygun olarak dört ana katmandan oluşmaktadır:

### EComCore.Domain

- Temel iş mantığını ve varlıkları içerir
- DTO'lar ve entity'ler burada tanımlanır
- Repository interface'leri burada bulunur

### EComCore.Application

- İş mantığının uygulandığı katman
- CQRS pattern'i ile komut ve sorgular
- AutoMapper profilleri
- Servis katmanı implementasyonları

### EComCore.Infrastructure

- Veritabanı işlemleri
- Repository implementasyonları
- DbContext ve migration'lar
- Harici servis entegrasyonları

### EComCore.API

- REST API endpoints
- Controller'lar
- Middleware'ler
- API konfigürasyonları

## 🚀 Başlangıç

### Gereksinimler

- .NET 6.0 SDK veya üzeri
- SQL Server
- Visual Studio 2022 veya Visual Studio Code

### Kurulum

1. Projeyi klonlayın:

```bash
git clone [repository-url]
```

2. Backend klasörüne gidin:

```bash
cd Backend
```

3. Projeyi derleyin:

```bash
dotnet build
```

4. Veritabanını oluşturun:

```bash
dotnet ef database update
```

5. Projeyi çalıştırın:

```bash
dotnet run --project EComCore.API
```

## 🔄 API Endpoints

### Siparişler (Orders)

- `GET /api/orders` - Tüm siparişleri listeler
- `GET /api/orders/{id}` - Belirli bir siparişi getirir
- `POST /api/orders` - Yeni sipariş oluşturur
- `PUT /api/orders/{id}` - Sipariş durumunu günceller
- `DELETE /api/orders/{id}` - Siparişi iptal eder

## 🛠️ Teknolojiler ve Araçlar

- ASP.NET Core 6.0
- Entity Framework Core
- AutoMapper
- MediatR (CQRS implementasyonu için)
- SQL Server
- Swagger/OpenAPI

## 📦 Mimari Özellikler

- Clean Architecture
- CQRS Pattern
- Repository Pattern
- Dependency Injection
- Domain Driven Design (DDD) prensipleri

## 🔒 Güvenlik

- JWT Authentication
- Role-based Authorization
- Input Validation
- Cross-Origin Resource Sharing (CORS) politikaları

## 📝 Lisans

Bu proje [MIT] lisansı altında lisanslanmıştır.
