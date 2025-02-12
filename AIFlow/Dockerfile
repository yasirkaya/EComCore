# Python base image kullanıyoruz
FROM python:3.9

# Çalışma dizinini oluşturup ayarlıyoruz
WORKDIR /app

# Gereksinimlerinizi belirten requirements.txt dosyasını kopyalayalım
COPY requirements.txt .

# Bağımlılıkları yükleyelim
RUN pip install --no-cache-dir -r requirements.txt

# AIFlow dosyalarını kopyalayalım
COPY . .

# Uygulamanın çalışacağı portu açıyoruz
EXPOSE 8000

# Uygulama çalıştırma komutunu ekliyoruz (FastAPI örneği)
CMD ["uvicorn", "main:app", "--host", "0.0.0.0", "--port", "8000"]
