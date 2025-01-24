import axios, { AxiosError } from "axios";
import { setUser, setToken, logout as logoutAction } from "../store/slices/authSlice";
import { store } from '../store/store';

const BASE_URL = "http://localhost:5292/api";

// API istemcisini oluştur
export const api = axios.create({
  baseURL: BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
  timeout: 10000, // 10 saniye timeout
});

// İstek interceptor'u
api.interceptors.request.use(
  (config) => {
    const token = store.getState().auth.token;
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Yanıt interceptor'u
api.interceptors.response.use(
  (response) => response,
  async (error: AxiosError) => {
    const originalRequest = error.config;

    // Token hatası durumunda
    if (error.response?.status === 401) {
      // Store üzerinden logout action'ı dispatch et
      store.dispatch(logoutAction());
      
      // Local storage'ı temizle
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      
      // Login sayfasına yönlendir
      if (window.location.pathname !== "/login") {
        window.location.href = "/login";
      }
    }

    // Sunucu hatası durumunda
    if (error.response?.status === 500) {
      console.error("Sunucu hatası:", error);
    }

    // Network hatası durumunda
    if (error.message === "Network Error") {
      console.error("Network hatası: Sunucuya erişilemiyor");
    }

    // Timeout hatası durumunda
    if (error.code === "ECONNABORTED") {
      console.error("İstek zaman aşımına uğradı");
    }

    return Promise.reject(error);
  }
);

// API hata mesajlarını işleme
export const handleApiError = (error: any): string => {
  if (axios.isAxiosError(error)) {
    // Sunucudan gelen hata mesajı
    const serverError = error.response?.data?.message;
    if (serverError) return serverError;

    // Genel hata durumları
    switch (error.response?.status) {
      case 400:
        return "Geçersiz istek";
      case 401:
        return "Oturum süreniz doldu. Lütfen tekrar giriş yapın.";
      case 403:
        return "Bu işlem için yetkiniz bulunmuyor";
      case 404:
        return "İstenen kaynak bulunamadı";
      case 500:
        return "Sunucu hatası oluştu";
      default:
        return "Bir hata oluştu";
    }
  }
  
  return "Beklenmeyen bir hata oluştu";
};

// API yanıt tiplerini tanımla
export interface ApiResponse<T = any> {
  data: T;
  message?: string;
  success: boolean;
}
