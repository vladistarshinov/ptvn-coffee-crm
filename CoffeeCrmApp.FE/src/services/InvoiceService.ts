import axios from "axios";
import { IInvoice } from "@/types/Invoice";

export class InvoiceService {
  public async createNewInvoice(invoice: IInvoice): Promise<boolean> {
    const now = new Date();
    invoice.createdOn = now;
    invoice.updatedOn = now;
    //const result: any = await axios.post(`${this.API_URL}/invoice/`);
    const result: any = await axios.post(
      `https://localhost:5001/api/invoice/`,
      invoice
    );
    return result.data;
  }
}
