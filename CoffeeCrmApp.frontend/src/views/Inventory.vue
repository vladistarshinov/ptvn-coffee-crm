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

    <Modal v-if="isShowNewProductModal">
      <template v-slot:header>
        Добавить новый продукт
      </template>
      <template v-slot:body>
        <ul class="newProduct">
          <li>
            <label for="productName">Название</label>
            <input type="text" id="productName" v-model="newProduct.name">
          </li>
          <li>
            <label for="productDescription">Описание</label>
            <input type="text" id="productDescription" v-model="newProduct.description">
          </li>
          <li>
            <label for="productPrice">Цена за шт.</label>
            <input type="number" id="productPrice" v-model="newProduct.price">
          </li>
          <li>
            <label for="isTaxable">Товар облагается налогом?</label>
            <input type="checkbox" id="isTaxable" v-model="newProduct.isTaxable">
          </li>
        </ul>
      </template>
      <template v-slot:footer>
        <button class="btn" type="button" @click.prevent="saveNewProduct">
          Добавить
        </button>
        <button
          class="btn"
          type="button"
          @click.prevent="isShowNewProductModal = false"
        >
          Закрыть
        </button>
      </template>
    </Modal>

    <Modal v-if="isShowShipmentModal" :inventory="inventory">
      <template v-slot:header>
        Прием чека
      </template>
      <template v-slot:body>
        <ul class="shipmentProducts">
          <li>
            <label for="product">Товар</label>
            <select
              class="shipmentItems"
              v-model="selectedProduct"
              id="product"
            >
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
        <button
          class="btn"
          type="button"
          @click.prevent="isShowShipmentModal = false"
        >
          Закрыть
        </button>
      </template>
    </Modal>
    <InventoryList :inventory="inventory" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IProduct, IProductInventory } from "@/types/Product";
import Modal from "@/components/Modal.vue";
import ShipmentModal from "@/components/ShipmentModal.vue";
import InventoryList from "@/components/InventoryList.vue";

@Component({
  name: "Inventory",
  components: { Modal, InventoryList }
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

  newProduct: IProduct = {
    id: 0,
    name: "",
    description: "",
    price: 0,
    isTaxable: false,
    isArchived: false,
    createdOn: new Date(),
    updatedOn: new Date()
  };

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
}
</script>
