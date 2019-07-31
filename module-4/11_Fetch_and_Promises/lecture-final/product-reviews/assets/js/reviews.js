/* Data can be found at:
  data.json
  https://my-json-server.typicode.com/blazebiz/json1/reviews
*/
let reviews = [];

/**
 * Use fetch to get reviews array as json from some web service.
 */
function getReviews() {
  fetch('https://my-json-server.typicode.com/blazebiz/json1/reviews').then((response) => {
    // This is the function that will run when the fetch completes and returns a response
    response.json().then((jsonData) => {
      reviews = jsonData;
      displayReviews();
    })
  });

}

/**
 * This function when invoked will look at an array of reviews
 * and add it to the page by cloning the #review-template
 */
function displayReviews() {
  console.log("Display Reviews...");

  // first check to make sure the browser supports content templates
  if ('content' in document.createElement('template')) {
    // query the document for .reviews and assign it to a variable called container
    const container = document.querySelector(".reviews");
    // loop over the reviews array
    reviews.forEach((review) => {
      // get the template; find all the elements and add the data from our review to each element
      const tmpl = document.getElementById('review-template').content.cloneNode(true);
      tmpl.querySelector('img').setAttribute("src", review.avatar);
      tmpl.querySelector('.username').innerText = review.username;
      tmpl.querySelector('h2').innerText = review.title;
      tmpl.querySelector('.published-date').innerText = review.publishedOn;
      tmpl.querySelector('.user-review').innerText = review.review;
      container.appendChild(tmpl);
    });
  } else {
    console.error('Your browser does not support templates');
  }
}

document.addEventListener('DOMContentLoaded', () => {
  let button = document.querySelector('button');
  button.addEventListener('click', getReviews);
});

