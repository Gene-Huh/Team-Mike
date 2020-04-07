<template>
    <div class='products-list'>
    <h1>List of Products</h1>
    <button v-on:click="filterCriteria=false">Unapproved</button>
    <button v-on:click="filterCriteria=true">Approved</button>
    <table>
        <thead>
        <th>Number</th>
        <th>Default UOM</th>
        <th>Is Sellable</th>
        <th>Description</th>      
        </thead>
        <tbody>
        <tr v-for="item in filteredProductsList"
        v-bind:key="item.id">
        <td>{{item.productNumber}}</td>
        <td>{{item.defaultUOM}}</td>
        <td>{{item.isSellable}}</td>
        <td>{{item.productDescription}}</td>
        </tr>
        </tbody>
    </table>
    </div>
</template>

<script>
    export default {
        name: 'products',
        data() {
            return {
                API_URL: 'https://5e86b771781e48001676b31e.mockapi.io/api/Products',
                products: [],
                filterCriteria: false
            }
        },
        computed: {
            approvedProductsList() {
                return this.products.filter(product => {
                    return product.isSellable==true;
                });
            },
            filteredProductsList() {
                const filter = this.filterCriteria;
                return this.products.filter(product => {
                    return product.isSellable==filter;
                });
            }
        },
        created() {
            fetch(this.API_URL)
            .then(response => {
                return response.json();
            })
            .then(products => {
                this.products = products;
            })
            .catch(err => console.log(err));
        }
    };
</script>

<style>

</style>