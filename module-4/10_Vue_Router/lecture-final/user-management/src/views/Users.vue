<template>
    <div class="users">
        <h1>Users</h1>
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="user in users" v-bind:key="user.id">
                    <td>{{user.id}}</td>
                    <td><router-link v-bind:to="{name: 'user', params: {id: user.id}}">{{user.name}}</router-link></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import userService from '@/service/UserService.js'
export default {
    name: "users",
    data() {
        return {
            users: []
        }
    },

    methods: {
        getUsers() {
            userService.list().then( (data) => {
                this.users = data;
            } )
        }
    },

    // "Hey, Vue! Tell us when this component has been created."
    created() {
        console.log('The Users comonent has been created.');
        this.getUsers();
    }

}
</script>

<style>

</style>
