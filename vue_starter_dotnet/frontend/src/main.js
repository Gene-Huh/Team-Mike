import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from "./store";

import {library} from "@fortawesome/fontawesome-svg-core";
import {faBars, faEdit, faTrash, faUser, faSave, faFileExport, faMinusCircle, faPlusCircle, faBan, faEye, faSearch, faClipboardCheck, faList, faTimesCircle} from "@fortawesome/free-solid-svg-icons";

library.add(faBars, faEdit, faTrash, faUser, faSave, faFileExport, faMinusCircle, faPlusCircle, faBan, faEye, faSearch,faClipboardCheck, faList, faTimesCircle);
Vue.config.productionTip = false

new Vue({
  store,
  router,
  render: h => h(App)
}).$mount('#app')
