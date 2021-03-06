import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: () => import(/* webpackChunkName: "home" */ "../views/Home.vue")
  },
  {
    path: "/inventory",
    name: "Inventory",
    component: () =>
      import(/* webpackChunkName: "inventory" */ "../views/Inventory.vue")
  },
  {
    path: "/customers",
    name: "Customers",
    component: () =>
      import(/* webpackChunkName: "customers" */ "../views/Customers.vue")
  },
  {
    path: "/invoice/new",
    name: "Invoices",
    component: () =>
      import(/* webpackChunkName: "invoice" */ "../views/Invoices.vue")
  },
  {
    path: "/orders",
    name: "Orders",
    component: () =>
      import(/* webpackChunkName: "orders" */ "../views/Orders.vue")
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
