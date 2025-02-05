from fastapi import APIRouter
from services.gemini_service import analyze_review

router = APIRouter()

@router.post("/analyze_review")
def analyze_user_review(review: str):
    result = analyze_review(review)
    return {"review": review, "analysis": result}
