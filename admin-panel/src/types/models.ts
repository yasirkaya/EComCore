export interface User {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  role: string;
}

export interface Product {
  id: string;
  name: string;
  description: string;
  price: number;
  stock: number;
  categoryId: string;
  imageUrl?: string;
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
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  user: User;
}
