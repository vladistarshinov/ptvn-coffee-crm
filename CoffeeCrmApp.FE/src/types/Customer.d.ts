export interface ICustomer {
    id: number;
    firstName: string;
    lastName: string;
    phone: string;
    primaryAddress: ICustomerAddress;
    createdOn: Date;
    updatedOn?: Date;
}

export interface ICustomerAddress {
    id: number;
    country: string;
    city: string;
    email: string;
    address1: string;
    address2: string;
    createdOn: Date;
    updatedOn?: Date;
}