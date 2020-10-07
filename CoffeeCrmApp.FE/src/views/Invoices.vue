<template>
  <div class="main">
    <div class="article">
      <h2>Создание заказа</h2>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
    </div>
    <div class="invoice-step" v-if="invoiceStep === 1">
      <h2>Этап 1: Выберите клиента</h2>
      <div class="invoice-step__detail" v-if="customers.length">
        <label for="customer">Клиент</label>
        <select id="customer" v-model="selectedCustomerId">
          <option disabled value="">Выберите клиента из списка...</option>
          <option v-for="c in customers" :key="c.id" :value="c.id">
            {{ c.firstName + " " + c.lastName }}
          </option>
        </select>
      </div>
    </div>
    <div class="invoice-step" v-if="invoiceStep === 2">
      <h2>Этап 2: Выберите товар</h2>
      <div class="invoice-step__detail" v-if="inventory.length">
        <label for="product">Товар</label>
        <select id="product" v-model="newOrderItem.product">
          <option disabled value="">Выберите товар из списка...</option>
          <option v-for="i in inventory" :key="i.id" :value="i.product">
            {{ i.product.name }}
          </option>
        </select>
        <label for="quantity">Количество</label>
        <input
          id="quantity"
          v-model="newOrderItem.quantity"
          type="number"
          min="0"
        />
      </div>
      <div class="inventory-actions justify-center">
        <button
          class="btn"
          @click.prevent="addOrderItem"
          type="button"
          :disabled="!newOrderItem.product || !newOrderItem.quantity"
        >Добавить заказ</button>
        <button
          class="btn"
          @click.prevent="finalOrder"
          type="button"
          :disabled="!orderItems.length"
        >Завершить</button>
      </div>
      <InvoiceList :orderItems="orderItems" />
    </div>
    <div class="invoice-step" v-if="invoiceStep === 3">
      <h2>Этап 3: Подтверждение заказа</h2>
      <div class="invoice-snapshot">
        <OrderInvoiceSnapshot       
          :customers="customers" 
          :selectedCustomerId="selectedCustomerId"
          :orderItems="orderItems"
        />
        <InvoiceList :orderItems="orderItems" />
      </div>
      <div class="justify-center">
        <button 
          class="btn"
          @click.prevent="submitInvoice"
          type="button"
        >Подтвердить</button>
      </div>
    </div>
    <div class="inventory-actions justify-center">
      <button
        class="btn lni lni-arrow-left"
        @click.prevent="previousStep"
        type="button"
        :disabled="!canPushPrevBtn"
      ></button>
      <button
        class="btn lni lni-reload"
        @click.prevent="resetOrder"
        type="button"
      ></button>
      <button
        class="btn lni lni-arrow-right"
        @click.prevent="nextStep"
        type="button"
        :disabled="!canPushNextBtn"
      ></button>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IInvoice, IOrderItem } from "@/types/Invoice";
import { ICustomer } from "@/types/Customer";
import { IProductInventory } from "@/types/Product";
import { InventoryService } from "@/services/InventoryService";
import { InvoiceService } from "@/services/InvoiceService";
import { CustomerService } from "@/services/CustomerService";
import InvoiceList from "@/components/InvoiceList.vue"
import OrderInvoiceSnapshot from "@/components/OrderInvoiceSnapshot.vue";
@Component({
  name: "Invoices",
  components: { InvoiceList, OrderInvoiceSnapshot }
})
export default class Invoices extends Vue {
  inventoryService = new InventoryService();
  customerService = new CustomerService();
  invoiceService = new InvoiceService();
  invoiceStep: number = 1;
  selectedCustomerId: number = 0;
  orderItems: IOrderItem[] = [];
  invoice: IInvoice = {
    customerId: 0,
    orderItems: [],
    createdOn: new Date(),
    updatedOn: new Date()
  };
  customers: ICustomer[] = [];
  inventory: IProductInventory[] = [];
  newOrderItem: IOrderItem = {
    product: {
      id: 0,
      name: "",
      description: "",
      price: 0,
      isTaxable: false,
      isArchived: false,
      createdOn: new Date(),
      updatedOn: new Date()
    },
    quantity: 0
  };

  get canPushPrevBtn() {
    return this.invoiceStep !== 1;
  }

  get canPushNextBtn() {
    if (this.invoiceStep === 1) {
      if (!this.selectedCustomerId) {
        return false;
      }
      return true;
    }
    if (this.invoiceStep === 2) {
      if (!this.orderItems.length) {
        return false;
      }
      return true;
    }
    if (this.invoiceStep === 3) {
      return false;
    }
    return false;
  }

    previousStep(): void {
    if (this.invoiceStep == 1) {
      return;
    }
    this.invoiceStep -= 1;
  }

  nextStep(): void {
    if (this.invoiceStep == 3) {
      return;
    }
    this.invoiceStep += 1;
  }

  resetOrder(): void {
    this.invoice = {
      customerId: 0,
      orderItems: [],
      createdOn: new Date(),
      updatedOn: new Date()
    };
    this.orderItems.length = 0;
    this.invoiceStep = 1;
  }

  addOrderItem() {
    const addOrderItem: IOrderItem = {
      product: this.newOrderItem.product,
      quantity: Number(this.newOrderItem.quantity)
    };
    const existingItems = this.orderItems.map(item => item.product.id);
    if (existingItems.includes(addOrderItem.product.id)) {
      const orderItem = this.orderItems.find(
        item => item.product.id === addOrderItem.product.id
      );
      let currentQuantity = Number(orderItem.quantity);
      const updatedQuantity = (currentQuantity += addOrderItem.quantity);
      orderItem.quantity = updatedQuantity;
    } else {
      this.orderItems.push(this.newOrderItem);
      console.log(this.orderItems);
    }
    this.newOrderItem = {
      product: {
        id: 0,
        name: "",
        description: "",
        price: 0,
        isTaxable: false,
        isArchived: false,
        createdOn: new Date(),
        updatedOn: new Date()
      },
      quantity: 0
    };
  }

  finalOrder() {
    this.invoiceStep = 3;
  }

  async submitInvoice(): Promise<void> {
    this.invoice = {
      customerId: this.selectedCustomerId,
      orderItems: this.orderItems,
      createdOn: new Date(), 
      updatedOn: new Date()
    }
    await this.invoiceService.createNewInvoice(this.invoice);
  }

  async getInvoiceData(): Promise<void> {
    this.customers = await this.customerService.getCustomers();
    this.inventory = await this.inventoryService.getInventory();
  }

  async created() {
    await this.getInvoiceData();
  }
}
</script>

<style lang="scss"></style>
