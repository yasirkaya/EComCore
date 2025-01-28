export interface Address {
  id: string;
  name: string;
  addressLine1: string;
  addressLine2: string;
  city: string;
  postalCode: string;
  isDeleted: string;
}

export interface CreateAddress {
  name: string;
  addressLine1: string;
  addressLine2: string;
  city: string;
  postalCode: string;
  userId: number;
}
export interface UpdateAddress {
  name: string;
  addressLine1: string;
  addressLine2: string;
  city: string;
  postalCode: string;
}
