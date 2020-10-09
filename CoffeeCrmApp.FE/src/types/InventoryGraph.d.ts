export interface IInventoryTimeline {
    inventorySnapshots: ISnapshot[];
    timeline: Date[];
}

export interface ISnapshot {
    productName: string;
    quantityOnHand: number[];
}