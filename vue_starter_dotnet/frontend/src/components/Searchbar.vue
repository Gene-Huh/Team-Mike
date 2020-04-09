<template>
  <div>
    <input
      type="text"
      id="search"
      name="search"
      v-on:keyup="filterList"
      placeholder="Enter search here"
    />
    <input type="text" />
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