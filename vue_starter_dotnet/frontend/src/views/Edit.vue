<template>
  <div class="edit">

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