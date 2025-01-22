import { api } from "./api";
import {
  AuthResponse,
  LoginCredentials,
  RegisterCredentials,
} from "../types/auth";
import { cartService } from "./cart.service";

export const authService = {
  async login(credentials: LoginCredentials): Promise<AuthResponse> {
    const { data } = await api.post<AuthResponse>("/Auths/login", {
      loginDto: credentials,
    });
    localStorage.setItem("token", data.token);
    const cart = await cartService.getCart();
    localStorage.setItem("cart", JSON.stringify(cart));
    return data;
  },

  async register(credentials: RegisterCredentials): Promise<AuthResponse> {
    const { data } = await api.post<AuthResponse>(
      "/auths/register",
      credentials
    );
    localStorage.setItem("token", data.token);
    return data;
  },

  async forgotPassword(email: string): Promise<void> {
    await api.post("/auths/forgot-password", { email });
  },

  async resetPassword(token: string, newPassword: string): Promise<void> {
    await api.post("/auths/reset-password", { token, newPassword });
  },

  logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("cart");
  },

  async getCurrentUser(): Promise<AuthResponse> {
    const { data } = await api.get<AuthResponse>("/auths/me");
    return data;
  },
};
