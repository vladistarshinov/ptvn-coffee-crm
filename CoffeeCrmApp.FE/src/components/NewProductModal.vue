<template>
  <Modal>
    <template v-slot:header>
      Добавить новый продукт
    </template>
    <template v-slot:body>
      <ul class="newProduct">
        <li>
          <label for="productName">Название</label>
          <input type="text" id="productName" v-model="newProduct.name" />
        </li>
        <li>
          <label for="productDescription">Описание</label>
          <input
            type="text"
            id="productDescription"
            v-model="newProduct.description"
          />
        </li>
        <li>
          <label for="productPrice">Цена за шт.</label>
          <input type="number" id="productPrice" v-model="newProduct.price" />
        </li>
        <li>
          <label for="isTaxable">Товар облагается налогом?</label>
          <input
            type="checkbox"
            id="isTaxable"
            v-model="newProduct.isTaxable"
          />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <button class="btn" type="button" @click.prevent="addNewProduct">
        Добавить
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
@Component({
  name: "NewProductModal",
  components: { Modal }
})
export default class NewProductModal extends Vue {
  @Prop({ 
    required: true, 
    type: Array as () => IProductInventory[] 
  })
  inventory!: IProductInventory[];

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

  addNewProduct() {
    this.$emit("add:newProduct", this.newProduct);
  }

  close() {
    this.$emit("close");
  }
}
</script>

<style lang="scss"></style>
