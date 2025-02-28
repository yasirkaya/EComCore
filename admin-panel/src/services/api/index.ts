import { CrudService } from "./crud.service";
import { User, Product, Category, Permission } from "../../types/models";
import authService from "./auth.service";
import reviewService from "./review.service";
import roleService from "./role.service";

export const userService = new CrudService<User>("Users");
export const productService = new CrudService<Product>("Products");
export const categoryService = new CrudService<Category>("Categories");
export const permissionService = new CrudService<Permission>("Permissions");
export { authService, reviewService, roleService };

const apiServices = {
  auth: authService,
  users: userService,
  products: productService,
  categories: categoryService,
  reviews: reviewService,
  roles: roleService,
  permissions: permissionService,
};

export default apiServices;
