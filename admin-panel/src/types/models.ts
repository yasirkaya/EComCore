export interface User {
  id: string;
  username: string;
  email: string;
  isDeleted: boolean;
  isEmailVerified: boolean;
}

export interface Product {
  id: string;
  name: string;
  description: string;
  sku: string;
  price: number;
  stockQuantity: number;
  categoryIds: string[];
  isDeleted: boolean;
  createdAt: Date;
  updatedAt: Date;
}

export interface Category {
  id: string;
  name: string;
  description: string;
  parentId?: string;
  createdAt: Date;
  updatedAt: Date;
}

export interface LoginCredentials {
  loginDto: LoginDto;
}
export interface LoginDto {
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  refreshToken: string;
  user: User;
}
