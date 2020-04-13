<template>
  <div>
    <h3>{{title}}</h3>
    <div class="body-container">
      <div class="draft-box" v-for="(item, index) in drafts" :key="index">
        <span>{{item.productNumber}}</span>
        <hr />
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
      storedDrafts: [
        { productNumber: "123", productDescription: "generic item" }
      ],
      drafts: [],
      title: "Edit Drafts"
    };
  },
  props: {
    API_URL: String,
    selectedItems: Array
  },
  created() {},
  methods: {
    enterToChangeFields() {
      const allInputs = document.querySelectorAll("input");
      Array.from(allInputs).forEach((element, index) => {
        const isLastElement = index === allInputs.length - 1;
        element.onkeypress = event => {
          if (event.key === "Enter") {
            if (isLastElement) {
              // last element should go back to the first input that isn't the title
              allInputs[1].focus(); // element `0` is the #title input
            } else {
              // otherwise focus the next input
              allInputs[index + 1].focus();
            }
          }
        };
      });
    },
    saveDraft() {
      document.querySelector("#save-all").onclick = () => {
        this.drafts.forEach(draft => {
          let savedMatrixAValues = [];
          document
            .querySelectorAll(`#${draft} input`)
            .forEach(item => savedMatrixAValues.push(item.value));
          const matrixAString = JSON.stringify(savedMatrixAValues);
          window.localStorage.setItem(draft, matrixAString);
        });
      };
    }
  },
  mounted() {
    if (this.storedDrafts != null) {
      /* this.storedDrafts.forEach(draft => {
        try {
          JSON.parse(window.localStorage.getItem(draft)).forEach(item =>
            this.drafts.push(item)
          );
        } catch (error) {
          console.log(error);
        }
      }); */
      this.drafts = this.storedDrafts;
    }
    if (this.selectedItems != null) {
      this.selectedItems.forEach(id => {
        fetch(`${this.API_URL}/api/item/${id}`)
          .then(response => {
            return response.json();
          })
          .then(item => {
            this.drafts.push(item);
          });
      });
    }
  }
};
</script>

<style scoped>
.body-container {
  display: flexbox;
}
.draft-box {
  display: block;
  width: 25%;
}
input {
  width: 100%;
}
input.checkbox {
  display: inline;
}
</style>