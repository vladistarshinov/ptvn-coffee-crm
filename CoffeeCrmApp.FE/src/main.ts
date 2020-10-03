import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

/* import { BootstrapVue, IconsPlugin, BAlert, AlertPlugin } from 'bootstrap-vue'; */
import PriceFilter from "@/filters/PriceFilter";

Vue.config.productionTip = false;

Vue.filter("priceFilter", PriceFilter);
/* Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(AlertPlugin);
Vue.component('b-alert', BAlert); */

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
