// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const searchSelect = document.getElementById('searchSelect');
const input = document.getElementById('searchInput');
const categorySelect = document.getElementById('categorySelect');
categorySelect.style.display = "none";
searchSelect.addEventListener("change", changeVisibility);

const toggleExpand = (event) =>{
    console.log('xdddd');
    event.target.classList.toggle("offer--expand");
}

const offers = document.getElementById('offers');
const offer = offers.getElementsByClassName('offer');
const backdrop = document.getElementById('backdrop');
Array.from(offer).forEach(o => o.addEventListener("click", o => {
    if(o.target.classList.contains('offer')){
        console.log('xdddd');
        backdrop.classList.toggle('offers--hidden');
        o.target.classList.toggle('offer--expand');
        document.body.classList.toggle('no-scroll');
    }
}));

backdrop.addEventListener('click', function(){
    document.body.classList.toggle('no-scroll');
    backdrop.classList.toggle('offers--hidden');
    document.querySelector('.offer--expand').classList.toggle('offer--expand');
})

function changeVisibility(event) {

    if (event.target.value === 'Category') {
        input.style.display = "none";
        categorySelect.style.display = "block";
    }
    else {
        input.style.display = "block";
        categorySelect.style.display = "none";
    }
} 
