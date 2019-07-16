// Anonymous functions
/**
 * Transform each element
 * @param {string[]} array An array of strings to call an operation on
 * @param {function(s)} operation Function to apply to each element
 * @returns {string[]} Array of transformed elements
 */
function applyToAllElements(array, operation) {
  let outArray = [];
  for (let i = 0; i < array.length; i++) {
    outArray.push(operation(array[i]));
  }
  return outArray;
}

let arr = ["The", "quick", "brown"];
arr = ["now", "is", "the", "time"];

function upCase(s) {
  return s.toUpperCase();
}

/***

// Now we can call the function, passing in the named array and named function...
applyToAllElements(arr, upCase);

// Or we can call the function, passing in the an un-named array...
applyToAllElements(["Mike", "morel"], upCase);

// Or we can call the function, passing in the an un-named array AND and un-named function...
applyToAllElements(["Mike", "morel"], function (s) {return s.toUpperCase();});

// Or use the shortcut syntax for defining a function
applyToAllElements(["Mike", "morel"], (s) => {return s.toUpperCase();});

***/


/**
 * All named functions will have the function keyword and
 * a name followed by parentheses.
 */
function returnOne() {
  return 1;
}

/**
 * Functions can also take parameters. These are just variables that are filled
 * in by whoever is calling the function.
 *
 * Also, we don't *have* to return anything from the actual function.
 *
 * @param {any} value the value to print to the console
 */

 /**
  * Prints something to the console.
  * @param {any} value The element to print to console
  * @returns {number} The number of items printed
  */
function printToConsole(value) {
  console.log(value);
}

/**
 * Write a function called multiplyTogether that multiplies two numbers together. But 
 * what happens if we don't pass a value in? What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */
function multiplyTogether(firstParameter, secondParameter){
  if (Number(firstParameter) === NaN || Number(secondParameter) === NaN)
  {
    return NaN;
  }
  if (secondParameter === undefined)
  {
    return NaN;
  }
  return firstParameter * secondParameter;
}


/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=0] the second parameter to multiply
 */
function multiplyTogether(firstParameter = 0, secondParameter = 1){
  return firstParameter * secondParameter;
}

/**
 * Scope is defined as where a variable is available to be used.
 *
 * If a variable is declare inside of a block, it will only exist in
 * that block and any block underneath it. Once the block that the
 * variable was defined in ends, the variable disappears.
 */
function scopeTest() {
  // This variable will always be in scope in this function
  let inScopeInScopeTest = true;

  {
    // this variable lives inside this block and doesn't
    // exist outside of the block
    let scopedToBlock = inScopeInScopeTest;
  }

  // scopedToBlock doesn't exist here so an error will be thrown
  if (inScopeInScopeTest && scopedToBlock) {
    console.log("This won't print!");
  }
}

function createSentenceFromUser(name, age, listOfQuirks = [], separator = ', ') {
  let description = `${name} is currently ${age} years old. Their quirks are: `;
  return description + listOfQuirks.join(separator);
}

/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce(
    (accumulator, item) => { return accumulator + item; }
  );
}

/**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {
  return numbersToFilter.filter( (num) => { return (num % 3 === 0) });
}


let people = [
  { name: "Bobby", age: 27, height: 71 },
  { name: "Tyler", age: 23, height: 72 },
  { name: "El", age: 26, height: 60 },
  { name: "Jesse", age: 29, height: 78 },
  { name: "Chris", age: 29, height: 74 },
  { name: "Sirrena", age: 24, height: 71 },
  { name: "John S", age: 42, height:70 },
  { name: "Jacob", age: 23, height: 70 },
];

// List all the people using foreach
function listAllPeople() {
  people.forEach( (person) => {
    console.log(`Name: ${person.name} is ${person.age} years old and ${person.height} inches tall.`);
  });
}

// Filter people by height or age
function getTallPeople(minHeight){
  return people.filter( (p) => {
    return (p.height >= minHeight);
  });
}

// Map height to string format


// Reduce to total height of all people
function getTotalHeight(){
  return people.reduce( (accum, person) => {
    return accum + Number(person.height);
  }, 0 );
}

/**
 * Sorts the people array (above) by the specified field (n, a or h)
 * 
 * @param {string} sortBy Character representing field to sort by (a, n, h)
 * @returns {[]} A sorted array of people
 */
function sortPeople(sortBy = "n") {
  return people.sort( (p1, p2) => {
    return p2.height - p1.height;
    // if (p1.height > p2.height)
    // {
    //   return 1;
    // }
    // else if (p1.height < p2.height)
    // {
    //   return -1;
    // }
    // else
    // {
    //   return 0;
    // }
  }

  );
}
