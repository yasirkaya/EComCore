import React, { useCallback, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { productService } from "../services/product.service";
import { reviewService } from "../services/review.service";
import { Product } from "../types/product";
import { Review } from "../types/review";
import {
  Container,
  Row,
  Col,
  Image,
  Button,
  Alert,
  ListGroup,
  Form,
  Modal,
} from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../store/store";
import { addToCart, fetchCart } from "../store/slices/cartSlice";
import ReactStars from "react-rating-stars-component";

const ProductDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);
  const [addingToCart, setAddingToCart] = useState(false);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const [reviews, setReviews] = useState<Review[]>([]);
  const [averageRating, setAverageRating] = useState<number>(0);
  const [newReview, setNewReview] = useState<string>("");
  const [newRating, setNewRating] = useState<number>(5);
  const [showModal, setShowModal] = useState(false);
  const { user } = useSelector((state: RootState) => state.auth);
  const dispatch = useDispatch<AppDispatch>();

  const fetchProduct = useCallback(async () => {
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
  }, [id]);

  const fetchReviews = useCallback(async () => {
    try {
      if (id) {
        const data = await reviewService.getReviewsByProductId(parseInt(id));
        setReviews(data);
      }
    } catch (error) {
      console.error("Error fetching reviews:", error);
      setErrorMessage("Yorumlar yüklenirken bir hata oluştu.");
    }
  }, [id]);

  useEffect(() => {
    fetchProduct();
    fetchReviews();
  }, [id, fetchProduct, fetchReviews]);

  useEffect(() => {
    if (reviews.length > 0) {
      const total = reviews.reduce((sum, review) => sum + review.rating, 0);
      setAverageRating(Number((total / reviews.length).toFixed(1)));
    }
    console.log("Reviews updated:", reviews);
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

  const handleReviewSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (id) {
      try {
        const newReviewData = {
          productId: parseInt(id),
          userId: parseInt(user?.id || "0"),
          comment: newReview,
          rating: newRating,
        };
        await reviewService.createReview(newReviewData);
        fetchReviews();
        setNewReview("");
        setNewRating(5);
        setSuccessMessage("Yorum başarıyla eklendi.");
        setShowModal(false);
      } catch (error) {
        console.error("Error creating review:", error);
        setErrorMessage("Yorum eklenirken bir hata oluştu.");
        setShowModal(false);
      }
    }
  };

  const handleRatingChange = (newRating: number) => {
    setNewRating(newRating);
  };

  // Yıldızları render eden yardımcı fonksiyon
  const renderStars = (rating: number) => {
    if (isNaN(rating) || rating < 0 || rating > 5) {
      return null; // Geçersiz rating değeri için null döndür
    }

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
          <Button variant="primary" onClick={() => setShowModal(true)}>
            Değerlendir
          </Button>
          <Modal
            show={showModal}
            onHide={() => setShowModal(false)}
            style={{ marginTop: "100px" }}
          >
            <Modal.Header closeButton>
              <Modal.Title>Değerlendirme Yap</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Form onSubmit={handleReviewSubmit}>
                <Form.Group controlId="reviewRating">
                  <Form.Label>Değerlendirme</Form.Label>
                  <ReactStars
                    count={5}
                    onChange={handleRatingChange}
                    size={24}
                    activeColor="#ffd700"
                    value={newRating}
                  />
                </Form.Group>
                <Form.Group controlId="reviewComment" className="mt-3">
                  <Form.Label>Yorum</Form.Label>
                  <Form.Control
                    as="textarea"
                    rows={3}
                    value={newReview}
                    onChange={(e) => setNewReview(e.target.value)}
                  />
                </Form.Group>
                <Button variant="primary" type="submit" className="mt-3">
                  Yorum Yap
                </Button>
              </Form>
            </Modal.Body>
          </Modal>
          {reviews.length > 0 ? (
            <ListGroup variant="flush" className="mt-4">
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
                        {review.userName
                          ? review.userName.charAt(0).toUpperCase()
                          : "?"}
                      </div>
                    </div>
                    {/* Sağ: Yorum İçeriği */}
                    <div className="flex-grow-1">
                      <div className="mb-2 d-flex align-items-center">
                        <div className="me-2">{renderStars(review.rating)}</div>
                        <small className="text-muted">
                          {new Date(review.createdAt).toLocaleDateString(
                            "tr-TR"
                          )}
                        </small>
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
