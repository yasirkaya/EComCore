export interface Product {
  id: string;
  name: string;
  description: string;
  price: number;
  imageUrl?: string;
  categoryId?: string;
}

export interface Category {
  id: string;
  name: string;
  description?: string;
}

export interface Review {
  id: string;
  productId: string;
  userId: string;
  rating: number;
  comment: string;
  createdAt: string;
}

export interface ProductFilter {
  pageNumber?: number;
  pageSize?: number;
  sortBy?: string;
  sortOrder?: "asc" | "desc";
  categoryId?: string;
  minPrice?: number;
  maxPrice?: number;
  search?: string;
  minRating?: number;
  createdFrom?: string;
  createdTo?: string;
  includeDeleted?: boolean;
}
