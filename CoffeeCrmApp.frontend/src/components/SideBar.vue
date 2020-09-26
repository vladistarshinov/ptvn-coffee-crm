<template>
    <div>
        <input type="checkbox" id="nav-toggle" hidden>
        <nav class="nav">
            <label for="nav-toggle" class="nav-toggle" onclick></label>
            <h2 class="logo"> 
                <img alt="Vue logo" src="../assets/logo.png" />
            </h2>
            <ul>
                <li><a href="#1">Один</a></li>
                <li><a href="#2">Два</a></li>
                <li><a href="#3">Три</a></li>
                <li><a href="#4">Четыре</a></li>
            </ul>
        </nav>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  name: "SideBar"
})
  export default class SideBar extends Vue {}
</script>

<style lang="scss">

</style>