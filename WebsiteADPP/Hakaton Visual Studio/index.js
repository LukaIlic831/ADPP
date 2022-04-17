window.localStorage.clear();
var kartice = document.getElementsByClassName('choose__card');
var checkbox = document.getElementsByClassName('checkbox');
var slike = document.getElementsByClassName('allcard__img');
var imena = document.getElementsByClassName('allcard__para');
var checkboxID = 0;
var nizSlika = [];
var nizImena = [];
var nizId = [];


window.addEventListener('scroll', function (){
    let navigation = document.querySelector('.back__btn');
    navigation.classList.toggle('back__btn--show', window.scrollY > 100);
}) 

function zatvoriProzor(){
    document.querySelector('.header__section--findMore-bg').style.display = "none";
    document.body.style.overflow = "scroll";
}

function otvoriProzor(){
    document.querySelector('.header__section--findMore-bg').style.display = "flex";
    document.body.style.overflow = "hidden";
}

for (var i = 0; i < kartice.length; i++) {
    kartice[i].addEventListener('click', function() {
        checkbox[this.id].checked == false ? checkbox[this.id].checked = true : checkbox[this.id].checked = false}, false);
}


function potvrdi(){
    for(var i=0; i<checkbox.length; i++){
        if (checkbox[i].checked) {
            nizSlika.push(slike[i].src);
            nizImena.push(imena[i].innerText);
            nizId.push(kartice[i].id);
        }
    }
    localStorage.setItem("nizSlika", nizSlika);
    localStorage.setItem("nizImena", nizImena);
    localStorage.setItem("nizId", nizId);
    console.log(localStorage.getItem("nizSlika"));
    window.location.href = "generisi.aspx";
}


