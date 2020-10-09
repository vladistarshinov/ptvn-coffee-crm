<template>
  <div>
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
        <tr v-for="s in paginatedSales" :key="s.id">
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
    <Pagination v-show="pages > 1 || pageNumber > 1" :pageSelect="pageSelect" :pages="pages" />
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { ISalesHistory } from "@/types/SalesHistory";
import { IOrderItem } from "@/types/Invoice";
import Pagination from "@/components/layouts/Pagination.vue";
@Component({
  name: "OrderList",
  components: { Pagination }
})
export default class OrderList extends Vue {
  @Prop({
    required: true,
    type: Array as () => ISalesHistory[],
  })
  salesHistory!: ISalesHistory[];
  orderItems: IOrderItem[] = [];
  salesPerPage: number = 4;
  pageNumber: number = 1;

  getTotal(salesHistory: ISalesHistory) {
    return salesHistory.orderItems.reduce(
      (a: any, b: any) => a + b["product"]["price"] * b["quantity"],
      0
    );
  }

  get pages() {
    return Math.ceil(this.salesHistory.length / this.salesPerPage);
  }

  get paginatedSales() {
    const from = (this.pageNumber - 1) * this.salesPerPage;
    const to = from + this.salesPerPage;
    return this.salesHistory.slice(from, to);
  }

  pageSelect(page: any) {
    this.pageNumber = page;
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
