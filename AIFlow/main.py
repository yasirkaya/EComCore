from fastapi import FastAPI
from services.review_analysis import analyze_review
from pydantic import BaseModel

app = FastAPI()

class ReviewRequest(BaseModel):
    review_text: str

@app.post("/analyze_review")
async def analyze_review_endpoint(review: ReviewRequest):

    result = analyze_review(review.review_text)
    return {"result": result}
