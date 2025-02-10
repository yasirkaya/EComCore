import { CreateReview, Review, UpdateReview } from "types/review";
import { api } from "./api";

class ReviewService {
  async getReviewsByProductId(productId: number) {
    const response = await api.get<{ data: Review[] }>(
      `/review/product/${productId}`
    );
    return response.data.data;
  }

  async getReviewsByUserId(userId: number) {
    const response = await api.get<{ data: Review[] }>(
      `/review/user/${userId}`
    );
    return response.data.data;
  }

  async createReview(review: CreateReview) {
    const response = await api.post<{ data: Review }>("/review", review);
    return response.data.data;
  }

  async updateReview(id: number, review: UpdateReview) {
    const response = await api.put<{ data: Review }>(`/review/${id}`, review);
    return response.data.data;
  }

  async deleteReview(id: number) {
    const response = await api.delete<{ data: Review }>(`/review/${id}`);
    return response.data.data;
  }
}

export const reviewService = new ReviewService();
