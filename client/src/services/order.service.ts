import { api } from './api';
import { ApiResponse } from './api';

export interface Address {
  id?: number;
  title: string;
  fullName: string;
  addressLine: string;
  city: string;
  district: string;
  zipCode: string;
  phone: string;
}

export interface OrderItem {
  productId: number;
  quantity: number;
}

export interface CreateOrderRequest {
  address: Address;
  items: OrderItem[];
}

export interface Order {
  id: number;
  orderNumber: string;
  orderDate: string;
  status: string;
  address: Address;
  items: OrderItem[];
  totalAmount: number;
}

class OrderService {
  private readonly baseUrl = '/Order';

  async createOrder(orderData: CreateOrderRequest): Promise<ApiResponse<Order>> {
    try {
      const response = await api.post<ApiResponse<Order>>(this.baseUrl, orderData);
      return response.data;
    } catch (error) {
      throw error;
    }
  }

  async getOrderById(orderId: number): Promise<ApiResponse<Order>> {
    try {
      const response = await api.get<ApiResponse<Order>>(`${this.baseUrl}/${orderId}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  }

  async updateOrderStatus(orderId: number, status: string): Promise<ApiResponse<Order>> {
    try {
      const response = await api.put<ApiResponse<Order>>(`${this.baseUrl}/status`, {
        orderId,
        status
      });
      return response.data;
    } catch (error) {
      throw error;
    }
  }

  async cancelOrder(orderId: number): Promise<ApiResponse<Order>> {
    try {
      const response = await api.delete<ApiResponse<Order>>(`${this.baseUrl}/${orderId}`);
      return response.data;
    } catch (error) {
      throw error;
    }
  }
}

export const orderService = new OrderService();
