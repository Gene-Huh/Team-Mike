<template>
  <div class="home">
    <header>
      <ul id="nav">
          <router-link :to="{name: 'products-list'}" exact class="products" tag="button"><li>Products List</li></router-link>
          <router-link :to="{name: 'edit'}" class="edit" tag="button"><li>Edit</li></router-link>
      </ul>
    </header>
    <div class="content">
        <router-view />
    </div>
  </div>
</template>

<script>
export default {}
</script>