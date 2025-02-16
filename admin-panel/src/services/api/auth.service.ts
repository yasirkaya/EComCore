import { LoginCredentials, AuthResponse } from "../../types/models";
import api from "./axios";

class AuthService {
  async login(credentials: LoginCredentials): Promise<AuthResponse> {
    const response = await api.post<AuthResponse>("/Auths/login", credentials);
    if (response.data.token) {
      localStorage.setItem("token", response.data.token);
    }
    return response.data;
  }

  logout(): void {
    localStorage.removeItem("token");
  }

  getCurrentUser(): AuthResponse["user"] | null {
    const token = localStorage.getItem("token");
    if (token) {
      try {
        const base64Url = token.split(".")[1];
        const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
        const jsonPayload = decodeURIComponent(
          atob(base64)
            .split("")
            .map((c) => "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2))
            .join("")
        );
        return JSON.parse(jsonPayload).user;
      } catch (error) {
        return null;
      }
    }
    return null;
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem("token");
  }
}

const authService = new AuthService();
export default authService;
