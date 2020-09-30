export interface IProduct {
    id: number;
    name: string;
    description: string;
    price: number;
    isTaxable: boolean;
    isArchived: boolean;
    createdOn: Date;
    updatedOn: Date;
}

export interface IProductInventory {
    id: number;
    product: IProduct;
    quantityOnHand: number;
    idealQuantity: number;
}