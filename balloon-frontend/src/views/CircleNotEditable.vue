<template>
  <div class="d-flex justify-content-center mt-5">
    <dynamic-circle :diameter="params.diameter" :color="params.color" />
  </div>
</template>

<script>
import DynamicCircle from "@/components/DynamicCircle.vue";
import { _httpClient } from "@/services";

export default {
  name: "CircleNotEditableView",
  components: {
    DynamicCircle,
  },
  data() {
    return {
      params: {},
    };
  },
  mounted() {
    _httpClient.get("api/balloon").then(({ data }) => this.params = data);
  },
  sockets: {
    circleUpdated(data) {
      this.params = data;
    },
  },
};
</script>