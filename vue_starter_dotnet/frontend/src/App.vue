<template>
  <div id="app">
    <header>
    <div id="nav">
      <router-link to="/">Home</router-link>
      <router-link to="/products"> </router-link>
    </div>
    </header>
    <div class="content">
    <router-view/>
    </div>
  </div>
</template>
