import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

/* import { BootstrapVue, IconsPlugin, BAlert, AlertPlugin } from 'bootstrap-vue'; */
import PriceFilter from "@/filters/PriceFilter";
import DateFilter from "@/filters/DateFilter";
import DateTimeFilter from "@/filters/DateTimeFilter";
import VueApexChart from "vue-apexcharts";

Vue.config.productionTip = false;

Vue.filter("priceFilter", PriceFilter);
Vue.filter("dateFilter", DateFilter);
Vue.filter("datetimeFilter", DateTimeFilter);
Vue.component("apexchart", VueApexChart);
/* Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(AlertPlugin);
Vue.component('b-alert', BAlert); */

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
