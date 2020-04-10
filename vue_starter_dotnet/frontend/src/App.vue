<template>
  <div id="app">
    
    <div class="content">
      <router-view />
      <div id="footer">
        <p>
          <a href="/privacy-policy/">Privacy Policy</a>
        </p>
        <div class="copy">Copyright © 2020, Sarnova, Inc. All Rights Reserved</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
a {
  color: #f0ab00;
}

body {
  background-color: #ffffff;
  background-repeat: repeat-all;
  background-position: center center;
  background-attachment: scroll;
  font-family: "Open sans", Arial, sans-serif;
  font-weight: 400;
  font-size: 14px;
  line-height: 22px;
  margin: 0;
}
#app {
  background-color: #004165;
  color: #ffffff;
  padding: 20px;
}
#footer {
  padding: 1px 10px 10px 10px;
  color: #d9d9d9;
  background-color: #004165;
}
button {
  background-color: transparent;
  border: 1px solid #bbbbbb;
  color: #ffffff;
  cursor: pointer;
  margin: 0 5px 20px 0;
  line-height: 18px;
}
img {
  width: 15%;
  height: auto;
  margin-left: 20px;
}
</style>