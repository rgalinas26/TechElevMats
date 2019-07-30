<template>
  <div id="app">
    <header>
      <div class="heading">Awesome Book Reviews</div>
    </header>
    <product-review />
  </div>
</template>

<script>
import ProductReview from '@/components/ProductReview.vue'

export default {
  name: 'app',
  components: {
    ProductReview
  }
}
</script>

<style>
#app {
  width: 800px;
  margin: auto;
}

body {
  margin: 0;
  padding: 0;
}
.content {
  width:800px;
  margin: 20px auto !important;
}
header {
  background-color: #E34232;
}

header > .heading {
  color: yellow;
  text-align: center;
  font-size: 2.0rem;  
  border-bottom: 1px solid yellow;
}

.nav {
  margin:0;
  padding:0;
  list-style-type: none;
  display: flex;
  justify-content: center;
}
.nav li {
  display: inline-block;
  padding:20px;
  color: #fff;
  background-color: #E34232;
}
.nav li a {
  color: #fff;
  text-transform: uppercase;
  font-size: 14px;
  text-decoration: none;
}
.nav li:hover {
  background-color: rgb(216, 216, 216);
  cursor: pointer;
  color:rgb(44, 44, 44);
}
.nav li a:hover {
  color:rgb(44, 44, 44);
}
.router-link-active {
  background-color: rgb(44, 44, 44);
}
</style>
