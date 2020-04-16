<template>
  <div class="content">
    <navbar />
    <div class="team-mike">
      <div>
        <h3>Searra Schell</h3>
        <p>https://www.linkedin.com/in/searra-schell/</p>
      </div>
      <div>
        <h3>Shabnam Ahmed</h3>
        <p>https://www.linkedin.com/in/shabnam-ahmed/</p>
      </div>
      <div>
        <h3>Gene Huh</h3>
        <p>https://www.linkedin.com/in/geneshuh/</p>
      </div>
      <div>
        <h3>Paul Curtin</h3>
        <p>https://www.linkedin.com/in/curtinpaul1/</p>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar";
import auth from "../auth";

export default {
  components: {
    Navbar
  },
  data() {
    return {
      userRole: ""
    };
  },
  created() {
    auth.getToken();
  }
};
</script>
<style>
.team-mike {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
  height: 50vh;
  align-items: center;
}
.team-mike div {
  flex-basis: 50%;
}
h3 {
  color: #f0ab00
}
</style>