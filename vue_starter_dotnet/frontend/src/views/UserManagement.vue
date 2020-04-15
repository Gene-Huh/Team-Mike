<template>
  <div class="content">
    <Navbar />
    <div class="options">
      <button @click="choice='addChoice'">
        <font-awesome-icon icon="plus-circle" /> Add User</button>
      <button @click="choice='editChoice'">
        <font-awesome-icon icon="edit" /> Edit User</button>
      <button @click="choice='disableChoice'">
        <font-awesome-icon icon="ban" /> Disable User</button>
      <button @click="choice='removeChoice'">
        <font-awesome-icon icon="minus-circle" /> Remove User</button>
    </div>
    <div class="choice-forms-display">
      <form v-if="choice=='addChoice'">
        <h3>Add User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>

        <div class="form-element">
          <label for="password">Password:</label>
          <input id="password" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role</label>
          <input name="role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
      </form>
      <form v-if="choice=='editChoice'">
        <h3>Edit User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>

        <div class="form-element">
          <label for="password">Password:</label>
          <input id="password" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role</label>
          <input name="role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
      </form>
      <form v-if="choice=='disableChoice'">
        <h3>Disable User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>

        <div class="form-element">
          <label for="password">Password:</label>
          <input id="password" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role</label>
          <input name="role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
      </form>
      <form v-if="choice=='removeChoice'">
        <h3>Remove User</h3>
        <div class="form-element">
          <label for="username">Username:</label>
          <input id="username" type="text" required />
        </div>

        <div class="form-element">
          <label for="password">Password:</label>
          <input id="password" type="text" required />
        </div>
        <div class="form-element">
          <label for="role">Role</label>
          <input name="role" type="radio" value="User" />
          <label for="User">User</label>
          <input name="role" type="radio" value="Admin" />
          <label for="Admin">Administrator</label>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/Navbar";
import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome";

export default {
  name: "User-Management",
  components: {
    Navbar,
    FontAwesomeIcon
  },
  data() {
    return {
      choice: ""
    };
  },
  methods: {}
};
</script>