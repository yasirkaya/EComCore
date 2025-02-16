import api from "./axios";
import { Review, CreateReview, UpdateReview } from "../../types/models";

class ReviewService {
  private endpoint = "Review";

  async getAll(): Promise<Review[]> {
    const response = await api.get<Review[]>(this.endpoint);
    return response.data;
  }

  async getById(id: string): Promise<Review> {
    const response = await api.get<Review>(`${this.endpoint}/${id}`);
    return response.data;
  }

  async getByProductId(productId: string): Promise<Review[]> {
    const response = await api.get<Review[]>(
      `${this.endpoint}/product/${productId}`
    );
    return response.data;
  }

  async getByUserId(userId: string): Promise<Review[]> {
    const response = await api.get<Review[]>(`${this.endpoint}/user/${userId}`);
    return response.data;
  }

  async create(review: CreateReview): Promise<Review> {
    const response = await api.post<Review>(this.endpoint, review);
    return response.data;
  }

  async update(id: string, review: UpdateReview): Promise<Review> {
    const response = await api.put<Review>(`${this.endpoint}/${id}`, review);
    return response.data;
  }

  async updateStatus(
    id: string,
    status: string,
    moderationReason?: string
  ): Promise<void> {
    await api.put(`${this.endpoint}/${id}/status`, {
      status,
      moderationReason,
    });
  }

  async delete(id: string): Promise<void> {
    await api.delete(`${this.endpoint}/${id}`);
  }
}

const reviewService = new ReviewService();
export default reviewService;
