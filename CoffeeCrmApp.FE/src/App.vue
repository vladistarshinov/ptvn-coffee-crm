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
    padding-left: $menu-width + 50px;
    width: 95%;
  }
}

@media screen and (max-width: 900px) {
  .app {
    &-content {
      padding-left: $small-menu-width + 30px;
    }
  }
}

@media screen and (max-width: 730px) {
  .app {
    &-content {
      padding-left: 50px;
    }
  }
}

@media screen and (max-width: 600px) {
  .app {
    &-content {
      padding-left: 20px;
    }
  }
}

@media screen and (max-width: 410px) {
   .app {
    &-content {
      padding-left: 10px;
    }
  }
}
</style>
