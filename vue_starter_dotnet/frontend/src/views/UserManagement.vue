<template>
  <div class="content">  
    <div class="options">
      <button @click="choice='addChoice'">Add User</button>
      <button @click="choice='editChoice'">Edit User</button>
      <button @click="choice='disableChoice'">Disable User</button>
      <button @click="choice='removeChoice'">Remove User</button>
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
export default {
  name: "User-Management",
  data() {
    return {
      choice: ""
    };
  },
  methods: {}
};
</script>