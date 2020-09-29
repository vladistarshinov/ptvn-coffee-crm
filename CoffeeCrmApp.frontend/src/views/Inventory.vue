<template>
  <div class="inventory">
    <div class="article">
      <h2>Инвентарь</h2>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
    </div>

    <div class="inventory-actions">
      <button class="btn" @click.prevent="isShowNewProductModal = true" type="button">
        Добавить
      </button>
      <button
        class="btn"
        @click.prevent="isShowShipmentModal = true"
        type="button"
      >
        Получить
      </button>
    </div>

    <NewProductModal 
      v-if="isShowNewProductModal"
      :inventory = inventory
      @add:newProduct="addNewProduct"
      @close="isShowNewProductModal = false" 
    />

    <ShipmentModal 
      v-if="isShowShipmentModal" 
      :inventory = inventory 
      @save:shipment="saveShipment"
      @close="isShowShipmentModal = false" 
    />

    <InventoryList :inventory="inventory" />

  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IProduct, IProductInventory } from "@/types/Product";
import NewProductModal from "@/components/NewProductModal.vue";
import ShipmentModal from "@/components/ShipmentModal.vue";
import InventoryList from "@/components/InventoryList.vue";

@Component({
  name: "Inventory",
  components: { ShipmentModal, NewProductModal, InventoryList }
})
export default class Inventory extends Vue {
  isShowNewProductModal: boolean = false;
  isShowShipmentModal: boolean = false;

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

  saveShipment(selectedProduct : IProduct, quantityReceived : number) {
    console.log(selectedProduct);
    console.log("quantityReceived: ", quantityReceived)
    
  }

  addNewProduct(newProduct : IProduct) {
    console.log(newProduct);
  }

}
</script>
