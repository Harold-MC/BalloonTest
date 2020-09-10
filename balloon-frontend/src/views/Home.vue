<template>
  <section>
    <div class="d-flex mt-5">

      <div class="form-group mx-5 my-0">
        <label class="font-weight-bold" for="input-color">Seleccionar Color</label>
        <input
          type="color"
          class="form-control"
          id="input-color"
          v-model="params.color"
        />
      </div>

      <div class="mr-5 my-0">
        <label class="font-weight-bold mr-3" for="input-diameter">Tamaño del Globo</label>
        <input
          id="input-diameter"
          type="text"
          class="form-control"
          v-model="params.diameter"
          aria-describedby="emailHelp"
        />
      </div>
      <div class="d-flex mr-5 align-items-end">
        <button @click="openTab" type="button" class="btn btn-info">Abrir Pestaña</button>
      </div>
      <div class="d-flex align-items-end">
        <button @click="updateTabs" type="button" class="btn btn-info">Guardar y Replicar</button>
      </div>
    </div>

    <div style="display: flex; justify-content:center; margin-top: 50px;">
      <dynamic-circle :color="params.color" :diameter="params.diameter" />
    </div>
  </section>
</template>

<script>
import { _httpClient } from "@/services";
import DynamicCircle from "@/components/DynamicCircle.vue";

export default {
  name: "Home",
  components: {
    DynamicCircle,
  },
  data() {
    return {
      params: {
        diameter: null,
        color: null
      },
    };
  },
  mounted() {
    _httpClient.get("api/balloon").then(({ data }) => this.params = data);
  },
  methods: {
    openTab(){
      window.open('/circle-view', '_blank')
    },
    updateTabs() {
      _httpClient
        .put("api/balloon", {
          diameter: Number(this.params.diameter),
          color: this.params.color,
        })
        .then(() => {
          alert("Valores Refrescados en otras pestañas");
        });
    },
  },
};
</script>