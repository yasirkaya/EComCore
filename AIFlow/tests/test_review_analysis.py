import unittest
from services.review_analysis import analyze_review

class TestReviewAnalysis(unittest.TestCase):
    def test_positive_review(self):
        review = "Bu ürün harika! Kesinlikle tavsiye ederim."
        result = analyze_review(review)
        self.assertIn(result, ["Onaylandı", "Kontrol Edilmeli"])  # API bazen farklı cevaplar verebilir

    def test_negative_review(self):
        review = "Çok kötü bir ürün, asla almayın!"
        result = analyze_review(review)
        self.assertIn(result, ["Onaylanmadı", "Kontrol Edilmeli"])

if __name__ == "__main__":
    unittest.main()
