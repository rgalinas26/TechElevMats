<template>
  <div class="user-profile">
    <h1>User {{user.name}}</h1>
    <h3>Email: {{user.email}}</h3>

    <table>
      <thead>
        <tr>
          <th>Property</th>
          <th>Value</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(val, prop) in user" v-bind:key="prop">
            <td>{{prop}}</td>
            <td>{{val}}</td>
        </tr>
      </tbody>
    </table>
    <!-- <pre>{{user}}</pre> -->
    <router-link v-bind:to="{name: 'users'}">Back to list</router-link>
  </div>
</template>

<script>
import userService from "@/service/UserService.js";
export default {
  data() {
    return {
      user: null
    };
  },

  methods: {
    getUser(id) {
      userService.get(id).then(data => {
        this.user = data;
      });
    }
  },

  created() {
    const userId = this.$route.params.id;
    console.log(`Looking up user id ${userId}.`);
    this.getUser(userId);
  }
};
</script>

<style>
</style>
