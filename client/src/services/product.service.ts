import { api } from './api';
import { Product, ProductFilter, Category, Review } from '../types/product';

export const productService = {
  async getProducts(filter: ProductFilter = {}): Promise<{ items: Product[]; total: number }> {
    const { data } = await api.get('/products', { params: filter });
    return data;
  },

  async getProduct(id: string): Promise<Product> {
    const { data } = await api.get(`/products/${id}`);
    return data;
  },

  async getCategories(): Promise<Category[]> {
    const { data } = await api.get('/categories');
    return data;
  },

  async getProductReviews(productId: string): Promise<Review[]> {
    const { data } = await api.get(`/products/${productId}/reviews`);
    return data;
  },

  async addReview(productId: string, rating: number, comment: string): Promise<Review> {
    const { data } = await api.post(`/products/${productId}/reviews`, {
      rating,
      comment,
    });
    return data;
  },

  async getFavorites(): Promise<Product[]> {
    const { data } = await api.get('/favorites');
    return data;
  },

  async addToFavorites(productId: string): Promise<void> {
    await api.post(`/favorites/${productId}`);
  },

  async removeFromFavorites(productId: string): Promise<void> {
    await api.delete(`/favorites/${productId}`);
  },
};
