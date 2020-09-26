<template>
  <div class="app">
    <div class="app-menu">
      <SideBar />
    </div>
    <div class="app-content">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SideBar from "@/components/SideBar.vue";

@Component({
  name: "App",
  components: { SideBar }
})
export default class App extends Vue {}
</script>

<style lang="scss">
  @import "@/styles/index.scss";

  .app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
    display: flex;

    &-content {
      padding-left: 330px;
      width: 90%;
    }
  }

  @media screen and (max-width: 640px) {
    .app {
      &-content {
      padding-left: 50px;
      width: 90%;
    }
    }
  }

</style>
