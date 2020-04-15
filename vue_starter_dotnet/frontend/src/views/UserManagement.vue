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
      <button @click="choice='deleteChoice'">
        <font-awesome-icon icon="minus-circle" />Delete User
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
          <input id="username" v-model="addForm.userName" type="text" required />
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
          <input id="username" v-model="editForm.userName" type="text" required />
        </div>
        <div class="form-element">
          <label for="firstName">First Name:</label>
          <input id="firstName" v-model="editForm.firstName" type="text" required />
        </div>
        <div class="form-element">
          <label for="lastName">Last Name:</label>
          <input id="lastName" v-model="editForm.lastName" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role:</label>
          <input name="role" v-model="editForm.role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" v-model="editForm.role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
        <button @click.prevent="editUser" type="submit">Confirm Edit</button>
      </form>
      <form v-if="choice=='disableChoice'">
        <h3>Disable User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" v-model="userName" type="text" required />
        </div>
        <button @click.prevent="disableUser" type="submit">Confirm Disable User</button>
      </form>
      <form v-if="choice=='deleteChoice'">
        <h3>Delete User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" v-model="userName" type="text" required />
        </div>
        <button @click.prevent="deleteUser" type="submit">Confirm Delete User</button>
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
      API_URL: "http://localhost:64458/api",

      addForm: {
        firstName: "",
        lastName: "",
        userName: "",
        password: "",
        role: ""
      },
      editForm: {
        firstName: "",
        lastName: "",
        userName: "",
        role: ""
      },
      userName: ""
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
        //.then(response => response.json())
        .then(response => console.log(response));
      this.addForm.firstName = "";
      this.addForm.lastName = "";
      this.addForm.userName = "";
      this.addForm.password = "";
      this.addForm.role = "";
    },
    editUser() {
      fetch(`${this.API_URL}/users/edit/${this.editForm.userName}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json; charset=utf-8"
        },
        body: JSON.stringify(this.editForm)
      }).then(console.log(Response.text()));
      this.editForm.firstName = "";
      this.editForm.lastName = "";
      this.editForm.userName = "";
      this.editForm.role = "";
    },

    disableUser() {
      fetch(`${this.API_URL}/users/disable/${this.userName}`);
    },

    deleteUser() {
      fetch(`${this.API_URL}/users/delete/${this.userName}`, {
        method: "DELETE"
      }
      );
    }
  }
};
</script>

<style scoped>
.form-content {
  margin: 5px;
}
</style>