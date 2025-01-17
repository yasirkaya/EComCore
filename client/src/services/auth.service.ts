import { api } from './api';
import { AuthResponse, LoginCredentials, RegisterCredentials } from '../types/auth';

export const authService = {
  async login(credentials: LoginCredentials): Promise<AuthResponse> {
    const { data } = await api.post<AuthResponse>('/auth/login', credentials);
    localStorage.setItem('token', data.token);
    return data;
  },

  async register(credentials: RegisterCredentials): Promise<AuthResponse> {
    const { data } = await api.post<AuthResponse>('/auth/register', credentials);
    localStorage.setItem('token', data.token);
    return data;
  },

  async forgotPassword(email: string): Promise<void> {
    await api.post('/auth/forgot-password', { email });
  },

  async resetPassword(token: string, newPassword: string): Promise<void> {
    await api.post('/auth/reset-password', { token, newPassword });
  },

  logout() {
    localStorage.removeItem('token');
  },

  async getCurrentUser(): Promise<AuthResponse> {
    const { data } = await api.get<AuthResponse>('/auth/me');
    return data;
  },
};
