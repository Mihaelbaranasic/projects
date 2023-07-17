document.addEventListener("DOMContentLoaded", function (event) {
    if(document.location.href.endsWith("rezervacija") || document.location.href.endsWith("kontakt") || document.location.href.endsWith("dokumentacija") || document.location.href.endsWith("ponuda1") || document.location.href.endsWith("ponuda2") || document.location.href.endsWith("ponuda3") || document.location.href.endsWith("autor")){
        
    }else{
        tablica();
        rotateLogo();
        animacija1();
        scroll();
    }   
    if(document.location.href.endsWith("rezervacija")){
        rezervacije();
    }
    else if(document.location.href.endsWith("kontakt")){
        kontakt();
    }
    
});

function tablica(){
    var redci = document.querySelectorAll('tr');
    var info = document.getElementById('info');
    console.log(info);

    console.log(redci[0].innerHTML);
    
    for(let i = 0; i<redci.length; i++){
        let isPrinted = false;
        redci[i].addEventListener('mouseover', function(event){
            if (!isPrinted) {
                info.innerHTML += redci[i].innerHTML + "<br><hr>";
                isPrinted = true;
            }
        });
    }
}

function rezervacije(){

    const re = RegExp("^[^!?\#<>\\s]+$");

    const reMail = RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");

    const reOIB = RegExp("^[0-9]{11}$");

    var ime = document.getElementById('ime');
    var prezime = document.getElementById('prezime');
    var oib = document.getElementById('oib');
    var mail = document.getElementById('posta');
    var akcija = document.querySelectorAll('input[type="radio"]');
    var ponude = document.querySelectorAll('input[type="checkbox"]');
    var checked = false;

    var greske = document.getElementById('greske');

    var tipka = document.querySelector('button[value="salji"]');

    var provjera = false;

    tipka.addEventListener('click', function(event){
        var dolazak = new Date(document.getElementById('datum1').value);
        var odlazak = new Date(document.getElementById('datum2').value);
        var danas = new Date();
        var vrijeme = document.getElementById('vrijeme');
        //console.log(vrijeme.value);
        if(provjera == true){
            alert("Molimo ispravite pogreške prije slanja obrasca!");
            event.preventDefault();
        }else{
            checked = false;
            if(re.test(ime.value)){
                ime.style = "border: solid 1px #000"
            }else{
                greske.innerHTML += "<p>Krivo uneseno ime!</p>"
                ime.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(re.test(prezime.value)){
                prezime.style = "border: solid 1px #000"
            }else{
                greske.innerHTML += "<p>Krivo uneseno prezime!</p>"
                prezime.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(reOIB.test(oib.value)){
                oib.style = "border: solid 1px #000"
            }else{
                greske.innerHTML += "<p>Krivo uneseni OIB!</p>"
                oib.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(reMail.test(mail.value)){
                mail.style = "border: solid 1px #000"
            }else{
                greske.innerHTML += "<p>Krivo unesena e-mail adresa!</p>"
                mail.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if (!Array.prototype.some.call(akcija, input => input.checked)) {
                greske.innerHTML += "<p>Morate odabrati jednu akcijsku ponudu! (radio input)</p>"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            for (var i = 0; i < ponude.length; i++) {
                if (ponude[i].checked) {
                    checked = true;
                    break;
                }
            }
            if (!checked){
                greske.innerHTML += "<p>Morate odabrati jednu ponudu iz cjenika! (checkbox)</p>"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if (isNaN(dolazak) || isNaN(odlazak)){
                greske.innerHTML += "<p>Molim odaberite datum!</p>"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if (dolazak.toJSON().slice(0, 10) < danas.toJSON().slice(0, 10) || odlazak.toJSON().slice(0, 10) < danas.toJSON().slice(0, 10)) {
                greske.innerHTML += "<p>Datum ne smije biti u prošlosti!</p>"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(odlazak < dolazak){
                greske.innerHTML += "<p>Datum iseljenja ne može biti prije datuma dolaska!</p>"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(dolazak.toJSON().slice(0, 10) == danas.toJSON().slice(0, 10)){
                
                hr = danas.getHours();
                min = danas.getMinutes();
                console.log(vrijeme.value);
                if(vrijeme.value <= hr+":"+min){
                    greske.innerHTML += "<p>Vrijeme dolaska ne može biti u prošlosti!</p>"
                    greske.style.display = 'block';
                    provjera = true;
                    event.preventDefault();
                }
            }
        }
    });

    greske.addEventListener('click', (event)=>{
        greske.style.display = 'none';
        provjera = false;
        greske.innerHTML = "";
    });
}

function kontakt(){
    const re = RegExp("^[^!?\#<>\\s]+$");
    const re2 = RegExp("^[^!?\#<>]+$");

    var predmet = document.getElementById('pred');
    var vrsta = document.querySelectorAll('input[type="radio"]');
    var poruka = document.getElementById('poruka');
    var tipka = document.querySelector('button[value="salji"]');

    var provjera = false;

    poruka.setAttribute('maxlength', '1000');

    tipka.addEventListener('click', (event)=>{
        if(provjera == true){
            alert("Molimo ispravite pogreške prije slanja obrasca!");
            event.preventDefault();
        }else{
            if(re.test(predmet.value)){
                predmet.style = "border: solid 1px #000"
            }else{
                greske.innerHTML += "<p>Krivo unesen predmet!</p>"
                predmet.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if (!Array.prototype.some.call(vrsta, input => input.checked)) {
                greske.innerHTML += "<p>Morate odabrati vrstu upita!</p>"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(re2.test(poruka.value)){
                poruka.style = "border: solid 1px #000";
            }else{
                greske.innerHTML += "<p>U poruci su nedopušteni znakovi!</p>"
                poruka.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }
            if(poruka.value.length < 10){
                greske.innerHTML += "<p>Poruka mora imati minimalno 10 znakova!</p>"
                poruka.style = "border-color: red;"
                greske.style.display = 'block';
                provjera = true;
                event.preventDefault();
            }else{
                poruka.style = "border: solid 1px #000";
            }
            if(poruka.value.length > 1000){
                
            }
        }
        greske.addEventListener('click', (event)=>{
            greske.style.display = 'none';
            provjera = false;
            greske.innerHTML = "";
        });
    });
}

    var logo = document.getElementById("logo");
    var rotation = 0;
    var timout;
function rotateLogo() {
      rotation += 5;
      logo.style.transform = "rotate(" + rotation + "deg)";
      logo.addEventListener("mouseover", ()=>{
        clearTimeout(timeout);
      });
      timeout=setTimeout(rotateLogo, 10);
}

function animacija1(){
    const text = document.querySelector('h1');
    const strText = text.textContent;
    const splitText = strText.split("");
    text.textContent ="";

    for(let i=0; i<splitText.length;i++){
        text.innerHTML += "<span>"+ splitText[i] + "</span>";
    }

    let char =0;
    let timer = setInterval(onTick, 50);
    function onTick(){
        const span = text.querySelectorAll('span')[char];
        span.classList.add('fade');
        char++;
        if(char === splitText.length){
            complete();
            return;
        }
    }
    function complete(){
        clearInterval(timer);
        timer = null;
    }
}

function scroll(){
    const observer = new IntersectionObserver((entries)=>{
        entries.forEach((entry)=>{
            if(entry.isIntersecting){
                entry.target.classList.add('show');
            }else{
                entry.target.classList.remove('show');
            }
        });
    });
    const hidden = document.querySelectorAll('.hidden');
    hidden.forEach((el)=> observer.observe(el));
}