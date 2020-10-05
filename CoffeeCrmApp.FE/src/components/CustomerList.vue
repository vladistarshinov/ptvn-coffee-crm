<template>
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
      <tr v-for="item in customers" :key="item.id">
        <td class="cursor-pointer" @click.prevent="showEditCustomerInfoModal(item.id)">
          {{ item.firstName + " " + item.lastName }}
        </td>
        <td>{{ item.primaryAddress.email }}</td>
        <td>{{ item.phone }}</td>
        <td>{{ item.createdOn | dataFilter }}</td>
        <td>
          <div
            class="lni lni-close product-archive"
            @click.prevent="deleteCustomer(item.id)"
          ></div>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
@Component({
  name: "CustomerList"
})
export default class CustomerList extends Vue {
  @Prop({
    required: true,
    type: Array as () => ICustomer[]
  })
  customers!: ICustomer[];

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
