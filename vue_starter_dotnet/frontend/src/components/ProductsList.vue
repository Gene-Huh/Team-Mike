<template>
  <div class="products-display">
    <div class="confirm">
      <button v-on:click="confirmChanges()" id="confirm">Confirm Changes</button>
    </div>
    <table>
      <caption>
        <h2>{{title}}</h2>
      </caption>
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
        <tr
          v-for="item in filteredList"
          v-bind:key="item.productNumber"
          :class="item.productNumber"
        >
          <td>
            <input
              type="checkbox"
              @click="markSelected($event)"
              v-model="selectedItems"
              :value="item.productNumber"
              :id="item.productNumber"
            />
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
    API_URL: String
  },
  data() {
    return {
      selectedItems: []
    };
  },
  methods: {
    resetStatus(productNumber) {
      const checkBox = document.getElementById(productNumber);
      checkBox.checked = false;
      checkBox.parentNode.classList.remove("selected");
      const arrIndex = this.data.findIndex(item => item.productNumber == productNumber);
      this.data.splice(arrIndex, 1);
    },
    markSelected(event) {
      event.stopPropagation();
      const { target } = event;
      const tableRow = target.closest("tr");
      if (!target.checked) {
        tableRow.classList.remove("selected");
      } else {
        tableRow.classList.add("selected");
      }
    },

    confirmChanges() {
      this.selectedItems.forEach(item => {
        this.resetStatus(item);
        fetch(`${this.API_URL}/item/${item}/Sellable`, {
          //localhost:#####/api/item/[Object object]
          method: "PUT",
          headers: {
            "Content-Type": "application/json; charset=utf-8"
          },
          body: JSON.stringify(item)
        }).then(response => {
          let rText = response.text().toString();
          if (rText == 0) {
            console.log(`FAIL: ${rText} failed to change isSellable value`);
          } else {
            console.log(`SUCCESS: ${rText} changed isSellable value`);
          }
        });
        this.selectedItems = [];
      });
    }
  },
  computed: {
    filteredList() {
      const filter = new RegExp(this.search, "i");
      return this.data.filter(item => item.productNumber.match(filter));
    }
  }
};
</script>

<style>
.selected {
  background-color: #f0ab00;
  color: black;
  padding: 0;
  margin: 0;
}
caption {
  background-color: white;
  color: black;
}
table {
  border-style: hidden;
  margin: 5px;
  border-collapse: collapse;
}
/* hr {
  border: 1px solid #f0ab00;
}
h1,
th {
  font-weight: 400;
} */
</style>