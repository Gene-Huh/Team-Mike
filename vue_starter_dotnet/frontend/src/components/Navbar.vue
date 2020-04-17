<template>
  <div class="sidebar">
    <div class="sidebar-backdrop" @click="closeSidebarPanel" v-if="isPanelOpen"></div>
    <transition name="slide">
      <div v-if="isPanelOpen" class="sidebar-panel">
        <button @click="toggle" style="float: right; border: 0px" class="close-panel">
        <font-awesome-icon icon="times-circle" size="2x"/>
        </button>
        <hr style = "border: 0px; margin-bottom: 50px;"/>
        <router-link
          :to="{name: 'products-list'}"
          exact
          class="products"
          v-if="$route.name!=='products-list'"
        >
          <font-awesome-icon icon="list" />Product List
        </router-link>
        <hr />
        <router-link :to="{name: 'edit'}" class="edit" v-if="$route.name!=='edit'">
          <font-awesome-icon icon="edit" />Edit Products
        </router-link>
        <hr />
        <router-link
          :to="{name: 'user-management'}"
          class="user-management"
          v-if="$route.name!=='user-management' && isAdmin"
        >
          <font-awesome-icon icon="user" />User Management
        </router-link>
        <hr />
        <button @click="logout" class="logout">Log Out</button>
      </div>
    </transition>
  </div>
</template>

<script>
var jwt = require("jwt-simple");
import { store, mutations } from "@/store.js";
import auth from "../auth";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

export default {
  name: "Navbar",
  components: {
    FontAwesomeIcon
  },
  data() {
    return {
      isAdmin: ""
    };
  },
  methods: {
    closeSidebarPanel: mutations.toggleNav,
    toggle() {
    //  this.isBurgerActive =! this.isBurgerActive;
      mutations.toggleNav();
    },

    logout() {
      auth.destroyToken();
      this.$router.push("/");
    }
  },
  computed: {
    isPanelOpen() {
      return store.isNavOpen;
    }
  },
  mounted() {
    let token = auth.getToken();
    if (token) {
      var decoded = jwt.decode(token, "TechElevatorCodingBootamp");
      this.isAdmin = decoded.rol == "Admin";
      console.log(decoded.rol);
    }
  }
};
</script>
<style>
.slide-enter-active,
.slide-leave-active {
  transition: transform 0.2s ease;
}

.slide-enter,
.slide-leave-to {
  transform: translateX(-100%);
  transition: all 150ms ease-in 0s;
}

.sidebar-backdrop {
  background-color: rgba(19, 15, 64, 0.4);
  width: 100vw;
  height: 100vh;
  position: fixed;
  top: 0;
  left: 0;
  cursor: pointer;
}

.sidebar-panel {
  overflow-y: auto;
  background-color: #004165;
  position: fixed;
  left: 0;
  top: 0;
  height: 100vh;
  z-index: 999;
  padding: 3rem 20px 2rem 20px;
  width: 300px;
}
.sidebar-panel {
  display: block;
}

.close-panel:hover {
  background-color: #004165;
  color: #ffff
}

</style>