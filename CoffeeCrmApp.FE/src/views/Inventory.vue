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

    <InventoryChart v-show="isShowinventoryChart" />

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
      <button
        v-if="!isShowinventoryChart"
        class="btn"
        @click.prevent="isShowinventoryChart = true"
        type="button"
      >
        Показать график
      </button>
      <button
        v-else
        class="btn"
        @click.prevent="isShowinventoryChart = false"
        type="button"
      >
        Скрыть график
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

    <InventoryList 
      :inventory="inventory" 
      @archive="archiveProduct"
    />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IProduct, IProductInventory } from "@/types/Product";
import { IShipment } from "@/types/Shipment";
import NewProductModal from "@/components/NewProductModal.vue";
import ShipmentModal from "@/components/ShipmentModal.vue";
import InventoryList from "@/components/InventoryList.vue";
import InventoryChart from "@/components/InventoryChart.vue";
import { InventoryService } from "@/services/InventoryService";
import { ProductService } from "@/services/ProductService";

@Component({
  name: "Inventory",
  components: { ShipmentModal, NewProductModal, InventoryList, InventoryChart }
})
export default class Inventory extends Vue {
  inventoryService = new InventoryService();
  productService = new ProductService();
  isShowNewProductModal: boolean = false;
  isShowShipmentModal: boolean = false;
  isShowinventoryChart: boolean = false;

  inventory: IProductInventory[] = [];

  async saveNewShipment(shipment: IShipment) {
    await this.inventoryService.updateInventoryQuantity(shipment);
    this.isShowShipmentModal = false;
    await this.getInventoryInfo();
  }

  async addNewProduct(newProduct: IProduct) {
    await this.productService.save(newProduct);
    this.isShowNewProductModal = false;
    await this.getInventoryInfo();
  }

  async archiveProduct(productId: number) {
    await this.productService.archive(productId);
    await this.getInventoryInfo();
  }

  async getInventoryInfo() {
    this.inventory = await this.inventoryService.getInventory();
    await this.$store.dispatch("assignSnapshots");   
  }

  async created() {
    await this.getInventoryInfo();
  }
}
</script>
