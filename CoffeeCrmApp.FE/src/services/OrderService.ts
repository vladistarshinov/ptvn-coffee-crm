import axios from "axios";

export class OrderService {
    //API_URL = process.env.VUE_APP_API_URL;

    public async getOrders(): Promise<any> {
        //const result: any = await axios.get(`${this.API_URL}/order/complete/${id}`)
        const result: any = await axios.get(`https://localhost:5001/api/orders/`);
        return result.data;
    }

    public async markCompleteOrder(id: number): Promise<any> {
        //const result: any = await axios.get(`${this.API_URL}/order/complete/${id}`)
        const result: any = await axios.patch(`https://localhost:5001/api/order/complete/${id}`);
        return result.data;
    }
}