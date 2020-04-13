<template>
  <div class="home">
    <header>
    
          <router-link :to="{name: 'products-list'}" exact class="products" tag="button">Products List</router-link>
          <router-link :to="{name: 'edit'}" class="edit" tag="button">Edit</router-link>
          
    </header>
    <div class="content">
        <router-view />
    </div>
  </div>
</template>

<script>
export default {}
</script>