// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("JS connected")

//////Create Player//////

const createPlayerOverall = document.querySelector("#createPlayerOverall")

const createPlayerStatInputs = document.querySelectorAll(".statInput")

const paceInput = document.querySelector("#paceInput")
const shootingInput = document.querySelector("#shootingInput")
const passingInput = document.querySelector("#passingInput")
const dribblingInput = document.querySelector("#dribblingInput")
const defendingInput = document.querySelector("#defendingInput")
const physicalInput = document.querySelector("#physicalInput")

//ERROR - cannot add event listener?
createPlayerStatInputs.addEventListener('change', updateOverall);

function updateOverall(e){
    console.log(e.target.value)
}