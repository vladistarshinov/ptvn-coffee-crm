<template>
  <table class="table">
    <thead>
      <tr>
        <th>Инвентарь</th>
        <th>Количество в наличии</th>
        <th>Цена за шт.</th>
        <th>Налог</th>
        <th>Удалить</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in inventory" :key="item.id">
        <td>{{ item.product.name }}</td>
        <td>{{ item.quantityOnHand }}</td>
        <td>{{ item.product.price | priceFilter }}</td>
        <td>
          <span v-if="item.product.isTaxable">Да</span>
          <span v-else>Нет</span>
        </td>
        <td class="cursor-pointer">Х</td>
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
}
</script>

<style lang="scss"></style>
