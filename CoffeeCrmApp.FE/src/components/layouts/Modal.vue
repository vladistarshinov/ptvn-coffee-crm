<template>
  <transition name="modal-fade">
    <div class="modal-backdrop">
      <div
        class="modal"
        role="dialog"
        aria-labelledby="modalTitle"
        aria-describedby="modalDescription"
      >
        <header class="modal-header" id="modalTitle">
          <slot name="header"></slot>
        </header>
        <section class="modal-body" id="modalDescription">
          <slot name="body"></slot>
        </section>
        <footer class="modal-footer">
          <slot name="footer"></slot>
        </footer>
      </div>
    </div>
  </transition>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
@Component({
  name: "Modal",
  components: {}
})
export default class Modal extends Vue {
  close() {
    this.$emit("close");
  }
}
</script>

<style lang="scss">
@import "@/styles/index.scss";
.modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.6);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal {
  background: #fff;
  box-shadow: 2px 2px 20px 1px;
  overflow-x: auto;
  display: flex;
  flex-direction: column;
  width: 60%;
  margin-left: 320px;
  border-radius: 3px;

  &-header {
    padding: 15px;
    display: flex;
    background-color: $coffee-color;
    color: #fff;
    font-size: 1.2rem;
    font-weight: bold;
    border-bottom: 1px solid #eee;
    justify-content: flex-start;
  }

  &-body {
    position: relative;
    padding: 1.4rem 1.8rem;
  }

  &-footer {
    padding: 15px;
    display: flex;
    border-top: 1px solid #eee;
    justify-content: center;
  }
}
.modal-fade-enter,
.modal-fade-leave-active {
  opacity: 0;
}
.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.5s ease;
}

@media screen and (max-width: 935px) {
  .modal {
    height: 70%;
  }
}

@media screen and (max-width: 900px) {
  .modal {
    margin-left: 240px;
    height: 65%;
    width: 65%;
  }
}

@media screen and (max-width: 730px) {
  .modal {
    margin-left: 0;
    width: 80%;
  }
}

@media screen and (max-width: 430px) {
  .modal {
    width: 85%;
    height: 60%;

    &-header {
      font-size: 0.8rem;
    }

    &-body {
      padding: 1rem;
    }

    &-footer {
      padding: 10px;
    }
  }
}
</style>
