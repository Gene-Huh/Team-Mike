<template>
  <div>
    <label for="search">Search: </label>
    <input
      type="text"
      id="search"
      name="search"
      v-on:keyup="filterList"
      placeholder="Enter search here"
    />
  </div>
</template>

<script>
export default {
    methods: {
        filterList() {
            const query = document.getElementById('search').value;
            this.$emit('filter-list', query);
        }
    }
}
</script>
<style scoped>
label{
  margin-right: 20px;
}
</style>