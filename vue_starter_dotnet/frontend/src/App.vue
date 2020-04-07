<template>
  <div id="app">
    <header>
    <div id="nav">
      <router-link to="/products">Products </router-link>
    </div>
    </header>
    <div class="content">
    <router-view/>
    </div>
  </div>
</template>

<script>

export default {
}
</script>

<style>

</style>