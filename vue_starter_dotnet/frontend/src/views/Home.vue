<template>
  <div class="home">
    <header>
    <h2>Welcome</h2>
          <router-link :to="{name: 'products-list'}" exact class="products" tag="button">Products List</router-link>
          <router-link :to="{name: 'edit'}" class="edit" tag="button">Edit</router-link>
          <router-link :to="{name: 'user-management'}" class="user-management" tag="button">User Management</router-link>
          
    </header>
    <div class="content">
      <navbar/>
      <router-link :to="{name: 'products-list'}" exact class="products" tag="button">Products List</router-link>
      <router-link :to="{name: 'edit'}" class="edit" tag="button">Edit</router-link>
      <router-view />
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar"
export default {
  components: {
    Navbar
  }
};
</script>