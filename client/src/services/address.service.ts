import { Address, CreateAddress, UpdateAddress } from "types/address";
import { api } from "./api";

export const addressService = {
  async getAddresses(): Promise<Address[]> {
    const { data } = await api.get("/address");
    return data.data;
  },

  async getAddressById(id: number): Promise<Address> {
    const { data } = await api.get(`/address/${id}`);
    return data.data;
  },

  async getAddressesByUserId(userId: number): Promise<Address[]> {
    const { data } = await api.get(`/address/user/${userId}`);
    return data.data;
  },

  async createAddress(address: CreateAddress): Promise<Address> {
    const { data } = await api.post("/address", address);
    return data.data;
  },

  async updateAddress(id: number, address: UpdateAddress): Promise<Address> {
    const { data } = await api.put(`/address/${id}`, address);
    return data;
  },

  async deleteAddress(id: number): Promise<void> {
    await api.delete(`/address/${id}`);
  },
};
