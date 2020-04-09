<template>
<div class = "products-display">
  
  <button v-on:click="ConfirmChanges()">Confirm Changes</button>

  <table>
    <caption>{{title}}</caption>
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
    <hr />
    <tbody>
      <tr v-for="item in filteredList" v-bind:key="item.id" :class="{selected: item.selected}">
        <td>
          <input type="checkbox" @click="MarkSelected(item.productNumber)" autocomplete="off" />
        </td>
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
  name: "products-list",
  props: {
      title: String,
      search: String,
      data: Array,
  },
  data() {
      return {
        selectedItems: []
      };
  },
  methods: {
      changeStatus(id, event){
          const arrIndex = this.data.findIndex(item => item.productNumber == id);
          this.data[arrIndex].selected = !this.data[arrIndex].selected;

          if (event.target.type != "checkbox") {
              const checkbox = event.target.querySelector('input[type="checkbox"]');
              checkbox.checked = !checkbox.checked;
          }
      }, 
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
        fetch(`${this.API_URL}/item/${item.productNumber}`, { //localhost:#####/api/item/[Object object]
          method: "PUT",
          headers: {
            "Content-Type": "application/json; charset=utf-8"
          },
          body: JSON.stringify(item)
        }).then(response => {
          console.log(`SUCCESS ${response}`);
        });
      });
     
    }
  },
  computed: {
      filteredList() {
          const filter = new RegExp(this.search, 'i');
          return this.data.filter(item => item.manufacturerId.match(filter));
      }
  }
};
</script>

<style>
.tr.selected {
    color: goldenrod;
}
</style>