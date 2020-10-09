<template>
  <table id="sales=table" class="table" v-if="salesHistory.length">
    <thead>
      <tr>
        <th>№<br />заказа</th>
        <th>Клиент</th>
        <th>Сумма</th>
        <th>Заказ</th>
        <th>Оплата</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="s in salesHistory" :key="s.id">
        <td>{{ s.id }}</td>
        <td>
          {{ s.customer.firstName.charAt(0) + ". " + s.customer.lastName }}
        </td>
        <td>{{ getTotal(s) | priceFilter }}</td>
        <td>
          <span v-for="o in s.orderItems" :key="o.id">
            {{ o.product.name + "(x" + o.quantity + "),"  }}<br />
          </span>
        </td>
        <td 
          v-if="!s.isPaid" 
          class="lni lni-checkmark-circle justify-center cursor-pointer" 
          :class="{ yellow: !s.isPaid }"
          @click.prevent="markComplete(s.id)"
        ></td>
        <td 
          v-else 
          class="lni lni-checkmark-circle justify-center" 
          :class="{ green: s.isPaid }"
        ></td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { ISalesHistory } from "@/types/SalesHistory";
import { IOrderItem } from "@/types/Invoice";
@Component({
  name: "OrderList",
})
export default class OrderList extends Vue {
  @Prop({
    required: true,
    type: Array as () => ISalesHistory[],
  })
  salesHistory!: ISalesHistory[];
  orderItems: IOrderItem[] = [];

  getTotal(salesHistory: ISalesHistory) {
    return salesHistory.orderItems.reduce(
      (a: any, b: any) => a + b["product"]["price"] * b["quantity"],
      0
    );
  }

  getStatus(isPaid: boolean) {
    return isPaid ? "Оплачено" : "Не оплачено";
  }

  markComplete(orderId: number) {
    this.$emit("mark:complete", orderId);
    console.log(orderId);
  }
}
</script>

<style lang="scss"></style>
