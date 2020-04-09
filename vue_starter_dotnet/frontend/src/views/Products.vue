<template>
  <div class="products">
    <div class = "lists">
    <button v-on:click="getUnapprovedList()">Unapproved</button>
    <button v-on:click="getApprovedList()">Approved</button>
    </div>

    
    <button v-on:click="ConfirmChanges()">Confirm Changes</button>
    
  </div>
</template>

<script>
export default {
  name: "products",
  data() {
    return {
      
      products: [],
      filterCriteria: false,
      selectedItems: [],
      currentList: ''
    };
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
/*         return this.products.filter(product => {
                    product.isSellable==0;  
                }); */
      return this.products;
    }
  },
  methods: {
    

    MarkSelected(productNumber) {
      if (this.selectedItems.includes(productNumber)) {
        let tempSelectedItems = this.selectedItems.filter(
          item => item !== productNumber
        );
        this.selectedItems = tempSelectedItems;
      } else {
        this.selectedItems.push(productNumber);
      }
      console.log(this.selectedItems);
    },
    ConfirmChanges() {
      this.selectedItems.forEach(item => {
        fetch(`${this.API_URL}/item/${item.productNumber}`, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json; charset=utf-8"
          },
          body: JSON.stringify(item)
        }).then(response => {
          console.log(`SUCCESS ${response}`);
        });
      });
      // .then(products => {
      //     this.products = products;
      // })
      // .catch(err => console.log(err));
      /* if (this.lastSelected=="unapproved"){
          this.getUnapprovedList();
      }
      else {
          this.getApprovedList();
      } */
      /* window.location.assign('http://localhost:8080/products'); */
    }
    
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
h1,
th {
  font-weight: 400;
}

</style>