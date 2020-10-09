export interface IInventoryTimeline {
    inventorySnapshots: ISnapshot[];
    timeline: Date[];
}

export interface ISnapshot {
    productId: number;
    quantityOnHand: number[];
}