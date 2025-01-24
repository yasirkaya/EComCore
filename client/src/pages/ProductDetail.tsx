import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { productService } from "../services/product.service";
import { Product } from "../types/product";
import { Container, Row, Col, Image, Button, Alert } from "react-bootstrap";
import { cartService } from "../services/cart.service";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../store/store";
import { addToCart, fetchCart } from "../store/slices/cartSlice";

const ProductDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);
  const [addingToCart, setAddingToCart] = useState(false);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
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

    fetchProduct();
  }, [id]);

  const handleAddToCart = async () => {
    if (product) {
      try {
        setAddingToCart(true);
        setSuccessMessage(null);
        setErrorMessage(null);
        
        await dispatch(addToCart({ productId: parseInt(product.id), quantity: 1 }));
        await dispatch(fetchCart()); // Sepet durumunu güncelle
        
        setSuccessMessage(`${product.name} sepete başarıyla eklendi`);
      } catch (error) {
        console.error("Sepete eklerken bir hata oluştu:", error);
        setErrorMessage("Ürün sepete eklenirken bir hata oluştu. Lütfen tekrar deneyin.");
      } finally {
        setAddingToCart(false);
      }
    }
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
        <Alert variant="success" onClose={() => setSuccessMessage(null)} dismissible>
          {successMessage}
        </Alert>
      )}
      {errorMessage && (
        <Alert variant="danger" onClose={() => setErrorMessage(null)} dismissible>
          {errorMessage}
        </Alert>
      )}
      <Row>
        <Col md={6}>
          <Image
            src={process.env.PUBLIC_URL + "urun.jpeg"}
            alt={product.name}
            fluid
          />
        </Col>
        <Col md={6}>
          <h1>{product.name}</h1>
          <p className="text-muted">{product.categoryId}</p>
          <h2 className="text-primary">{product.price} TL</h2>
          <p>{product.description}</p>
          <div className="d-grid gap-2">
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
    </Container>
  );
};

export default ProductDetail;
