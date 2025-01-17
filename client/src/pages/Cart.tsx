import React, { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { useAppDispatch } from '../store/hooks';
import {
  Container,
  Table,
  Button,
  Image,
  Form,
} from 'react-bootstrap';
import { RootState } from '../store/store';
import {
  fetchCart,
  updateCartItem,
  removeFromCart,
} from '../store/cartSlice';

const Cart: React.FC = () => {
  const dispatch = useAppDispatch();
  const { cart, loading } = useSelector((state: RootState) => state.cart);

  useEffect(() => {
    dispatch(fetchCart());
  }, [dispatch]);

  const handleQuantityChange = (productId: number, quantity: number) => {
    if (quantity > 0) {
      dispatch(updateCartItem({ productId, quantity }));
    } else {
      dispatch(removeFromCart(productId));
    }
  };

  const handleRemoveItem = (productId: number) => {
    dispatch(removeFromCart(productId));
  };

  if (loading) {
    return <div>Loading...</div>;
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
                    src={item.product?.imageUrl}
                    alt={item.product?.name}
                    width={50}
                    height={50}
                    className="me-3"
                  />
                  <span>{item.product?.name}</span>
                </div>
              </td>
              <td>{item.product?.price} TL</td>
              <td style={{ width: '150px' }}>
                <Form.Control
                  type="number"
                  min="1"
                  value={item.quantity}
                  onChange={(e) =>
                    handleQuantityChange(item.productId, parseInt(e.target.value))
                  }
                />
              </td>
              <td>{(item.product?.price || 0) * item.quantity} TL</td>
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
              <strong>{cart.total} TL</strong>
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

export default Cart;
