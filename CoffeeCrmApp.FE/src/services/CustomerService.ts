import { ICustomer } from "@/types/Customer";
import { IResponseService } from "@/types/ResponseService";
import axios from "axios";

export class CustomerService {
  //API_URL = process.env.VUE_APP_API_URL;

  public async getCustomers(): Promise<ICustomer[]> {
    //const result: any = await axios.get(`${this.API_URL}/customers/`);
    const result = await axios.get(`https://localhost:5001/api/customers/`);
    return result.data;
  }

  public async getCustomer(customerId: number): Promise<ICustomer> {
    //const result: any = await axios.get(`${this.API_URL}/customers/`);
    const result = await axios.get(
      `https://localhost:5001/api/customers/${customerId}`
    );
    return result.data;
  }

  public async addCustomer(
    newCustomer: ICustomer
  ): Promise<IResponseService<ICustomer>> {
    //const result: any = await axios.get(`${this.API_URL}/customer/`);
    const result = await axios.post(
      `https://localhost:5001/api/customer/`,
      newCustomer
    );
    return result.data;
  }

  public async editCustomer(
    customerId: number,
    customer: ICustomer
  ): Promise<IResponseService<ICustomer>> {
    //const result: any = await axios.get(`${this.API_URL}/customer/`);
    const result = await axios.put(
      `https://localhost:5001/api/customer/${customerId}`,
      customer
    );
    return result.data;
  }

  public async deleteCustomer(customerId: number): Promise<boolean> {
    //const result: any = await axios.get(`${this.API_URL}/customer/${customerId}`);
    const result = await axios.delete(
      `https://localhost:5001/api/customer/${customerId}`
    );
    return result.data;
  }
}
