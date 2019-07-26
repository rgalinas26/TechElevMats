<template>
  <div id="app">
    <nutrition-chart class="nutrition"></nutrition-chart>
  </div>
</template>

<script>
import Nutrition  from './components/Nutrition.vue'

export default {
  name: 'app',
  components: {
    'nutrition-chart' : Nutrition
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
  width: 100%;
}
</style>
