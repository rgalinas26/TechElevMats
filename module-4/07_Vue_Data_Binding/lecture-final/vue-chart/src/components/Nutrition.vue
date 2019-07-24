<template>
  <div class="nutrition-control">
    <!-- add a form for nutrition element across meals -->
    <table style="text-align: right;">
      <thead>
        <tr>
          <th>Meal</th>
          <th class="th-carbs">Carbs (g)</th>
          <th class="th-protein">Protein (g)</th>
          <th class="th-fat">Fat (g)</th>
          <th>Total Calories</th>
        </tr>
      </thead>
      <tbody>
          <!-- TODO: loop through meals here, bind input boxes to model fields -->
        <tr v-for="meal in meals" v-bind:key="meal.id">
          <td>
            <input type="text" v-model="meal.meal" />
          </td>
          <td>
            <input type="number"  v-model.number="meal.carbs"/>
          </td>
          <td>
            <input type="number"  v-model.number="meal.protein"/>
          </td>
          <td>
            <input type="number"  v-model.number="meal.fat"/>
          </td>
          <!-- TODO: Add meal total here, calling calories() method -->
          <td>{{calories(meal)}}</td>
        </tr>
        <tr>
          <!-- TODO: add total g values here -->
          <td>Grams</td>
          <td>{{totalCarbs}}</td>
          <td>{{totalProtein}}</td>
          <td>{{totalFat}}</td>
          <td></td>
        </tr>
        <tr>
          <!-- TODO: add total calories values here -->
          <td>Calories</td>
          <td>{{totalCarbs * 4}}</td>
          <td>{{totalProtein * 4}}</td>
          <td>{{totalFat * 9}}</td>
          <td>{{totalCalories}}</td>
        </tr>
      </tbody>
    </table>

    <br />

    <!-- TODO: Set the width of the bars based on percentages -->
    <h3>Stacked Bar Chart</h3>
    <div class="barchart">
      <div class="barchart-carbs" v-bind:style="{width : percentCarbs}" >{{percentCarbs}}</div>
      <div class="barchart-protein" v-bind:style="{width : percentProtein}">{{percentProtein}}</div>
      <div class="barchart-fat" v-bind:style="{width : percentFat}">{{percentFat}}</div>
    </div>
    <br />

    <!-- TODO: Set the width of the bars based on percentages -->
    <h3>Bar Chart</h3>
    <div class="barchart3">
      <div class="chart3row">
        <div class="chart3title">Carbs</div>
        <div class="barchart-carbs" v-bind:style="{width : percentCarbs}" >{{percentCarbs}}</div>
      </div>
      <div class="chart3row">
        <div class="chart3title">Protein</div>
        <div class="barchart-protein" v-bind:style="{width : percentProtein}">{{percentProtein}}</div>
      </div>
      <div class="chart3row">
        <div class="chart3title">Fat</div>
        <div class="barchart-fat" v-bind:style="{width : percentFat}">{{percentFat}}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      meals: [
        {
          id: 1,
          meal: "Breakfast",
          carbs: 0,
          protein: 0,
          fat: 0
        },
        {
          id: 2,
          meal: "Lunch",
          carbs: 0,
          protein: 0,
          fat: 0
        },
        {
          id: 3,
          meal: "Dinner",
          carbs: 0,
          protein: 0,
          fat: 0
        },
        {
          id: 4,
          meal: "",
          carbs: 0,
          protein: 0,
          fat: 0
        },
        {
          id: 5,
          meal: "",
          carbs: 0,
          protein: 0,
          fat: 0
        }
      ]
    };
  },

  // TODO: Add the computed properties logic to sum across meals
  computed: {
    totalCarbs() {
      return this.meals.reduce( (sum, meal) => { return sum + meal.carbs; }, 0);
    },
    totalProtein() {
      return this.meals.reduce( (sum, meal) => { return sum + meal.protein; }, 0);
    },
    totalFat() {
      return this.meals.reduce( (sum, meal) => { return sum + meal.fat; }, 0);
    },
    totalCalories() {
      return this.meals.reduce( (sum, meal) => { return sum + this.calories(meal); }, 0);
    },
    percentCarbs() {
      if (this.totalCalories == 0 || this.totalCarbs === 0) return "";
      return (
        (this.totalCalories === 0
          ? 0
          : (this.totalCarbs * 400) / this.totalCalories
        ).toFixed(0) + "%"
      );
    },
    percentProtein() {
      if (this.totalCalories == 0 || this.totalProtein === 0) return "";
      return (
        (this.totalCalories === 0
          ? 0
          : (this.totalProtein * 400) / this.totalCalories
        ).toFixed(0) + "%"
      );
    },
    percentFat() {
      if (this.totalCalories == 0 || this.totalFat === 0) return "";
      return (
        (this.totalCalories === 0
          ? 0
          : (this.totalFat * 900) / this.totalCalories
        ).toFixed(0) + "%"
      );
    }
  },


  methods: {
    calories(meal) {
      return meal.carbs * 4 + meal.protein * 4 + meal.fat * 9;
    }
  }
};
</script>

<style scoped>

input {
  text-align: right;
}
.th-carbs {
  color: var(--carbs-fg);
  background-color: var(--carbs-bg);
}
.th-protein {
  color: var(--protein-fg);
  background-color: var(--protein-bg);
}
.th-fat {
  color: var(--fat-fg);
  background-color: var(--fat-bg);
}
.chart3row {
  height: 30px;
  display: flex;
  flex-direction: row;
}

.chart3title {
  width: 100px;
  padding: 0 5px;
}

.barchart3 {
  width: 80%;
  border: 1px solid darkgray;
  box-shadow: 5px 5px lightgray;
}

.barchart {
  height: 40px;
  width: 80%;
  display: flex;
  flex-direction: row;
  border: 1px solid darkgray;
  box-shadow: 5px 5px lightgray;
}

.barchart-carbs {
  height: 100%;
  color: var(--carbs-fg);
  background-color: var(--carbs-bg);
  text-align: center;
  border-top: 1px solid darkgray;
  border-right: 1px solid darkgray;
}

.barchart-protein {
  height: 100%;
  color: var(--protein-fg);
  background-color: var(--protein-bg);
  text-align: center;
  border-top: 1px solid darkgray;
  border-right: 1px solid darkgray;
}

.barchart-fat {
  height: 100%;
  color: var(--fat-fg);
  background-color: var(--fat-bg);
  text-align: center;
  border-top: 1px solid darkgray;
  border-right: 1px solid darkgray;
}
</style>
