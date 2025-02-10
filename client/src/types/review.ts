export interface Review {
  id: number;
  productId: number;
  productName: string;
  userId: number;
  userName: string;
  rating: number;
  comment: string;
  status: string;
  moderationReason: string;
  createdAt: Date;
  updatedAt: Date;
}
export interface CreateReview {
  productId: number;
  userId: number;
  comment: string;
  rating: number;
}

export interface UpdateReview {
  id: number;
  rating?: number;
  comment?: string;
  status?: ReviewStatus;
  moderationReason?: string;
}

export enum ReviewStatus {
  Pending = "Pending",
  Approved = "Approved",
  Rejected = "Rejected",
}
