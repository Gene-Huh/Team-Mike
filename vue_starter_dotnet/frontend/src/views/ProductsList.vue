<template>
  <div class="products-list">
    <span>Select List Type:</span>
    <button v-on:click="getUnapprovedList()">Unapproved</button>
    <button v-on:click="getApprovedList()">Approved</button>
    <SearchBar v-on:filter-list="handleSearch" />
    <ProductsList :data="data" :search="search" :title="currentList" :API_URL="API_URL"/>
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
        })
        .catch(err => console.log(err));
      this.currentList = "Unapproved Products List";
    },

    getApprovedList() {
      fetch(`${this.API_URL}/products/1`)
        .then(response => {
          return response.json();
        })
        .then(products => {
          this.data = products;
        })
        .catch(err => console.log(err));
      this.currentList = "Approved Products List";
    }
  }
};
</script>

<style>
button {
  margin: 1% 1% 1% 1%;
  border-radius: 25px;
  padding: 5px 10px;
  font-weight: bold;
}
button:hover {
  background-color: #f0ab00;
  color: black;
}
</style>