<template>
  <Modal>
    <template v-slot:header>
      Прием чека
    </template>
    <template v-slot:body>
      <ul class="shipmentProducts">
        <li>
          <label for="product">Товар</label>
          <select class="shipmentItems" v-model="selectedProduct" id="product">
            <option disabled value="">Выберите из списка ниже...</option>
            <option
              v-for="item in inventory"
              :key="item.product.id"
              :value="item"
            >
              {{ item.product.name }}
            </option>
          </select>
        </li>
        <li>
          <label for="quantityReceived">Получено</label>
          <input
            type="number"
            id="quantityReceived"
            v-model="quantityReceived"
          />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <button class="btn" type="button" @click.prevent="saveShipment">
        Сохранить
      </button>
      <button class="btn" type="button" @click.prevent="close">
        Закрыть
      </button>
    </template>
  </Modal>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Modal from "@/components/layouts/Modal.vue";
import { IProduct, IProductInventory } from "@/types/Product";
import { IShipment } from "@/types/Shipment";
@Component({
  name: "ShipmentModal",
  components: { Modal }
})
export default class ShipmentModal extends Vue {
  @Prop({
    required: true,
    type: Array as () => IProductInventory[]
  })
  inventory!: IProductInventory[];

  selectedProduct: IProduct = {
    id: 0,
    name: "",
    description: "",
    price: 0,
    isTaxable: false,
    isArchived: false,
    createdOn: new Date(),
    updatedOn: new Date()
  };

  quantityReceived: number = 0;

  close() {
    this.$emit("close");
  }

  saveShipment() {
    const shipment: IShipment = {
      productId: this.selectedProduct.id,
      settingQuantities: this.quantityReceived
    };

    this.$emit("save:shipment", shipment);
  }
}
</script>

<style lang="scss"></style>
