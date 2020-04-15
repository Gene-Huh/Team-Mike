<template>
  <div class="content">
    <Navbar />
    <div class="options">
      <button @click="choice='addChoice'">
        <font-awesome-icon icon="plus-circle" />Add User
      </button>
      <button @click="choice='editChoice'">
        <font-awesome-icon icon="edit" />Edit User
      </button>
      <button @click="choice='disableChoice'">
        <font-awesome-icon icon="ban" />Disable User
      </button>
      <button @click="choice='removeChoice'">
        <font-awesome-icon icon="minus-circle" />Remove User
      </button>
    </div>
    <div class="choice-forms-display">
      <form v-if="choice=='addChoice'">
        <h3>Add User</h3>
        <div class="form-element">
          <label for="firstName">First Name :</label>
          <input id="firstName" v-model="addForm.firstName" type="text" required />
        </div>
        <div class="form-element">
          <label for="lastName">Last Name :</label>
          <input id="lastName" v-model="addForm.lastName" type="text" required />
        </div>
        <div class="form-element">
          <label for="username">Username :</label>
          <input id="username" v-model="addForm.username" type="text" required />
        </div>
        <div class="form-element">
          <label for="password">Password :</label>
          <input id="password" v-model="addForm.password" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role:</label>
          <input name="role" v-model="addForm.role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" v-model="addForm.role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
        <button @click.prevent="addUser" type="submit">Confirm Add User</button>
      </form>
      <form v-if="choice=='editChoice'">
        <h3>Edit User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>
        <div class="form-element">
          <label for="firstName">First Name:</label>
          <input id="firstName" type="text" required />
        </div>
        <div class="form-element">
          <label for="lastName">Last Name:</label>
          <input id="lastName" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role:</label>
          <input name="role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
        <button @click.prevent="editUser" type="submit">Confirm Edit</button>
      </form>
      <form v-if="choice=='disableChoice'">
        <h3>Disable User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>
        <button @click.prevent="disableUser" type="submit">Confirm Disable User</button>
      </form>
      <form v-if="choice=='removeChoice'">
        <h3>Remove User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>
        <button @click.prevent="removeUser" type="submit">Confirm Remove User</button>
      </form>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
export default {
  name: "User-Management",
  components: {
    Navbar,
    FontAwesomeIcon
  },
  data() {
    return {
      choice: "",
      addForm: {
        firstName: "",
        lastName: "",
        userName: "",
        password: "",
        role: "",        
      },
       API_URL: process.env.APP_VUE_CONNECTION_STRING,
      
    };
  },
  methods: {
    addUser() {
      fetch(`${this.API_URL}/users/add`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json; charset=utf-8"
        },
        body: JSON.stringify(this.addForm)
      })
        // .then(response => response.json())
        .then(response => console.log(response.Body.text()));
      this.addForm.firstName = "";
      this.addForm.lastName = "";
      this.addForm.userName = "";
      this.addForm.password = "";
      this.addForm.role = "";
    }
  }
};
</script>

<style scoped>
.form-content {
  margin: 5px;
}
</style>