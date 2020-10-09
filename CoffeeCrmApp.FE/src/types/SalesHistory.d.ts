import { ICustomer } from '@/types/Customer';
import { IOrderItem } from '@/types/Invoice';

export interface ISalesHistory {
    id: number;
    customer: ICustomer;
    orderItems: IOrderItem;
    isPaid: boolean;
    createdOn: Date;
    updatedOn?: Date;
}