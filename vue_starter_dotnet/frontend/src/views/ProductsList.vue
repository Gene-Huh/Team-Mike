<template>
  <div class="products-list">
    <button v-on:click="getUnapprovedList()">Unapproved</button>
    <button v-on:click="getApprovedList()">Approved</button>
    <SearchBar v-on:filter-list="handleSearch" />
    <ProductsList :data="data" :search="search" :title="currentList" />
  </div>
</template>

<script>
import ProductsList from "@/components/ProductsList";
import SearchBar from "@/components/Searchbar";

export default {
  name: "products-list",
  components: {
    ProductsList,
    SearchBar
  },
  data() {
    return {
      search: "",
      data: [],
      currentList: "",
      API_URL: "http://localhost:64458/api"
    };
  },
  methods: {
    handleSearch(query) {
      console.log("filter-list", query);
      this.search = query;
    },

    getUnapprovedList() {
      fetch(`${this.API_URL}/products/0`)
        .then(response => {
          return response.json();
        })
        .then(products => {
          this.data = products;
          this.selectedItems = [];/* 
          return this.data; */
        })
        .catch(err => console.log(err));
      this.currentList = "Unapproved";
    },

    getApprovedList() {
      fetch(`${this.API_URL}/products/1`)
        .then(response => {
          return response.json();
        })
        .then(products => {
          this.data = products;
          this.selectedItems = [];
          return this.data;
        })
        .catch(err => console.log(err));
      this.currentList = "Approved";
    }
  }
};
</script>