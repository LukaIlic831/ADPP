var slike = localStorage.getItem('nizSlika');
var imena = localStorage.getItem('nizImena');
var id = localStorage.getItem('nizId');
var nizslika = slike.split(',');
var nizimena = imena.split(',');
var nizid = id.split(',');
const ispisK = document.querySelector(".final__block--wrapper");
var y = 1;
var txt = "";
var brojac = -1;

function ispisiKartice() {
    if (slike !== '') {
        for (var i = 0; i < nizslika.length; i++) {
            txt += `
         <div class="final__blockk">
         <div class="final__block--desc">
            <figure class="final__block--img-wrapper">
                <img src="${nizslika[i]}" alt="" class="final__img">
            </figure> 
            <div class="final__block--para">
               <div class="vreme">
               <p>Pocetak:</p>
               <input type="time" onChange="pocetnoVreme(event)" onClick = "staviID()">
               </div>
               <div class="vreme vreme2">
               <p>Kraj:</p>
               <input type="time"  onChange="krajnjeVreme(event)">
               </div>
            </div>
         </div>
         <div class="image__block--txt">
         </div>
     </div>
         `
        }
        ispisK.innerHTML = txt;
    }
}

ispisiKartice();
var pocvreme = '';


function pocetnoVreme(event) {
    if (y % 2 != 0) {
        document.getElementById("TextBox" + y.toString()).value = event.target.value;
        y++;
    } 
}

function krajnjeVreme(event) {
    if (y % 2 == 0) {
        document.getElementById("TextBox" + y.toString()).value = event.target.value;
        y++;
    }  
}



function staviID() {
    brojac++;
    document.getElementById("TextBoxT" + ((1 + brojac).toString())).value = nizid[brojac];
}
