<template>
  <div class="invoice-order" v-if="orderItems.length">
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
        <tr>
          <th colspan="4"></th>
          <th>Итого</th>
        </tr>
      </tbody>
      <tfoot>
        <tr>
          <td colspan="4" class="due">Баланс оплачивается при получении</td>
          <td class="price-final">{{ runningTotal | priceFilter }}</td>
        </tr>
      </tfoot>
    </table>
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
  margin-top: 0.6rem;
  padding: 0.5rem;

  &__title {
    display: flex;
    justify-content: center;
  }
}

.price-final {
  font-weight: bold;
  font-size: 1rem;
  color: #326500;
}
.due {
  font-weight: bold;
}
</style>
