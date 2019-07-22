<template>
  <div class="main">
    <h2>Product Reviews for {{name}}</h2>
    <p class="description">{{description}}</p>
    <div class="review" v-for="r in reviews" >
      <h4>{{ r.reviewer }}</h4>
      <div class="rating">
        <!-- <img src="img/star.png" class="ratingStar" /> -->
      </div>
      <h3>{{ r.title }}</h3>
      <p>{{r.review}}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "product-review",
  data() {
    return {
      name: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all of your squirrelly friends.",
      reviews: [
        {
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review:
            "It certainly is a book. I mean, I can see that. Pages kept together with glue (I hope that's glue) and there's writing on it, in some language.",
          rating: 3
        },
        {
          reviewer: "Tim Ferriss",
          title: "Had a cigar party started in less than 4 hours.",
          review:
            "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
          rating: 4
        },
        {
          reviewer: "Ramit Sethi",
          title: "What every new entrepreneurs needs. A door stop.",
          review:
            "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
          rating: 1
        },
        {
          reviewer: "Gary Vaynerchuk",
          title: "And I thought I could write",
          review:
            "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
          rating: 3
        }
      ]
    };
  }
};
</script>

<style>
</style>
