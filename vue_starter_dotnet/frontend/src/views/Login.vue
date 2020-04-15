<template>
  <div class="login">
    <div class="content">
      <h1>Login</h1>
      <form>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" />
        </div>

        <div class="form-element">
          <label for="password">Password:</label>
          <input id="password" type="text" />
        </div>
      </form>
      <router-link :to="{name: 'home'}">
        <button>Sign In</button>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "login",
  title: "Login",
  data() {
    return {};
  }
};
</script>
<style>
</style>