<template>
  <div>
    <span>Edit Items:</span>
    <button v-on:click="saveDrafts()">Save</button>
    <button v-on:click="confirmDrafts()">Confirm</button>

    <div class="body-container">
      <div class="draft-box" v-for="(item, index) in drafts" :key="index">
        <span>
          <h4>Product Number: {{item.productNumber}}</h4>
        </span>
        <label for="description">Description</label>
        <input type="text" name="description" v-model="item.productDescription" />
        <label for="sellable">Cross Reference</label>
        <input type="text" name="crossReference" v-model="item.crossReference" />
        <label for="manufacturerId">Manufacturer</label>
        <input type="text" name="manufacturerId" v-model="item.manufacturerId" />
        <label for="inventoryStatus">Inventory Status</label>
        <input type="text" name="inventoryStatus" v-model="item.inventoryStatus" />
        <label for="alternativeProducts">Alternative Products</label>
        <input type="text" name="alternativeProducts" v-model="item.alternativeProducts" />
        <div>
          <input type="checkbox" class="checkbox" name="sellable" v-model="item.isSellable" />
          <label for="sellable">Approved</label>
        </div>
        <div>
          <input
            type="checkbox"
            class="checkbox"
            name="drugControlled"
            v-model="item.isDrugControlled"
          />
          <label for="drugControlled">Drug Controlled</label>
        </div>
        <div>
          <input type="checkbox" class="checkbox" name="returnable" v-model="item.isNonReturnable" />
          <label for="returnable">Returnable</label>
        </div>
        <div>
          <input type="checkbox" class="checkbox" name="refrigerated" v-model="item.isRefrigerated" />
          <label for="refrigerated">Refrigerated</label>
        </div>
        <div>
          <input type="checkbox" class="checkbox" name="regulated" v-model="item.isRegulated" />
          <label for="regulated">Regulated</label>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "drafts",
  data() {
    return {
      storedDrafts: [],
      drafts: [],
      title: "Edit Drafts"
    };
  },
  props: {
    API_URL: String
  },
  created() {
    this.selectedItems = this.$route.params.selectedItems;
  },
  methods: {
    saveDrafts() {
      const draftString = JSON.stringify(this.drafts);
      window.localStorage.setItem("productNumber", draftString);
    },

    /* loadDrafts() {
      try {
        const data = JSON.parse(window.localStorage.getItem("productNumber"));
        data.forEach(item => this.drafts.push(item));
      } catch (error) {
        console.log(error);
      }
    } */
  },
  mounted() {
    JSON.parse(window.localStorage.getItem("productNumber")).forEach(item =>
      this.drafts.push(item)
    );
    if (this.selectedItems != null) {
       let filtered = this.drafts.filter(product => !this.selectedItems.includes(product.productNumber));
        filtered.forEach(id => {{
          fetch(`${this.API_URL}/item/${id}`)
          .then(response => {
            return response.json();
          })
          .then(item => {
            this.drafts.push(item);
          });
        }
        
      });
    }
  }
};
</script>

<style scoped>
.body-container {
  display: flexbox;
  flex-direction: row;
}
.draft-box {
  display: block;
  width: 25%;
  border-bottom: 2px solid #f0ab00;
}
input {
  width: 100%;
}
input.checkbox {
  display: inline;
  width: auto;
}
span {
  margin-bottom: 5px;
}
</style>