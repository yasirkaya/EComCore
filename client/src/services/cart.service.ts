import axios from 'axios';
import { api } from './api';

export interface CartItem {
  productId: number;
  quantity: number;
  product?: {
    id: number;
    name: string;
    price: number;
    imageUrl: string;
  };
}

export interface Cart {
  id: number;
  userId: number;
  items: CartItem[];
  total: number;
}

class CartService {
  async getCart() {
    const response = await api.get<Cart>(`/cart`);
    return response.data;
  }

  async addToCart(productId: number, quantity: number = 1) {
    const response = await api.post<Cart>(`/cart/items`, {
      productId,
      quantity,
    });
    return response.data;
  }

  async updateCartItem(productId: number, quantity: number) {
    const response = await api.put<Cart>(`/cart/items/${productId}`, {
      quantity,
    });
    return response.data;
  }

  async removeFromCart(productId: number) {
    const response = await api.delete<Cart>(`/cart/items/${productId}`);
    return response.data;
  }
}

export const cartService = new CartService();
