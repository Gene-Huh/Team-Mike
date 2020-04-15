<template>
  <div class="content">
    <Navbar />
    <Drafts :selectedItems="selectedItems" :API_URL="API_URL" />
  </div>
</template>

<script>
import Drafts from "@/components/Drafts.vue";
import Navbar from "@/components/Navbar"
export default {
  name: "edit",
  components: {
    Drafts,
    Navbar
  },
  props: {
    selectedItems: []
  },
  data() {
    return {
      
      API_URL: "http://localhost:64458/api"
    };
  }
};
</script>