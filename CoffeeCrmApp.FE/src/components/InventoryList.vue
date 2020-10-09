<template>
  <div>
    <table class="table">
      <thead>
        <tr>
          <th>Инвентарь</th>
          <th>Количество в наличии</th>
          <th>Цена за шт.</th>
          <th>Налог</th>
          <th>В архив</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in paginatedInventory" :key="item.id">
          <td>{{ item.product.name }}</td>
          <td 
            v-bind:class="`${ applyColor(item.quantityOnHand, item.idealQuantity) }`"
          >{{ item.quantityOnHand }}</td>
          <td>{{ item.product.price | priceFilter }}</td>
          <td>
            <span v-if="item.product.isTaxable">Да</span>
            <span v-else>Нет</span>
          </td>
          <td>
            <div 
              class="lni lni-archive product-archive"
              @click.prevent="archive(item.product.id)"
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
import { IProductInventory } from "@/types/Product";
import Pagination from "@/components/layouts/Pagination.vue";
@Component({
  name: "InventoryList",
  components: { Pagination }
})
export default class InventoryList extends Vue {
  @Prop({
    required: true,
    type: Array as () => IProductInventory[]
  })
  inventory!: IProductInventory[];
  inventoryPerPage: number = 5;
  pageNumber: number = 1;

  get pages() {
    return Math.ceil(this.inventory.length / this.inventoryPerPage);
  }

  get paginatedInventory() {
    const from = (this.pageNumber - 1) * this.inventoryPerPage;
    const to = from + this.inventoryPerPage;
    return this.inventory.slice(from, to);
  }

  pageSelect(page: any) {
    this.pageNumber = page;
  }

  archive(productId: number) {
    this.$emit("archive", productId);
  }

  applyColor(currentQuantity: number, targetQuantity: number) {
    if (currentQuantity <= 0) { 
      return "red";
    } else if (Math.abs(targetQuantity - currentQuantity) < 8) {
      return "yellow";
    } else {
      return "green";
    }
  }
}
</script>

<style lang="scss"></style>
