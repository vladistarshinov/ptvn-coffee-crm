<template>
  <div class="customers">
    <div class="article">
      <h2>Покупатели</h2>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
    </div>
    <div class="inventory-actions">
      <button
        class="btn"
        @click.prevent="isShowNewCustomerModal = true"
        type="button"
      >
        Добавить
      </button>
    </div>

    <NewCustomerModal
      v-if="isShowNewCustomerModal"
      :customers="customers"
      @add:newCustomer="addNewCustomer"
      @close="isShowNewCustomerModal = false"
    />

    <EditCustomerModal
      v-if="isShowEditCustomerModal"
      :customer="customer"
      @edit:customer = "editCustomer"
      @close="isShowEditCustomerModal = false"
    />

    <CustomerList
      :customers="customers"
      @show:customer="getCustomer"
      @delete="deleteCustomer"
    />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
import CustomerList from "@/components/CustomerList.vue";
import NewCustomerModal from "@/components/NewCustomerModal.vue";
import EditCustomerModal from "@/components/EditCustomerModal.vue";
import { CustomerService } from "@/services/CustomerService";
@Component({
  name: "Customers",
  components: { CustomerList, NewCustomerModal, EditCustomerModal }
})
export default class Customers extends Vue {
  customerService = new CustomerService();
  isShowNewCustomerModal: boolean = false;
  isShowEditCustomerModal: boolean = false;

  customers: ICustomer[] = [];
  customer: ICustomer = {
    id: 0,
    firstName: "",
    lastName: "",
    phone: "",
    primaryAddress: {
      id: 0,
      country: "",
      city: "",
      email: "",
      address1: "",
      address2: "",
      createdOn: new Date(),
      updatedOn: new Date()
    },
    createdOn: new Date(),
    updatedOn: new Date()
  };

  async getCustomersData() {
    this.customers = await this.customerService.getCustomers();
    console.log(this.customers);
  }

  getCustomer(customerId: number) {
    for (let i = 0; i < this.customers.length; i++) {
      if (this.customers[i].id === customerId) {
        this.customer = this.customers[i];
      }
    }
    this.isShowEditCustomerModal = true;
  }

  async addNewCustomer(newCustomer: ICustomer) {
    await this.customerService.addCustomer(newCustomer);
    this.isShowNewCustomerModal = false;
    await this.getCustomersData();
  }

  async editCustomer(customerId: number, customer: ICustomer) {
    await this.customerService.editCustomer(customerId, customer);
    this.isShowEditCustomerModal = false;
    await this.getCustomersData();
  }

  async deleteCustomer(customerId: number) {
    await this.customerService.deleteCustomer(customerId);
    await this.getCustomersData();
  }

  async created() {
    await this.getCustomersData();
  }
}
</script>
