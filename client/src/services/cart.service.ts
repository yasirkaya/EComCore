import { api } from "./api";

export interface CartItem {
  productId: number;
  quantity: number;
  productName: string;
  unitPrice: number;
  totalPrice: number;
}

export interface Cart {
  id: number;
  userId: number;
  items: CartItem[];
}

class CartService {
  async getCart() {
    const localCart = localStorage.getItem("cart");
    if (localCart) {
      return JSON.parse(localCart);
    } else {
      const response = await api.get<Cart>("/cart");
      localStorage.setItem("cart", JSON.stringify(response.data));
      console.log(localStorage.getItem("cart"));
      return response.data;
    }
  }

  async addToCart(productId: number, quantity: number = 1) {
    const response = await api.post<Cart>(`/cart/items`, {
      productId,
      quantity,
    });

    const cartString = localStorage.getItem("cart");
    const cart = cartString ? JSON.parse(cartString) : { items: [] };

    if (!Array.isArray(cart.items)) {
      cart.items = [];
    }

    const existingItemIndex = cart.items.findIndex(
      (item: CartItem) => item.productId === productId
    );

    if (existingItemIndex !== -1) {
      cart.items[existingItemIndex].quantity += quantity;
    } else {
      await cartService.getCart().then((newCart) => {
        if (newCart && newCart.items) {
          const newCartItem = newCart.items.find(
            (item: CartItem) => item.productId === productId
          );
          cart.items.push(newCartItem);
        } else {
          console.error("Sepet verileri alınamadı!");
        }
      });
    }

    localStorage.setItem("cart", JSON.stringify(cart));

    return response.data;
  }

  async updateCartItem(productId: number, quantity: number) {
    const response = await api.put<Cart>(`/cart/items`, {
      quantity,
      productId,
    });

    const cartString = localStorage.getItem("cart");
    const cart = cartString ? JSON.parse(cartString) : { items: [] };

    if (!Array.isArray(cart.items)) {
      cart.items = [];
    }

    const itemIndex = cart.items.findIndex(
      (item: CartItem) => item.productId === productId
    );
    if (itemIndex !== -1) {
      cart.items[itemIndex].quantity = quantity;
      localStorage.setItem("cart", JSON.stringify(cart));
    }

    return response.data;
  }

  async removeFromCart(productId: number) {
    const response = await api.delete<Cart>(`/cart/items/${productId}`);

    const cart = JSON.parse(localStorage.getItem("cart") || "{}");
    const filteredItems = cart.items.filter(
      (item: CartItem) => item.productId !== productId
    );
    cart.items = filteredItems;
    localStorage.setItem("cart", JSON.stringify(cart));

    return response.data;
  }
}

export const cartService = new CartService();
