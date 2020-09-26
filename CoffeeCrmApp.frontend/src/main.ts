import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import PriceFilter from '@/filters/PriceFilter';

Vue.config.productionTip = false;

Vue.filter('priceFilter', PriceFilter);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
