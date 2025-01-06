import api from "./axios";

export class CrudService<T> {
  constructor(private endpoint: string) {}

  async getAll(): Promise<T[]> {
    const response = await api.get<T[]>(this.endpoint);
    return response.data;
  }

  async getById(id: string): Promise<T> {
    const response = await api.get<T>(`${this.endpoint}/${id}`);
    return response.data;
  }

  async create(data: Partial<T>): Promise<T> {
    const response = await api.post<T>(this.endpoint, data);
    return response.data;
  }

  async update(id: string, data: Partial<T>): Promise<T> {
    const response = await api.put<T>(`${this.endpoint}/${id}`, data);
    return response.data;
  }

  async delete(id: string): Promise<void> {
    await api.delete(`${this.endpoint}/${id}`);
  }
}
