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
import { useNavigate } from "react-router-dom";
import CheckoutSteps from "../components/CheckoutSteps";
import { orderService } from "../services/order.service";

const ShoppingCart: React.FC = () => {
  const dispatch: AppDispatch = useDispatch();
  const navigate = useNavigate();
  const { cart, loading, error } = useSelector(
    (state: RootState) => state.cart
  );
  const [showCheckout, setShowCheckout] = useState(false);
  const { user } = useSelector((state: RootState) => state.auth);

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

  const totalAmount =
    cart?.items?.reduce((total, item) => total + item.totalPrice, 0) ?? 0;

  const handleCheckoutComplete = async (address: any) => {
    try {
      const response = await orderService.createOrder({
        addressId: address.id,
        items:
          cart?.items.map((item) => ({
            productId: item.productId,
            quantity: item.quantity,
          })) || [],
        totalAmount: totalAmount,
        userId: parseInt(user?.id || "0"),
        shipmentId: 0,
      });

      if (response.success) {
        // Sepeti temizle ve ana sayfaya yönlendir
        dispatch(fetchCart());
        navigate("/");
      } else {
        throw new Error(
          response.message || "Sipariş oluşturulurken bir hata oluştu"
        );
      }
    } catch (error) {
      console.error("Sipariş oluşturma hatası:", error);
      // Hata durumunda kullanıcıya bilgi verilebilir
    }
  };

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
      {!showCheckout ? (
        <>
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
          <div className="d-flex justify-content-end mt-3">
            <div className="text-end">
              <h4>Toplam: {totalAmount} TL</h4>
              <Button
                variant="primary"
                onClick={() => setShowCheckout(true)}
                disabled={cart.items.length === 0}
              >
                Siparişi Tamamla
              </Button>
            </div>
          </div>
        </>
      ) : (
        <CheckoutSteps
          onComplete={handleCheckoutComplete}
          onCancel={() => setShowCheckout(false)}
          totalAmount={totalAmount}
        />
      )}
    </Container>
  );
};

export default ShoppingCart;
