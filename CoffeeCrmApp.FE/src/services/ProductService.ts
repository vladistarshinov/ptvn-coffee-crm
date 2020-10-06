import { IProduct } from "@/types/Product";
import axios from "axios";

export class ProductService {
  //API_URL = process.env.VUE_APP_API_URL;

  public async archive(productId: number) {
    //const result: any = await axios.get(`${this.API_URL}/product/${productId}`);
    const result: any = await axios.patch(
      `https://localhost:5001/api/product/${productId}`
    );
    return result.data;
  }

  public async save(newProduct: IProduct) {
    //const result: any = await axios.get(`${this.API_URL}/product/`, newProduct);
    const result: any = await axios.post(
      `https://localhost:5001/api/product/`,
      newProduct
    );
    return result.data;
  }
}
