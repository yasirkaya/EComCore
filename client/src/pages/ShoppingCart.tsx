import React, { useEffect, useState } from "react";
import { Container, Table, Button, Image, Form } from "react-bootstrap";
import { Cart, CartItem, cartService } from "services/cart.service";

const ShoppingCart: React.FC = () => {
  const [cart, setCart] = useState<Cart | null>(null);

  useEffect(() => {
    const fetchCart = async () => {
      const storedCart = await cartService.getCart();
      if (storedCart) {
        setCart(storedCart);
      } else {
        setCart(null);
      }
    };

    fetchCart();
  }, []);

  const handleQuantityChange = (productId: number, quantity: number) => {
    cartService.updateCartItem(productId, quantity);
  };

  const handleRemoveItem = (productId: number) => {
    cartService.removeFromCart(productId);
  };

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
              <strong>{222} TL</strong>
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
