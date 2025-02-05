import requests
from config import GEMINI_API_KEY

GEMINI_URL = f"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={GEMINI_API_KEY}"

def analyze_review(review_text: str) -> str:
    """
    Kullanıcı yorumunu analiz etmek için Gemini API'yi çağırır.
    """
    payload = {
        "contents": [{
            "parts": [{"text": review_text}]
        }]
    }
    
    headers = {"Content-Type": "application/json"}
    
    response = requests.post(GEMINI_URL, json=payload, headers=headers)

    if response.status_code == 200:
        result = response.json()
        return result["candidates"][0]["content"]["parts"][0]["text"]
    else:
        return f"Error: {response.status_code}, {response.text}"
