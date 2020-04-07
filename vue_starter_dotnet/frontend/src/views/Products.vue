<template>
    <div class='products-list'>
    <h1>List of Products</h1>
    <button v-on:click="filterCriteria=false">Unapproved</button>
    <button v-on:click="filterCriteria=true">Approved</button>
    <table>
        <thead>
        <th>Number</th>
        <th>Default UOM</th>
        <th>Cross Reference</th>
        <th>Manufacturer ID</th>
        <th>Inventory Status</th>
        <th>Alternative Products</th> 
        <th>Description</th>      
        </thead>
            <hr/>
        <tbody>
        <tr v-for="item in filteredProductsList"
        v-bind:key="item.id">
        <td>{{item.ProductNumber}}</td>
        <td>{{item.DefaultUOM}}</td>
        <td>{{item.CrossReference}}</td>
        <td>{{item.ManufacturerId}}</td>
        <td>{{item.InventoryStatus}}</td>
        <td>{{item.AlternativeProducts}}</td>
        <td>{{item.ProductDescription}}</td>
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
                    return product.IsSellable==true;
                });
            },
            filteredProductsList() {
                const filter = this.filterCriteria;
                return this.products.filter(product => {
                    return product.IsSellable==filter;
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

<style scoped>
    hr {
        border: 1px solid #f0ab00;
    }
    h1, th {
        font-weight: 400;
    }
    button {
        background-color: transparent;
        border: 1px solid #bbbbbb;
        color: #ffffff;
        cursor: pointer;
        margin: 0 5px 20px 0;
        line-height: 18px;
    }
</style>