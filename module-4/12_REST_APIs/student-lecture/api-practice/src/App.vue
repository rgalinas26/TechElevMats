<template>
  <div id="app">
    <to-do />
  </div>
</template>

<script>
import Todo from '@/components/Todo.vue'

export default {
  name: 'app',
  components: {
    'to-do' : Todo
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
