# Base image olarak Node.js kullanıyoruz
FROM node:16

# Çalışma dizinini oluşturup ayarlıyoruz
WORKDIR /app

# Package dosyalarını container içine kopyalıyoruz
COPY package*.json ./

# Gerekli bağımlılıkları yükleyelim
RUN npm install

# Uygulamanın tüm dosyalarını kopyalayalım
COPY . .

# React uygulamasını build edelim
RUN npm run build

# Uygulamayı çalıştırmak için uygun portu açıyoruz
EXPOSE 3000

# Build sonrası, uygulamayı çalıştırıyoruz
CMD ["npm", "start"]
