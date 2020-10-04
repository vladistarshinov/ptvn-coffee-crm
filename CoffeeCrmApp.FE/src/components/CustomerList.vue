<template>
  <table class="table">
    <thead>
      <tr>
        <th>Клиент</th>
        <th>Город, адрес</th>
        <th>Телефон</th>
        <th>Дата</th>
        <th>Удалить</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in customers" :key="item.id">
        <td class="cursor-pointer" @click.prevent="getCustomer(item.id)">
          {{ item.firstName + " " + item.lastName }}
        </td>
        <td>
          {{
            item.primaryAddress.city +
              ", " +
              item.primaryAddress.address1 +
              "-" +
              item.primaryAddress.address2
          }}
        </td>
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

  getCustomer(customerId: number) {
    this.$emit("get:customer", customerId);
    console.log(customerId);
  }

  deleteCustomer(customerId: number) {
    this.$emit("delete", customerId);
  }
}
</script>

<style lang="scss"></style>
