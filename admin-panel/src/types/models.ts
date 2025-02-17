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

export interface Review {
  id: string;
  productId: string;
  productName: string;
  userId: string;
  userName: string;
  rating: number;
  comment: string;
  status: ReviewStatus;
  moderationReason?: string;
  createdAt: string;
  updatedAt: string;
}

export const ReviewStatus = {
  Pending: 0,
  Approved: 1,
  Rejected: 2,
} as const;

export type ReviewStatus = typeof ReviewStatus[keyof typeof ReviewStatus];

export interface CreateReview {
  productId: string;
  userId: string;
  comment: string;
  rating: number;
}

export interface UpdateReview {
  rating?: number;
  comment?: string;
  status?: string;
  moderationReason?: string;
}

export interface UpdateReviewStatus {
  status?: string;
  moderationReason?: string;
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
