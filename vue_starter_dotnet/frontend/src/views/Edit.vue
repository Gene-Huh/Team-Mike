<template>
  <div class="edit">
    <span>Edit Items:</span>
    <button v-on:click="getUnapprovedList()">Load draft</button>
    <button v-on:click="getApprovedList()">Save draft</button>
    <button v-on:click="getApprovedList()">Confirm</button>
    
    <Drafts :selectedItems="selectedItems" :API_URL="API_URL" />
  </div>
</template>

<script>
import Drafts from "@/components/Drafts.vue";


export default {
  name: "edit",
  components: {
    Drafts
  },
  data() {
    
  }
}
</script>