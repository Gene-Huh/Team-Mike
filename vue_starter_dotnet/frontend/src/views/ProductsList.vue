<template>
  <div class="content">
    <Navbar />
    <span>Select List Type:</span>
    <button v-on:click="getUnapprovedList()">Unapproved</button>
    <button v-on:click="getApprovedList()">Approved</button>
    <ProductsList :data="data" :listType="currentList" :API_URL="API_URL"/>
  </div>
</template>

<script>
import ProductsList from "@/components/ProductsList";
import Navbar from "@/components/Navbar";

export default {
  name: "products-list",
  components: {
    ProductsList,
    Navbar
  },
  data() {
    return {
      data: [],
      currentList: "",
      API_URL: "http://localhost:64458/api",
      selectedItems: []
    };
  },
  methods: {
    edit(){
      this.$router.push({name: 'edit', params:{selectedItems: this.selectedItems}})
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


</style>