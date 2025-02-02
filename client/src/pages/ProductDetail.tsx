import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { productService } from "../services/product.service";
import { Product } from "../types/product";
import {
  Container,
  Row,
  Col,
  Image,
  Button,
  Alert,
  ListGroup,
} from "react-bootstrap";
import { cartService } from "../services/cart.service";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../store/store";
import { addToCart, fetchCart } from "../store/slices/cartSlice";

// Örnek yorum verisi
interface Review {
  id: number;
  userName: string;
  rating: number;
  comment: string;
  date: string;
}

const sampleReviews: Review[] = [
  {
    id: 1,
    userName: "Ali Veli",
    rating: 4,
    comment: "Ürün gayet başarılı, tavsiye ederim.",
    date: "2025-01-25",
  },
  {
    id: 2,
    userName: "Ayşe Yılmaz",
    rating: 5,
    comment: "Beklentilerimi tamamen karşıladı, mükemmel!",
    date: "2025-01-20",
  },
  {
    id: 3,
    userName: "Mehmet Demir",
    rating: 3,
    comment: "Fiyatına göre iyiydi ama biraz daha kaliteli olabilirdi.",
    date: "2025-01-18",
  },
];

const ProductDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);
  const [addingToCart, setAddingToCart] = useState(false);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const [reviews, setReviews] = useState<Review[]>([]);
  const [averageRating, setAverageRating] = useState<number>(0);
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        if (id) {
          const data = await productService.getProductById(parseInt(id));
          setProduct(data);
        }
      } catch (error) {
        console.error("Error fetching product:", error);
        setErrorMessage("Ürün bilgileri yüklenirken bir hata oluştu.");
      } finally {
        setLoading(false);
      }
    };

    // Ürün verisini çek
    fetchProduct();

    // Örnek yorumları ayarla (API'den çekilecekse burası değiştirilebilir)
    setReviews(sampleReviews);
  }, [id]);

  useEffect(() => {
    if (reviews.length > 0) {
      const total = reviews.reduce((sum, review) => sum + review.rating, 0);
      setAverageRating(Number((total / reviews.length).toFixed(1)));
    }
  }, [reviews]);

  const handleAddToCart = async () => {
    if (product) {
      try {
        setAddingToCart(true);
        setSuccessMessage(null);
        setErrorMessage(null);

        await dispatch(
          addToCart({ productId: parseInt(product.id), quantity: 1 })
        );
        await dispatch(fetchCart()); // Sepet durumunu güncelle

        setSuccessMessage(`${product.name} sepete başarıyla eklendi`);
      } catch (error) {
        console.error("Sepete eklerken bir hata oluştu:", error);
        setErrorMessage(
          "Ürün sepete eklenirken bir hata oluştu. Lütfen tekrar deneyin."
        );
      } finally {
        setAddingToCart(false);
      }
    }
  };

  // Yıldızları render eden yardımcı fonksiyon
  const renderStars = (rating: number) => {
    const fullStars = Math.floor(rating);
    const halfStar = rating % 1 !== 0;
    const emptyStars = 5 - fullStars - (halfStar ? 1 : 0);

    return (
      <>
        {[...Array(fullStars)].map((_, index) => (
          <i key={index} className="fas fa-star text-warning"></i>
        ))}
        {halfStar && <i className="fas fa-star-half-alt text-warning"></i>}
        {[...Array(emptyStars)].map((_, index) => (
          <i key={index} className="far fa-star text-warning"></i>
        ))}
      </>
    );
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (!product) {
    return <div>Product not found</div>;
  }

  return (
    <Container className="py-5">
      {successMessage && (
        <Alert
          variant="success"
          onClose={() => setSuccessMessage(null)}
          dismissible
        >
          {successMessage}
        </Alert>
      )}
      {errorMessage && (
        <Alert
          variant="danger"
          onClose={() => setErrorMessage(null)}
          dismissible
        >
          {errorMessage}
        </Alert>
      )}
      <Row>
        <Col md={6}>
          <Image
            src={process.env.PUBLIC_URL + "/urun.jpeg"}
            alt={product.name}
            fluid
          />
        </Col>
        <Col md={6}>
          <h1>{product.name}</h1>
          <div className="d-flex align-items-center mb-3">
            <div>{renderStars(averageRating)}</div>
            <span className="ms-2">({averageRating} / 5)</span>
          </div>
          <p className="text-muted">Kategori: {product.categoryId}</p>
          <h2 className="text-primary">{product.price} TL</h2>
          <p>{product.description}</p>
          <div className="d-grid gap-2 mb-3">
            <Button
              variant="primary"
              onClick={handleAddToCart}
              disabled={addingToCart}
            >
              {addingToCart ? "Sepete Ekleniyor..." : "Sepete Ekle"}
            </Button>
          </div>
        </Col>
      </Row>
      <Row className="mt-5">
        <Col>
          <h3>Ürün Yorumları</h3>
          {reviews.length > 0 ? (
            <ListGroup variant="flush">
              {reviews.map((review) => (
                <ListGroup.Item key={review.id} className="border-0 mb-3">
                  <div className="d-flex">
                    {/* Sol: Profil Alanı */}
                    <div className="me-3">
                      <div
                        style={{
                          width: "50px",
                          height: "50px",
                          borderRadius: "50%",
                          backgroundColor: "#007bff",
                          color: "white",
                          display: "flex",
                          alignItems: "center",
                          justifyContent: "center",
                          fontSize: "20px",
                        }}
                      >
                        {review.userName.charAt(0).toUpperCase()}
                      </div>
                    </div>
                    {/* Sağ: Yorum İçeriği */}
                    <div className="flex-grow-1">
                      <div className="mb-2 d-flex align-items-center">
                        <div className="me-2">{renderStars(review.rating)}</div>
                        <small className="text-muted">{review.date}</small>
                      </div>
                      <div
                        className="p-3"
                        style={{
                          backgroundColor: "#f1f1f1",
                          borderRadius: "10px",
                          border: "1px solid #e0e0e0",
                          width: "50%",
                        }}
                      >
                        {review.comment}
                      </div>
                    </div>
                  </div>
                </ListGroup.Item>
              ))}
            </ListGroup>
          ) : (
            <p>Henüz yorum yapılmamış.</p>
          )}
        </Col>
      </Row>
    </Container>
  );
};

export default ProductDetail;
