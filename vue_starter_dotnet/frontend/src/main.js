import Vue from 'vue'
import App from './App.vue'
import router from './router'

import {library} from "@fortawesome/fontawesome-svg-core";
import {faBars, faEdit, faTrash, faUser, faSave, faFileExport, faMinusCircle, faPlusCircle, faBan, faEye, faSearch, faClipboardCheck} from "@fortawesome/free-solid-svg-icons";

library.add(faBars, faEdit, faTrash, faUser, faSave, faFileExport, faMinusCircle, faPlusCircle, faBan, faEye, faSearch,faClipboardCheck);
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
