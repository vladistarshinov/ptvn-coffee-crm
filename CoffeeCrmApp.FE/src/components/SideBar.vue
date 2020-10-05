<template>
  <div>
    <input type="checkbox" id="nav-toggle" hidden />
    <nav class="nav">
      <label for="nav-toggle" class="nav-toggle" onclick></label>
      <h2 class="logo">
        <router-link to="/">
          <img alt="Vue logo" src="../assets/logo.png" />
        </router-link>
      </h2>
      <ul v-for="item in menuItem" :key="item.id">
        <li>
          <router-link :to="item.url">{{ item.title }}</router-link>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  name: "SideBar"
})
export default class SideBar extends Vue {
  menuItem = [
    {
      id: 1,
      title: "Инвентарь",
      url: "/inventory"
    },
    {
      id: 2,
      title: "Покупатели",
      url: "/customers"
    },
    {
      id: 3,
      title: "Счета",
      url: "/invoice"
    },
    {
      id: 4,
      title: "Заказы",
      url: "/orders"
    }
  ];
}
</script>

<style lang="scss"></style>
