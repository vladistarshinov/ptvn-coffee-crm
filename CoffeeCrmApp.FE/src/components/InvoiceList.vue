<template>
  <div class="invoice-order" v-if="orderItems.length">
    <hr />
    <h2 class="invoice-order__title">Заказ</h2>
    <table class="table">
      <thead>
        <tr>
        <th>Товар</th>
        <th>Описание</th>
        <th>Кол.</th>
        <th>Цена</th>
        <th>Общая сумма</th>
        </tr>
      </thead>
    <tbody>
        <tr
          v-for="orderItem in orderItems"
          :key="`index_${orderItem.product.id}`"
        >
          <td>{{ orderItem.product.name }}</td>
          <td>{{ orderItem.product.description }}</td>
          <td>{{ orderItem.quantity }}</td>
          <td>{{ orderItem.product.price | priceFilter }}</td>
          <td>
            {{ (orderItem.product.price * orderItem.quantity) | priceFilter }}
          </td>
        </tr>
      </tbody>
    </table>
    <div class="invoice-order__runningTotal">
      <h3>Итого:</h3>
      <h3>{{ runningTotal | priceFilter }}</h3>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { IOrderItem } from "@/types/Invoice";
@Component({
  name: "CustomerList"
})
export default class CustomerList extends Vue {
  @Prop({
    required: true,
    type: Array as () => IOrderItem[]
  })
  orderItems!: IOrderItem[];

  get runningTotal() {
    return this.orderItems.reduce(
      (a, b) => a + b["product"]["price"] * b["quantity"],
      0
    );
  }

}
</script>

<style lang="scss">
.invoice-order {
  margin-top: 1.3rem;
  padding: 0.7rem;

  &__title {
    display: flex;
    justify-content: center;
  }

  &__runningTotal {
    display: flex;
    justify-content: flex-end;

    h3 {
      margin-right: 1rem;
    }
  }
}
</style>
