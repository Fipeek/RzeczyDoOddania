// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const searchSelect = document.getElementById('searchSelect');
const input = document.getElementById('searchInput');
const categorySelect = document.getElementById('categorySelect');
searchSelect.addEventListener("change", changeVisibility);

function changeVisibility(event) {

    if (event.target.value === 'Category') {
        input.classList.add('deactive');
        categorySelect.classList.remove('deactive');
    }
    else {
        input.classList.remove('deactive');
        categorySelect.classList.add('deactive');
    }
} 