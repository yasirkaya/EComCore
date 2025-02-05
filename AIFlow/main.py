from fastapi import FastAPI
from api.review import router as review_router

app = FastAPI()

app.include_router(review_router, prefix="/review")

@app.get("/")
def read_root():
    return {"message": "AIFlow API is running!"}
