import api from "./axios";

export class CrudService<T> {
  constructor(private endpoint: string) {
    console.log("CrudService initialized with endpoint:", endpoint);
  }

  async getAll(): Promise<T[]> {
    console.log("Fetching all from endpoint:", this.endpoint);
    const response = await api.get<T[]>(this.endpoint);
    return response.data;
  }

  async getById(id: string): Promise<T> {
    console.log("Fetching by id from endpoint:", `${this.endpoint}/${id}`);
    const response = await api.get<T>(`${this.endpoint}/${id}`);
    return response.data;
  }

  async create(data: Partial<T>): Promise<T> {
    console.log("Creating at endpoint:", this.endpoint, "with data:", data);
    const response = await api.post<T>(this.endpoint, data);
    return response.data;
  }

  async update(id: string, data: Partial<T>): Promise<T> {
    console.log(
      "Updating at endpoint:",
      `${this.endpoint}/${id}`,
      "with data:",
      data
    );
    const response = await api.put<T>(`${this.endpoint}/${id}`, data);
    return response.data;
  }

  async delete(id: string): Promise<void> {
    console.log("Deleting at endpoint:", `${this.endpoint}/${id}`);
    await api.delete(`${this.endpoint}/${id}`);
  }
}
