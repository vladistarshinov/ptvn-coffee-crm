import { IProduct } from "@/types/Product";

export interface IInvoice {
  customerId: number;
  orderItems: IOrderItem[];
  createdOn: Date;
  updatedOn: Date;
}

export interface IOrderItem {
  product: IProduct;
  quantity: number;
}