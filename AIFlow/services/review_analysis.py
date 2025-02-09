import os
import requests
from dotenv import load_dotenv

# Ortam değişkenlerini yükle
load_dotenv()

GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")
GEMINI_API_URL = f"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={GEMINI_API_KEY}"

def analyze_review(review_text: str) -> str:
    """
    Kullanıcı yorumunu analiz ederek "Onaylandı", "Onaylanmadı" veya "Kontrol Edilmeli" sonucunu döndürür.
    Hakaret, küfür, spam içeriyorsa onaylanmaz.
    """
    prompt = f"""
    Aşağıdaki kullanıcı yorumunu analiz et ve uygun bir şekilde sınıflandır:
    
     **Onaylandı:** Yorumda herhangi bir hakaret, küfür, spam veya kötü niyetli içerik yoksa.
     **Onaylanmadı:** Yorumda hakaret, küfür, spam veya kötü niyetli içerik varsa.
     **Kontrol Edilmeli:** Yorum anlam açısından belirsizse veya insan onayına ihtiyaç duyuyorsa.
    
    **Kullanıcı Yorumu:** {review_text}
    
    Sadece **Onaylandı**, **Onaylanmadı** veya **Kontrol Edilmeli** şeklinde bir çıktı döndür.
    """

    headers = {"Content-Type": "application/json"}
    payload = {
        "contents": [{"parts": [{"text": prompt}]}]
    }

    response = requests.post(GEMINI_API_URL, headers=headers, json=payload)

    if response.status_code == 200:
        try:
            result = response.json()
            return result["candidates"][0]["content"]["parts"][0]["text"].strip()
        except (KeyError, IndexError):
            return "Kontrol Edilmeli"
    else:
        return "Kontrol Edilmeli"