<template>
  <div class="invoice-step-detail" id="invoice" ref="invoice">
    <div class="invoice-logo">
      <img id="imgLogo" src="../assets/logo-snapshot.png" alt="Corretto logo" />
      <h3>г. Томск, пр. Ленина, 25, офис 221</h3>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
      <h3>Мы благодарим Вас за выбор нашей компании!</h3>
      <div class="invoice-order" v-if="orderItems.length">
        <div class="invoice-order__header">
          <h3>Дата и время заказа: {{ new Date() | datetimeFilter }}</h3>
          <h3>Клиент: {{ this.selectedCustomer.firstName + " " + this.selectedCustomer.lastName }} </h3>
          <h3>Email: {{ this.selectedCustomer.primaryAddress.email }}</h3>
          <h3>Адрес: 
            {{ "г. " + 
                this.selectedCustomer.primaryAddress.city +
                ", " +  
                this.selectedCustomer.primaryAddress.address1 + 
                "-" + 
                this.selectedCustomer.primaryAddress.address2 
            }} 
            </h3>
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
  margin: 1.2rem;
}

.invoice {
    &-logo {
        padding-top: 1.4rem;
        text-align: center;
        img {
            width: 220px;
        }
    }
    &-order {
        margin-top: 1.2rem;
        padding: 0.8rem;
        &__header {
            width: 100%;
            margin-bottom: 1.2rem;
        }   
    }
}
</style>