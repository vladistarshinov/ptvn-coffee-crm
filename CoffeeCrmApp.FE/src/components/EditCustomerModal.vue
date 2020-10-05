<template>
  <Modal>
    <template v-slot:header>
      Полная информация о клиенте
    </template>
    <template v-slot:body>
      <ul class="showCustomer">
        <li>
          <label for="clientFirstName">Имя покупателя</label>
          <input
            type="text"
            id="clientFirstName"
            v-model="customer.firstName"
          />
        </li>
        <li>
          <label for="clientLastName">Фамилия покупателя</label>
          <input type="text" id="clientLastName" v-model="customer.lastName" />
        </li>
        <li>
          <label for="clientPhone">Номер телефона</label>
          <input type="text" id="clientPhone" v-model="customer.phone" />
        </li>
        <li>
          <label for="clientEmail">Email</label>
          <input
            type="text"
            id="clientEmail"
            v-model="customer.primaryAddress.email"
          />
        </li>
        <li>
          <label for="clientAddress1">Адрес(дом)</label>
          <input
            type="text"
            id="clientAddress1"
            v-model="customer.primaryAddress.address1"
          />
        </li>
        <li>
          <label for="clientAddress2">Адрес(квартира)</label>
          <input
            type="number"
            id="clientAddress2"
            v-model="customer.primaryAddress.address2"
          />
        </li>
        <li>
          <label for="clientCity">Город</label>
          <input
            type="text"
            id="clientCity"
            v-model="customer.primaryAddress.city"
          />
        </li>
        <li>
          <label for="clientCountry">Страна</label>
          <input
            type="text"
            id="clientCountry"
            v-model="customer.primaryAddress.country"
          />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <button
        class="btn"
        type="button"
        @click.prevent="editCustomerInfo(customer.id)"
      >
        Обновить
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
import { ICustomer } from "@/types/Customer";
@Component({
  name: "EditCustomerModal",
  components: { Modal }
})
export default class EditCustomerModal extends Vue {
  @Prop({
    required: true,
    type: Object as () => ICustomer
  })
  customer!: ICustomer;

  editCustomerInfo(customerId: number) {
    const editCustomer: ICustomer = {
      id: customerId,
      firstName: this.customer.firstName,
      lastName: this.customer.lastName,
      phone: this.customer.phone,
      primaryAddress: {
        id: this.customer.primaryAddress.id,
        country: this.customer.primaryAddress.country,
        city: this.customer.primaryAddress.city,
        email: this.customer.primaryAddress.email,
        address1: this.customer.primaryAddress.address1,
        address2: this.customer.primaryAddress.address2,
        createdOn: this.customer.primaryAddress.createdOn,
        updatedOn: new Date()
      },
      createdOn: this.customer.createdOn,
      updatedOn: new Date()
    };
    this.$emit("edit:customer", editCustomer.id, editCustomer);
  }

  close() {
    this.$emit("close");
  }
}
</script>

<style lang="scss"></style>
