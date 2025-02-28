import api from "./axios";
import { CreateRole, Role, UpdateRole } from "../../types/models";

class RoleService {
  private endpoint = "Role";

  async getAll() {
    const response = await api.get<Role[]>(`${this.endpoint}`);
    return response.data;
  }

  async getRoleById(id: number) {
    const response = await api.get<Role>(`${this.endpoint}/${id}`);
    return response.data;
  }

  async getRoleByName(name: string) {
    const response = await api.get<Role>(`${this.endpoint}/byname/${name}`);
    return response.data;
  }

  async createRole(role: CreateRole) {
    const response = await api.post(`${this.endpoint}`, role);
    return response.data;
  }

  async updateRole(role: UpdateRole) {
    const response = await api.put(`${this.endpoint}/${role.id}`, role);
    return response.data;
  }

  async deleteRole(id: number) {
    const response = await api.delete(`${this.endpoint}/${id}`);
    return response.data;
  }
}

const roleService = new RoleService();
export default roleService;
