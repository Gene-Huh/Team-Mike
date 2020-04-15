<template>
  <div class="navbar">
    <router-link :to="{name: 'products-list'}" exact class="products" tag="button" v-if="$route.name!=='products-list'">
      <font-awesome-icon icon="eye" /> Product List
    </router-link>

    <router-link :to="{name: 'edit'}" class="edit" tag="button" v-if="$route.name!=='edit'">
      <font-awesome-icon icon="edit" /> Edit Products
    </router-link>

    <router-link
      :to="{name: 'user-management'}"
      class="user-management"
      tag="button" v-if="$route.name!=='user-management'"
    >
    <font-awesome-icon icon = "user" /> User Management</router-link>
    <hr />
  </div>
</template>

<script>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
export default {
  name: "Navbar",
  components: {
    FontAwesomeIcon
  },
  data() {
    return {};
  }
};
</script>
