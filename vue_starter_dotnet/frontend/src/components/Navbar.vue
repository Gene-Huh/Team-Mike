<template>
<div class="navbar">
  <router-link :to="{name: 'products-list'}" exact class="products" tag="button">Products List</router-link>
  <router-link :to="{name: 'edit'}" class="edit" tag="button">Edit</router-link>
</div>
</template>

