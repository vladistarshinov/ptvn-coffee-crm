<template>
  <div>
    <apexchart
      type="area"
      width="100%"
      height="300"
      :options="options"
      :series="series"
    >
    </apexchart>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { IInventoryTimeline } from "@/types/InventoryGraph";
import { Sync, Get } from "vuex-pathify";
@Component({
  name: "InventoryChart",
  components: {},
})
export default class InventoryChart extends Vue {
  @Sync("snapshotTimeline")
  snapshotTimeline: IInventoryTimeline;

  @Get("isTimelineBuilt")
  isTimelineBuilt: boolean;

  get options() {
    return {
      dataLabels: {
        enabled: true,
      },
      fill: {
        type: "gradient",
      },
      stroke: {
        curve: "smooth",
      },
      xaxis: {
        categories: this.snapshotTimeline.timeline,
        type: "datetime",
      },
    };
  }

  get series() {
    return this.snapshotTimeline.inventorySnapshots
        .map((snapshot) => ({
            name: snapshot.productName,
            data: snapshot.quantityOnHand,
        })
    );
  }

  async created() {
    await this.$store.dispatch("assignSnapshots");
  }
}
</script>

<style lang="scss"></style>
