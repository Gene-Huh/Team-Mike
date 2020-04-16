<template>  
    <div class="content">
      <navbar/>       
      </div>      
</template>

<script>
import Navbar from "@/components/Navbar"
import auth from "../auth";

export default {
  components: {
    Navbar
  },
  data() {
    return {
      userRole: ""
    }
  },
  created() {
    auth.getToken();
    
  }
};
</script>