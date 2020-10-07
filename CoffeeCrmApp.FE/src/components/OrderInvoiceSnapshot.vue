<template>
  <div class="invoice-step-detail">
    <div class="invoice-logo">
      <img id="imgLogo" src="../assets/logo-snapshot.png" alt="Corretto logo" />
      <h5>г. Томск, пр. Ленина, 25, офис 221</h5>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
      <h4>Мы благодарим Вас за выбор нашей компании!</h4>
      <div class="invoice-order" v-if="orderItems.length">
        <div class="invoice-order__header">
          <h4>Дата и время заказа: {{ new Date() | datetimeFilter }}</h4>
          <h4>Клиент: {{ this.selectedCustomer.firstName + " " + this.selectedCustomer.lastName }} </h4>
          <h4>Email: {{ this.selectedCustomer.primaryAddress.email }}</h4>
          <h4>Адрес: 
            {{ "г. " + 
                this.selectedCustomer.primaryAddress.city +
                ", " +  
                this.selectedCustomer.primaryAddress.address1 + 
                "-" + 
                this.selectedCustomer.primaryAddress.address2 
            }} 
          </h4>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { ICustomer } from "@/types/Customer";
import { IOrderItem } from "@/types/Invoice";
@Component({
  name: "OrderInvoiceSnapshot"
})
export default class OrderInvoiceSnapshot extends Vue {
  @Prop({
    required: true,
    type: Array as () => ICustomer[]
  })
  customers!: ICustomer[];
  @Prop({
    required: true
  })
  readonly selectedCustomerId!: number;
    @Prop({
    required: true,
    type: Array as () => IOrderItem[]
  })
  orderItems!: IOrderItem[];

  get selectedCustomer() {
    return this.customers.find(c => c.id == this.selectedCustomerId);
  }

  created() {
    console.log(this.selectedCustomerId)
      
  }
}
</script>

<style lang="scss">
.invoice-step-detail {
  margin: 0.5rem;
}
.invoice {
  &-logo {
    padding-top: 0.6rem;
    text-align: center;
    img {
      width: 180px;
    }
}
  &-order {
    margin-top: 0.4rem;
    padding: 0.4rem;
    &__header {
      width: 100%;
    }   
  }
}
</style>