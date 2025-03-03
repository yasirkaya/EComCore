import { CrudService } from "./crud.service";
import { UserRole } from "../../types/models";
import api from "./axios";

class UserRoleService extends CrudService<UserRole> {
  constructor() {
    super("UserRoles");
  }
  private userRoleEndpoint = "UserRoles";

  async getByUserId(userId: string): Promise<UserRole[]> {
    const response = await api.get<UserRole[]>(
      `${this.userRoleEndpoint}/user/${userId}`
    );
    return response.data;
  }

  async getByRoleId(roleId: string): Promise<UserRole[]> {
    const response = await api.get<UserRole[]>(
      `${this.userRoleEndpoint}/role/${roleId}`
    );
    return response.data;
  }

  async deleteByUserIdAndRoleId(userId: string, roleId: string): Promise<void> {
    await api.delete(`${this.userRoleEndpoint}/user/${userId}/role/${roleId}`);
  }
}

const userRoleService = new UserRoleService();
export default userRoleService;
