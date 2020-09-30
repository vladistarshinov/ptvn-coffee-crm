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
      <button
        class="btn"
        @click.prevent="isShowNewProductModal = true"
        type="button"
      >
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
      :inventory="inventory"
      @add:newProduct="addNewProduct"
      @close="isShowNewProductModal = false"
    />

    <ShipmentModal
      v-if="isShowShipmentModal"
      :inventory="inventory"
      @save:shipment="saveNewShipment"
      @close="isShowShipmentModal = false"
    />

    <InventoryList :inventory="inventory" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IProduct, IProductInventory } from "@/types/Product";
import { IShipment } from "@/types/Shipment";
import NewProductModal from "@/components/NewProductModal.vue";
import ShipmentModal from "@/components/ShipmentModal.vue";
import InventoryList from "@/components/InventoryList.vue";
import { InventoryService } from '@/services/InventoryService';

@Component({
  name: "Inventory",
  components: { ShipmentModal, NewProductModal, InventoryList }
})
export default class Inventory extends Vue {
  inventoryService = new InventoryService();
  isShowNewProductModal: boolean = false;
  isShowShipmentModal: boolean = false;

  inventory: IProductInventory[] = [];

  saveNewShipment(shipment: IShipment) {
    console.log(shipment);
  }

  addNewProduct(newProduct: IProduct) {
    console.log(newProduct);
  }

  async initializeData() {
    this.inventory = await this.inventoryService.getInventory();
    console.log(this.inventory)
    
  }

  async created() {
    await this.initializeData();
  }
}
</script>
