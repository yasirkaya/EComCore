import { CrudService } from "./crud.service";
import { User, Product, Category } from "../../types/models";
import authService from "./auth.service";

export const userService = new CrudService<User>("Users");
export const productService = new CrudService<Product>("Products");
export const categoryService = new CrudService<Category>("Categories");
export { authService };

export default {
  auth: authService,
  users: userService,
  products: productService,
  categories: categoryService,
};
