<template>
  <div class="main">
    <div class="article">
      <h2>Заказы</h2>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
    </div>
    <OrderList :salesHistory="salesHistory" @mark:complete="markComplete" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ISalesHistory } from "@/types/SalesHistory";
import { OrderService } from "@/services/OrderService";
import OrderList from "@/components/OrderList.vue";
@Component({
  name: "Orders",
  components: { OrderList }
})
export default class Orders extends Vue {
    orderService = new OrderService();
    salesHistory: ISalesHistory[] = [];

    async getSalesData () {
      this.salesHistory = await this.orderService.getOrders();
    }

    async markComplete(orderId: number) {
      await this.orderService.markCompleteOrder(orderId);
      await  this.getSalesData();
    }

    async created () {
      await this.getSalesData();
    }
}
</script>
