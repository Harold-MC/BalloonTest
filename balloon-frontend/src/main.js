import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueSignalR from '@latelier/vue-signalr';

//TODO: usar plugin
Vue.use(VueSignalR, `${process.env.VUE_APP_BASE_API}/hub`);

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
