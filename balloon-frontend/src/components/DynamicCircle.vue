<template>
  <div :style="allAttributes" class="dynamic-circle">
  </div>
</template>

<script>
export default {
  name: "DynamicCircle",
  props: {
    diameter: {
      type: [String, Number],
      default: () => 100
    },
    color: {
      type: String,
      default: () => null
    }
  },
  computed: {
    diameterSize(){
      return `width:${this.diameter}px;height:${this.diameter}px;`
    },
    circleColor(){
      return `background-color: ${this.color};`;
    },
    allAttributes(){
      return this.circleColor + this.diameterSize;
    }
  }
};
</script>

<style scoped>
.dynamic-circle {
  position: relative;
  border-radius: 50%;
}
</style>