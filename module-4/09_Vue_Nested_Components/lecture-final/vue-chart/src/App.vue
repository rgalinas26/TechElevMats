<template>
  <div id="app">
    <nutrition-chart class="nutrition" v-on:dataChanged="handleDataChange"></nutrition-chart>
    <br/>
    <h3>The Chart</h3>
    <stacked-bar-chart v-bind:chartData="nutritionChartData"></stacked-bar-chart>
  </div>
</template>

<script>
import Nutrition  from './components/Nutrition.vue'
import StackedBarChart  from './components/StackedBarChart.vue'

export default {
  name: 'app',
  components: {
    'nutrition-chart' : Nutrition,
    'stacked-bar-chart' : StackedBarChart
  },
  data() {
    return {
      nutritionChartData : []
    }
  },
  methods: {
    handleDataChange(eventChartData) {
        this.nutritionChartData = eventChartData;
    }
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
