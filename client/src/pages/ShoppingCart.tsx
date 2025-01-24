import React, { useEffect, useState } from "react";
import {
  Container,
  Table,
  Button,
  Image,
  Form,
  Spinner,
  Alert,
} from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../store/store";
import {
  fetchCart,
  updateCartItem,
  removeFromCart,
} from "../store/slices/cartSlice";
import { AppDispatch } from "../store/store";

const ShoppingCart: React.FC = () => {
  const dispatch: AppDispatch = useDispatch();
  const { cart, loading, error } = useSelector(
    (state: RootState) => state.cart
  );

  useEffect(() => {
    dispatch(fetchCart());
  }, [dispatch]);

  const handleQuantityChange = async (productId: number, quantity: number) => {
    if (quantity < 1) return; // Miktar 1'den küçük olamaz
    await dispatch(updateCartItem({ productId, quantity }));
    dispatch(fetchCart()); // Güncel sepet durumunu al
  };

  const handleRemoveItem = async (productId: number) => {
    await dispatch(removeFromCart(productId));
    dispatch(fetchCart()); // Güncel sepet durumunu al
  };

  const totalAmount = cart?.items?.reduce(
    (total, item) => total + item.totalPrice,
    0
  ) ?? 0;

  if (loading) {
    return (
      <Container className="py-5 text-center">
        <Spinner animation="border" />
        <p>Sepet yükleniyor...</p>
      </Container>
    );
  }

  if (error) {
    return (
      <Container className="py-5">
        <Alert variant="danger">{error}</Alert>
      </Container>
    );
  }

  if (!cart || cart.items.length === 0) {
    return (
      <Container className="py-5">
        <h1>Sepetiniz</h1>
        <p>Sepetiniz boş.</p>
      </Container>
    );
  }

  return (
    <Container className="py-5">
      <h1>Sepetiniz</h1>
      <Table responsive>
        <thead>
          <tr>
            <th>Ürün</th>
            <th>Fiyat</th>
            <th>Adet</th>
            <th>Toplam</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {cart.items.map((item) => (
            <tr key={item.productId}>
              <td>
                <div className="d-flex align-items-center">
                  <Image
                    src={process.env.PUBLIC_URL + "urun.jpeg"}
                    alt={item.productName}
                    width={50}
                    height={50}
                    className="me-3"
                  />
                  <span>{item.productName}</span>
                </div>
              </td>
              <td>{item.unitPrice} TL</td>
              <td style={{ width: "150px" }}>
                <Form.Control
                  type="number"
                  min="1"
                  value={item.quantity}
                  onChange={(e) =>
                    handleQuantityChange(
                      item.productId,
                      parseInt(e.target.value)
                    )
                  }
                />
              </td>
              <td>{item.totalPrice} TL</td>
              <td>
                <Button
                  variant="danger"
                  size="sm"
                  onClick={() => handleRemoveItem(item.productId)}
                >
                  Kaldır
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
        <tfoot>
          <tr>
            <td colSpan={3} className="text-end">
              <strong>Toplam:</strong>
            </td>
            <td>
              <strong>{totalAmount} TL</strong>
            </td>
            <td></td>
          </tr>
        </tfoot>
      </Table>
      <div className="d-flex justify-content-end">
        <Button variant="primary" size="lg">
          Siparişi Tamamla
        </Button>
      </div>
    </Container>
  );
};

export default ShoppingCart;
