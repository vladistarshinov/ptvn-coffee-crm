<template>
  <Modal>
    <template v-slot:header>
      Добавить нового клиента
    </template>
    <template v-slot:body>
      <ul class="newCustomer">
        <li>
          <label for="clientFirstName">Имя покупателя</label>
          <input
            type="text"
            id="clientFirstName"
            v-model="newCustomer.firstName"
          />
        </li>
        <li>
          <label for="clientLastName">Фамилия покупателя</label>
          <input
            type="text"
            id="clientLastName"
            v-model="newCustomer.lastName"
          />
        </li>
        <li>
          <label for="clientPhone">Номер телефона</label>
          <input type="text" id="clientPhone" v-model="newCustomer.phone" />
        </li>
        <li>
          <label for="clientAddress1">Адрес(дом)</label>
          <input
            type="text"
            id="clientAddress1"
            v-model="newCustomer.primaryAddress.address1"
          />
        </li>
        <li>
          <label for="clientAddress2">Адрес(квартира)</label>
          <input
            type="number"
            id="clientAddress2"
            v-model="newCustomer.primaryAddress.address2"
          />
        </li>
        <li>
          <label for="clientEmail">Email</label>
          <input
            type="text"
            id="clientEmail"
            v-model="newCustomer.primaryAddress.email"
          />
        </li>
        <li>
          <label for="clientCity">Город</label>
          <input
            type="text"
            id="clientCity"
            v-model="newCustomer.primaryAddress.city"
          />
        </li>
        <li>
          <label for="clientCountry">Страна</label>
          <input
            type="text"
            id="clientCountry"
            v-model="newCustomer.primaryAddress.country"
          />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <button class="btn" type="button" @click.prevent="addNewCustomer">
        Добавить
      </button>
      <button class="btn" type="button" @click.prevent="close">
        Закрыть
      </button>
    </template>
  </Modal>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Modal from "@/components/layouts/Modal.vue";
import { ICustomer } from "@/types/Customer";
@Component({
  name: "NewCustomerModal",
  components: { Modal }
})
export default class NewCustomerModal extends Vue {
  newCustomer: ICustomer = {
    id: 0,
    firstName: "",
    lastName: "",
    phone: "",
    primaryAddress: {
      id: 0,
      country: "",
      city: "",
      email: "",
      address1: "",
      address2: "",
      createdOn: new Date(),
      updatedOn: new Date()
    },
    createdOn: new Date(),
    updatedOn: new Date()
  };

  addNewCustomer() {
    this.$emit("add:newCustomer", this.newCustomer);
  }

  close() {
    this.$emit("close");
  }
}
</script>

<style lang="scss"></style>
