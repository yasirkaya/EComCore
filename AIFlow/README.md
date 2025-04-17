# EComCore AIFlow

## 📋 Proje Hakkında

EComCore AIFlow, e-ticaret platformunun yapay zeka destekli yorum onay sistemini içeren bir modüldür. Kullanıcı yorumlarını otomatik olarak analiz eder ve uygunluk durumuna göre onay/red kararı verir.

## 🏗️ Proje Yapısı

- Python tabanlı AI/ML uygulaması
- FastAPI ile API servisleri
- PostgreSQL veritabanı
- Redis önbellek sistemi
- Test katmanı

## 🚀 Başlangıç

### Gereksinimler

- Python 3.9+
- pip veya conda
- PostgreSQL
- Redis

### Kurulum

1. Projeyi klonlayın:

```bash
git clone [repository-url]
```

2. AIFlow klasörüne gidin:

```bash
cd AIFlow
```

3. Sanal ortam oluşturun:

```bash
python -m venv venv
source venv/bin/activate  # Linux/Mac
# veya
venv\Scripts\activate  # Windows
```

4. Bağımlılıkları yükleyin:

```bash
pip install -r requirements.txt
```

5. Uygulamayı başlatın:

```bash
uvicorn main:app --reload
```

## 📦 Özellikler

- Otomatik yorum onay sistemi
  - Yorum içeriği analizi
  - Uygunsuz içerik tespiti
  - Spam kontrolü
  - Duygu analizi
  - Otomatik onay/red kararı

## 🛠️ Teknolojiler

- Python 3.9
- FastAPI
- PostgreSQL
- Redis
- Docker
