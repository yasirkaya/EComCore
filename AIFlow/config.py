import os
from dotenv import load_dotenv

# .env dosyasını yükleyelim
load_dotenv()

# API anahtarını alalım
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")
