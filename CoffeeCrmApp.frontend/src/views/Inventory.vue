<template>
  <div class="main">
    <div class="article">
      <h2>Инвентарь</h2>
      <img class="title-separator" src="../assets/title-separator.png" alt="разделитель"/>
    </div>
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
          <td>Х</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IProductInventory } from "@/types/Product";

@Component({
  name: "Inventory",
  components: {}
})
export default class Inventory extends Vue {
  inventory: IProductInventory[] = [
    {
      id: 1,
      product: {
        id: 1,
        name: "Продукт",
        description: "Хороший продукт",
        price: 100,
        isTaxable: true,
        isArchived: false,
        createdOn: new Date(),
        updatedOn: new Date()
      },
      quantityOnHand: 100,
      idealQuantity: 100
    },
    {
      id: 2,
      product: {
        id: 2,
        name: "Еще Продукт",
        description: "Хороший продукт",
        price: 150,
        isTaxable: true,
        isArchived: false,
        createdOn: new Date(),
        updatedOn: new Date()
      },
      quantityOnHand: 50,
      idealQuantity: 120
    }
  ];
}
</script>

<style lang="scss"></style>
