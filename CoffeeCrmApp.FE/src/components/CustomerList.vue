<template>
  <div>
    <table class="table">
      <thead>
        <tr>
          <th>Клиент</th>
          <th>Email</th>
          <th>Телефон</th>
          <th>Дата</th>
          <th>Удалить</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in paginatedCustomers" :key="item.id">
          <td
            class="cursor-pointer"
            @mouseenter="activeEdit = true"
            @mouseleave="activeEdit = false"
            @click.prevent="showEditCustomerInfoModal(item.id)"
          >
            <span v-show="activeEdit" class="lni lni-pencil"></span
            >{{ item.firstName + " " + item.lastName }}
          </td>
          <td>{{ item.primaryAddress.email }}</td>
          <td>{{ item.phone }}</td>
          <td>{{ item.createdOn | dateFilter }}</td>
          <td>
            <div
              class="lni lni-close product-archive"
              @click.prevent="deleteCustomer(item.id)"
            ></div>
          </td>
        </tr>
      </tbody>
    </table>
    <Pagination v-show="pages > 1 || pageNumber > 1" :pageSelect="pageSelect" :pages="pages" />
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
import Pagination from "@/components/layouts/Pagination.vue";
@Component({
  name: "CustomerList",
  components: { Pagination }
})
export default class CustomerList extends Vue {
  @Prop({
    required: true,
    type: Array as () => ICustomer[]
  })
  customers!: ICustomer[];
  activeEdit: boolean = false;
  customersPerPage: number = 5;
  pageNumber: number = 1;

  get pages() {
    return Math.ceil(this.customers.length / this.customersPerPage);
  }

  get paginatedCustomers() {
    const from = (this.pageNumber - 1) * this.customersPerPage;
    const to = from + this.customersPerPage;
    return this.customers.slice(from, to);
  }

  pageSelect(page: any) {
    this.pageNumber = page;
  }

  showEditCustomerInfoModal(customerId: number) {
    this.$emit("show:customer", customerId);
    console.log(customerId);
  }

  deleteCustomer(customerId: number) {
    this.$emit("delete", customerId);
  }
}
</script>

<style lang="scss"></style>
