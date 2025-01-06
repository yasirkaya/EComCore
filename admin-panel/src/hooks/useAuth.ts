import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { authService } from "../services/api";
import { User, LoginCredentials } from "../types/models";

export const useAuth = () => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    const currentUser = authService.getCurrentUser();
    setUser(currentUser);
    setLoading(false);
  }, []);

  const login = async (credentials: LoginCredentials) => {
    try {
      const response = await authService.login(credentials);
      setUser(response.user);
      navigate("/dashboard");
      return { success: true };
    } catch (error) {
      return {
        success: false,
        error: "Giriş başarısız. Lütfen bilgilerinizi kontrol edin.",
      };
    }
  };

  const logout = () => {
    authService.logout();
    setUser(null);
    navigate("/login");
  };

  return {
    user,
    loading,
    login,
    logout,
    isAuthenticated: authService.isAuthenticated(),
  };
};
