import api from "./axios";
import { Review, CreateReview, ReviewStatus, UpdateReviewStatus } from "../../types/models";



class ReviewService {
  private endpoint = "Review";

  async getAll() {
    const response = await api.get<{data: Review[]}>(this.endpoint);
    return response.data.data;
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

  async updateStatus(updateReview : UpdateReviewStatus) {
    await api.put(`${this.endpoint}/${updateReview.id}/status`, {
      ...updateReview,
      status: updateReview.status !== undefined ? Number(updateReview.status) : undefined,
    });
  }

  async delete(id: string): Promise<void> {
    await api.delete(`${this.endpoint}/${id}`);
  }
}

const reviewService = new ReviewService();
export default reviewService;
