import { IProductInventory } from '@/types/Product';
import { IShipment } from "@/types/Shipment";
import axios from "axios";

export class InventoryService {
    //API_URL = process.env.VUE_APP_API_URL;

    public async getInventory(): Promise<IProductInventory[]> {
        //const result: any = await axios.get(`${this.API_URL}/inventory/`);
        const result = await axios.get(`https://localhost:5001/api/inventory/`);
        return result.data;
    }

    public async updateInventoryQuantity(shipment: IShipment) {
        const result = await axios.patch(`https://localhost:5001/api/inventory/`, shipment);
        return result.data;
    }
}