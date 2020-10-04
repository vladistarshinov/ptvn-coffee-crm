import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

/* import { BootstrapVue, IconsPlugin, BAlert, AlertPlugin } from 'bootstrap-vue'; */
import PriceFilter from "@/filters/PriceFilter";
import DataFilter from "@/filters/DataFilter";
import TimeFilter from "@/filters/TimeFilter";

Vue.config.productionTip = false;

Vue.filter("priceFilter", PriceFilter);
Vue.filter("dataFilter", DataFilter);
Vue.filter("timeFilter", TimeFilter);
/* Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(AlertPlugin);
Vue.component('b-alert', BAlert); */

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
