<template>
    <div class="pagination">
        <div class="pagination__element"
            v-for="(page, i) in pages" :key="i"
            @click.prevent="pageSelect(page)"
        >
            {{page}}
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
@Component({
  name: "Pagination",
  components: {}
})
export default class Pagination extends Vue {
  @Prop({
    required: true
  })
  pages!: number;
  @Prop({
    required: true
  })
  pageSelect!: Function;
}
</script>

<style lang="scss">
.pagination {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    margin-top: 30px;
    margin-bottom: 30px;

    &__element {
        padding: 2px 6px;
        margin-right: 10px;
        border: 1px solid #e7e7e7;
        cursor: pointer;
        transition: .5s all;

        &:hover {
            background: rgba(#442d25, .75);
            color: #fff;
        }

        &:active {
            background: #442d25;
            border: 3px solid rgb(31, 30, 30);
        }
    }
}
</style>

