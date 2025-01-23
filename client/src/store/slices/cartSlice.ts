import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { Cart, cartService } from "../../services/cart.service";

interface CartState {
  cart: Cart | null;
  loading: boolean;
  error: string | null;
}

const initialState: CartState = {
  cart: null,
  loading: false,
  error: null,
};

export const fetchCart = createAsyncThunk("cart/fetchCart", async () => {
  const cart = await cartService.getCart();
  return cart;
});

export const addToCart = createAsyncThunk(
  "cart/addToCart",
  async ({ productId, quantity }: { productId: number; quantity: number }) => {
    const cart = await cartService.addToCart(productId, quantity);
    return cart;
  }
);

export const updateCartItem = createAsyncThunk(
  "cart/updateCartItem",
  async ({ productId, quantity }: { productId: number; quantity: number }) => {
    const cart = await cartService.updateCartItem(productId, quantity);
    return cart;
  }
);

export const removeFromCart = createAsyncThunk(
  "cart/removeFromCart",
  async (productId: number) => {
    const cart = await cartService.removeFromCart(productId);
    return cart;
  }
);

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      // fetchCart
      .addCase(fetchCart.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchCart.fulfilled, (state, action) => {
        state.loading = false;
        state.cart = action.payload;
      })
      .addCase(fetchCart.rejected, (state, action) => {
        state.loading = false;
        state.error =
          action.error.message || "Sepet verileri alınırken bir hata oluştu.";
      })

      // addToCart
      .addCase(addToCart.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(addToCart.fulfilled, (state, action) => {
        state.loading = false;
        state.cart = action.payload;
      })
      .addCase(addToCart.rejected, (state, action) => {
        state.loading = false;
        state.error =
          action.error.message || "Ürün sepete eklenirken bir hata oluştu.";
      })

      // updateCartItem
      .addCase(updateCartItem.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(updateCartItem.fulfilled, (state, action) => {
        state.loading = false;
        state.cart = action.payload;
      })
      .addCase(updateCartItem.rejected, (state, action) => {
        state.loading = false;
        state.error =
          action.error.message || "Sepet öğesi güncellenirken bir hata oluştu.";
      })

      // removeFromCart
      .addCase(removeFromCart.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(removeFromCart.fulfilled, (state, action) => {
        state.loading = false;
        state.cart = action.payload;
      })
      .addCase(removeFromCart.rejected, (state, action) => {
        state.loading = false;
        state.error =
          action.error.message || "Ürün sepetten çıkarılırken bir hata oluştu.";
      });
  },
});

export default cartSlice.reducer;
