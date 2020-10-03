<template>
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
      <tr v-for="item in inventory" :key="item.id">
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
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { IProductInventory } from "@/types/Product";
@Component({
  name: "InventoryList"
})
export default class InventoryList extends Vue {
  @Prop({
    required: true,
    type: Array as () => IProductInventory[]
  })
  inventory!: IProductInventory[];

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
