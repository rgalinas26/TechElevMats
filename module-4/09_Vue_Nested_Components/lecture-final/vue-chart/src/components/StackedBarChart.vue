<template>
    <div class="barchart">
      <div class="barchart-bar" v-for="(item, index) in chartData" v-bind:key="index"  v-bind:style="{'width': item.percent, 'background-color' : item.color}">{{item.percent}}</div>
    </div>
</template>

<script>
export default {
    props: {
        chartData : Array
    },
    data() {
        return {
        }
    }
};

</script>

<style scoped>
.barchart {
  height: 40px;
  width: 80%;
  display: flex;
  flex-direction: row;
  border: 1px solid darkgray;
  box-shadow: 5px 5px lightgray;
}

.barchart-bar {
  height: 100%;
  text-align: center;
  border-top: 1px solid darkgray;
  border-right: 1px solid darkgray;
}
</style>