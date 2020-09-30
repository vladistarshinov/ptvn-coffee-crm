<template>
  <div class="main">
    <div class="article">
      <h2>Главная</h2>
      <img
        class="title-separator"
        src="../assets/title-separator.png"
        alt="Разделитель"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  name: "Home"
})
export default class Home extends Vue {}
</script>
