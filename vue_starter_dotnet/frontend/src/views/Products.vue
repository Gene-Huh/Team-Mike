<template>
    <div class='products-list'>
    <h1>List of Products</h1>
    <button v-on:click="getUnapprovedList()">Unapproved</button>
    <button v-on:click="getApprovedList()">Approved</button>
    <button v-on:click="ConfirmChanges()">Confirm Changes</button>
    <table>
        <thead>  
        <th>Select</th>
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
        <td><input type="checkbox" @change="MarkSelected(item.productNumber)"></td>
        <td>{{item.productNumber}}</td>
        <td>{{item.defaultUOM}}</td>
        <td>{{item.crossReference}}</td>
        <td>{{item.manufacturerId}}</td>
        <td>{{item.inventoryStatus}}</td>
        <td>{{item.alternativeProducts}}</td>
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
                API_URL: 'http://localhost:64458/api/products',
                products: [],
                filterCriteria: false,
                selectedItems: []
            }
        },
        computed: {
           /*  approvedProductsList() {
                return this.products.filter(product => {
                    return product.isSellable==true;
                });
            }, */
            filteredProductsList() {
/*                const filter = this.filterCriteria;
                if(filter){
                    let approvedList = this.getApprovedList();
                    return approvedList;
                }
                else {
                    return this.getUnapprovedList();
                } */
/*                return this.products.filter(product => {
                    return product.isSellable==filter;  
                });*/
                return this.products;
            }
        },
         methods: {
            getUnapprovedList() {
                fetch(`${this.API_URL}/0`)
            .then(response => {
                return response.json();
            })
            .then(products => {
                this.products = products;
                this.selectedItems = [];
                return products;
            })
            .catch(err => console.log(err));
            },

            getApprovedList() {
                fetch(`${this.API_URL}/1`)
            .then(response => {
                return response.json();
            })
            .then(products => {
                this.products = products;
                this.selectedItems = [];
                return products;
            })
            .catch(err => console.log(err));
            },

            MarkSelected(productNumber){
                if (this.selectedItems.includes(productNumber)){
                    let tempSelectedItems = this.selectedItems.filter(item => item !== productNumber);
                    this.selectedItems = tempSelectedItems;
                } else{
                    this.selectedItems.push(productNumber);
                } 
                console.log(this.selectedItems);
            },
        //     ConfirmChanges(){
        //         this.selectedItems.forEach(item => {     
                
        //         fetch(this.API_URL, {
        //             method: 'PUT',
        //             headers: {
        //                 'Content-Type': 'application/json; charset=utf-8'
        //             },
        //             body: JSON.stringify(item)
        //         })
        //     .then(response => {

        //         console.log(`SUCCESS ${response}`);
        //     })
        //     });
        //     // .then(products => {
        //     //     this.products = products;
        //     // })
        //     // .catch(err => console.log(err));
        // } 
                }

         /* , 
        
        created() {
            fetch(this.API_URL)
            .then(response => {
                return response.json();
            })
            .then(products => {
                this.products = products;
            })
            .catch(err => console.log(err));
        }  */
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