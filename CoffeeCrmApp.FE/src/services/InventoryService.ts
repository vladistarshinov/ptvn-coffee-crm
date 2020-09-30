import axios from "axios";

export class InventoryService {
    //API_URL = process.env.VUE_APP_API_URL;

    public async getInventory(): Promise<any> {
        //const result: any = await axios.get(`${this.API_URL}/inventory/`);
        const result: any = await axios.get(`https://localhost:5001/api/inventory/`);
        return result.data;
    }
}