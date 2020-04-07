<template>
<div class="login">
    <h1>Login</h1>
    <form>
        <div class="form-element">
        <label for="username">Username:</label>
        <input id="username" type="text"></div>

        <div class="form-element">
        <label for="password">Password:</label>
        <input id="password" type="text"></div>
    </form>
    <router-link :to="{name: 'products'}"><button>Sign In</button></router-link>
    
</div>
</template>

<script>
export default {
    name: 'login',
    title: "Login",
    data () {
        return {

        }
    }
}
</script>

<style scoped>

</style>