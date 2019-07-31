// filename: fetchtxt.js

/*
    Fetch data from a text file and parse the response. (Embedded then's)
*/
fetch('demo.txt')           // sends an HTTP request to the relative path 'demo.txt'
    .then((response) => {   // get a Response object once this completes
        response.text()     // Call async function to get the text from the response
        .then( (txt) => {   // get a string once that completes
            console.log(txt);   // log the string data
            document.getElementById('results').innerText = txt
        })
    });

/*
    VERBOSE version of the above
*/
// let responsePromise = fetch('demo.txt');
// console.log(responsePromise);
// responsePromise.then(
//     (resp) => {
//         let stringPromise = resp.text();
//         console.log(responsePromise);
//         console.log(stringPromise);
//         stringPromise.then(
//             (str) => {
//                 console.log(stringPromise);
//                 console.log(str);
//                 document.getElementById('results').innerText = str;
//             }
//         );
//     }
// );



/*
    Fetch data from a text file and parse the response. (CHAINED then's)
*/
// fetch('demo.txt')               // sends an HTTP request to the relative path 'demo.txt'
//     .then((response) => {       // get a Response object once this completes
//         return response.text(); // Call async function to get the text from the response
//     }).then((txt) => {          // get a string once that completes
//         console.log(txt);       // log the string data
//         document.getElementById('results').innerText = txt
//     });

/*
    VERBOSE version of the above
*/
// let responsePromise = fetch('demo.txt');
// let stringPromise;
// console.log(responsePromise);
// responsePromise.then(
//     (resp) => {
//         stringPromise = resp.text();
//         console.log(responsePromise);
//         console.log(stringPromise);
//         return stringPromise;
//     }
// ).then( (str) => {
//     console.log(stringPromise);
//     console.log(str);
//     document.getElementById('results').innerText = str;
// });




/*
    Fetch and Catch
    Note that catch only catches network-type errors. If the call completes with a bad http response,
    it will not be caught.  You must check for a good response code.
*/
// fetch('demoxxx.txt')            // sends an HTTP request to the relative path 'demo.txt'
//     .then((response) => {       // get a Response object once this completes
//         if (response.ok) {
//         response.text()         // Call async function to get the text from the response
//         .then( (txt) => {       // get a string once that completes
//             console.log(txt);   // log the string data
//             document.getElementById('results').innerText = txt
//         })
//     }
//     else
//     {
//         console.log(`BAD STATUS CODE: ${response.status} ${response.statusText}`)
//     }
//     }).catch ( (err) => {
//         console.log(`There was an ERROR: ${err}`);
//     });



