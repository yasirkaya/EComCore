import { api } from "./api";
import {
  AuthResponse,
  LoginCredentials,
  RegisterCredentials,
} from "../types/auth";
import { cartService } from "./cart.service";
import {
  setUser,
  setToken,
  logout as logoutAction,
} from "../store/slices/authSlice";
import { AppDispatch } from "../store/store";

export const authService = {
  async login(
    credentials: LoginCredentials,
    dispatch: AppDispatch
  ): Promise<AuthResponse> {
    const { data } = await api.post<AuthResponse>("/Auths/login", {
      loginDto: credentials,
    });
    dispatch(setToken(data.token));
    console.log(data.token);
    dispatch(setUser(data.user));
    return data;
  },

  async register(
    credentials: RegisterCredentials,
    dispatch: AppDispatch
  ): Promise<AuthResponse> {
    const { data } = await api.post<AuthResponse>(
      "/auths/register",
      credentials
    );
    dispatch(setToken(data.token));
    dispatch(setUser(data.user));
    return data;
  },

  async forgotPassword(email: string): Promise<void> {
    await api.post("/auths/forgot-password", { email });
  },

  async resetPassword(token: string, newPassword: string): Promise<void> {
    await api.post("/auths/reset-password", { token, newPassword });
  },

  logout(dispatch: AppDispatch) {
    dispatch(logoutAction());
  },

  async getCurrentUser(dispatch: AppDispatch): Promise<AuthResponse> {
    const { data } = await api.get<AuthResponse>("/auths/me");
    dispatch(setToken(data.token));
    dispatch(setUser(data.user));

    return data;
  },
};
