<template>
  <div class="login">
    <h1>Login</h1>
    <form>
      <div class="form-element">
        <label for="username">Username:</label>
        <input id="username" type="text" required />
      </div>

      <div class="form-element">
        <label for="password">Password:</label>
        <input id="password" type="text" required />
      </div>
    </form>
    <router-link :to="{name: 'home'}">
      <button>Sign In</button>
    </router-link>    
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
// import auth from "../auth";

export default {
  name: "login",
  title: "Login",
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  // methods: {
  //   login() {
  //     fetch(, {
  //       method: "POST",
  //       headers: {
  //         Accept: "application/json",
  //         "Content-Type": "application/json"
  //       },
  //       body: JSON.stringify(this.user)
  //     })
  //       .then(response => {
  //         if (response.ok) {
  //           return response.text();
  //         } else {
  //           this.invalidCredentials = true;
  //         }
  //       })
  //       .then(token => {
  //         if (token != undefined) {
  //           if (token.includes('"')) {
  //             token = token.replace(/"/g, "");
  //           }
  //           auth.saveToken(token);
  //           this.$router.push("/");
  //         }
  //       })
  //       .catch(err => console.error(err));
  //   }
  // }
};
</script>

<style scoped>
    



</style>