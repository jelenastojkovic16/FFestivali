import { Festival } from "./Festival.js";
import { DnevniRepertoar } from "./DnevniRepertoar.js";


var listaFestivala=[];
var listaRepertoara=[];
function ucitajFestivale()
{
    fetch("https://localhost:5001/Festival/Festivali")
    .then(p=>{
                   p.json().then(festivali=>{

                  festivali.forEach(p=>
                    {
                        var f =new Festival(p.id, p.nazivFestivala, p.grad, p.adresa, p.pocetak, p.kraj, p.opis);
                        listaFestivala.push(f);
                     

                    });
                    
                    pocetna(document.body);
                    
                })
        })
    
}
console.log(listaFestivala);

ucitajFestivale();


function ucitajDnevneRepertoare(naziv) {
    fetch("https://localhost:5001/DnevniRepertoar/PreuzmiRepertoare/" + naziv)
    .then(p=>{
        listaRepertoara.length=0;
            p.json().then(repertoari=>{
                repertoari.forEach(x => {
                    let repertoar = new DnevniRepertoar(x.id, x.cena, x.dan, x.datum, x.filmovi);
                    listaRepertoara.push(repertoar);
                    console.log(repertoar.filmovi);
                })
                //prikaziRepertoare(naziv);

                let divZaPrikazFestivala=document.querySelector(".divZaPrikazFestivala");
                obrisiFormu(divZaPrikazFestivala);
                //console.log(document.querySelector(".lNaslov"));
                let naslov = document.createElement("label");
                naslov.innerHTML = naziv;
                naslov.value=naziv;


                let divZaSveDane = document.createElement("div");
                divZaSveDane.className = "divZaSveDane";
            // fdiv.appendChild(divZaPrikazFestivala);
                divZaPrikazFestivala.appendChild(divZaSveDane);

                

                let i = 0;

                

                let divFormular=document.createElement("div");
                divFormular.className="divFormular";
                divZaPrikazFestivala.appendChild(divFormular);

                console.log(listaRepertoara);
                listaRepertoara.forEach(x => {
                    console.log(listaRepertoara);
                    let divZaDan = document.createElement("div");
                    divZaDan.className = "divZaDan";

                
                    divZaSveDane.appendChild(divZaDan);
                    let tabela = document.createElement("table");
                    tabela.className = "tabela";
                    //i++;
                    let lblDan = document.createElement("label");
                    lblDan.innerHTML = x.dan;
                    lblDan.className="dan"+i;
                    divZaDan.appendChild(lblDan);
                    divZaDan.appendChild(tabela);
    
                    let thead = document.createElement("thead");
                    tabela.appendChild(thead);
                
                    let tr = document.createElement("tr");
                    tr.className = "row";
                    thead.appendChild(tr);
                
                    let tbody = document.createElement("tbody");
                    tbody.className = "tbody" + i;
                    tabela.appendChild(tbody);
                    let th;
                    let nizZaglavlja = ["Ime filma", "Reditelj", "Datum i vreme", "Trajanje"];
                    nizZaglavlja.forEach(el => {
                        th = document.createElement("th");
                        th.innerHTML = el;
                        tr.appendChild(th);
                    })
                    console.log(x.filmovi);


                    x.filmovi.forEach(y => {
                        let teloTabele = document.querySelector(".tbody" + i);

                        let tr = document.createElement("tr");
                        tr.className = "red";
                        teloTabele.appendChild(tr);

                        tr.id = y.id;

                    let imeFilma = document.createElement("td");
                    imeFilma.innerHTML = y.nazivFilma;
                    tr.appendChild(imeFilma);

                    let reditelj=document.createElement("td");
                    reditelj.innerHTML=y.imeReditelja;
                    tr.appendChild(reditelj);

                    let vreme = document.createElement("td");
                    vreme.innerHTML = y.vreme.split("T");
                    tr.appendChild(vreme);

                    let trajanje = document.createElement("td");
                    trajanje.innerHTML = y.trajanje;
                    tr.appendChild(trajanje);
                    console.log(y);
                })
                
                console.log(x);
                let divKarte=document.createElement("div");
                divKarte.className="divKarte"+i;
                divZaDan.appendChild(divKarte);

                let lblBr=document.createElement("label");
                lblBr.innerHTML = "Broj karata: ";
                divKarte.appendChild(lblBr);

                let brKarata=document.createElement("input");
                brKarata.className="brKarata"+i;
                brKarata.type="number";
    
                brKarata.value="1";
                brKarata.addEventListener("change", ()=>
                {
                    if(brKarata.value<1) {alert("Nece moci");
                    brKarata.value = "1";}
                    else if (brKarata.value>5)
                    {
                        alert("Premasen maksimalan broj karata! ");
                        brKarata.value="5";
                    }
                })
 
                divKarte.appendChild(brKarata);


                let divh=document.createElement("div");
                divh.className="divZaCheckBox"+i;
                divZaDan.appendChild(divh);
                
                let lblCena = document.createElement("label");
                lblCena.innerHTML = "Cena za dan: "+ x.cena;
                divh.appendChild(lblCena);
                let boxZaRez = document.createElement("input");
            // boxZaRez.innerHTML="izaberi";
                boxZaRez.type = "checkbox";
                boxZaRez.className=i;
                boxZaRez.value = x.cena;

                

                divh.appendChild(boxZaRez);
                i++;
            })

            let divDgm=document.createElement("div");
            divZaSveDane.appendChild(divDgm);

            let dugmeNastavi = document.createElement("button");
            dugmeNastavi.className="dugmeNastavi";
            dugmeNastavi.onclick = (ev) => prikaziFormular();


            let dugmeCena = document.createElement("button");
            dugmeCena.innerHTML = "Prikazi cenu";
            dugmeCena.className="dugmeCena";
            divDgm.appendChild(dugmeCena);
            dugmeCena.onclick=(ev)=>odrediCenu();

            let dugmeKomplet = document.createElement("button");
            dugmeKomplet.innerHTML = "Komplet";
            dugmeKomplet.className="dugmeKomplet";
            dugmeKomplet.disabled=true;
            divDgm.appendChild(dugmeKomplet);
            let lblBrKomp=document.createElement("label");
            lblBrKomp.innerHTML="Izaberite broj kompleta";
            divDgm.appendChild(lblBrKomp);
            let brKomp=document.createElement("input");
            brKomp.type="number";
            brKomp.className="brKomp";
            divDgm.appendChild(brKomp);
            const input = document.querySelector('input');
            brKomp.addEventListener('input', updateValue);
            brKomp.addEventListener("change", ()=>
            {
                if(brKomp.value>0)
                {
                    dugmeCena.disabled=true;
                    dugmeKomplet.disabled=false;
                }
                else
                {
                    dugmeCena.disabled=false;
                }
                if(brKomp.value==0) {
                dugmeKomplet.disabled=true;
                }

                if(brKomp.value<0)
                {
                    alert("Ne moze!");
                }
                else if (brKomp.value>5)
                {
                    alert("Premasen maksimalan broj kompleta! ");
                    brKomp.value="5";
                    
                }
            })

            function updateValue()
            {
                let dani=document.querySelectorAll('input[type="checkbox"]');
                let num=".brKarata";
                let br=document.querySelector(".brKomp");
                dani.forEach(p=>
                    {
                        if(br.value>0 && br.value<6)
                        p.checked=true;
                        else
                        {
                        p.checked=false;
                        br.value=0;
                        }
                        
                        document.querySelector(num+p.className).value=brKomp.value;
                    })
            }


            dugmeKomplet.onclick=(ev)=>CenaZaKomplet();
           

            let divC=document.createElement("div");
            divC.className="divC";
            divDgm.appendChild(divC);

            dugmeNastavi.innerHTML = "Nastavi";
            dugmeNastavi.className="nast";
            divDgm.appendChild(dugmeNastavi);
            dugmeNastavi.disabled=true;
            

            let formular = document.createElement("div");
            formular.className = "formular";
                
            divFormular.appendChild(formular);
        })
               
    })
    function CenaZaKomplet()
    {
        document.querySelector(".nast").disabled=false;
        let odabraniDani=document.querySelectorAll("input[type='checkbox']:checked");
        if (odabraniDani===null)
        {
            alert("Izaberite dan festivala");
            return;   
        }
        console.log(odabraniDani);
        let cena=0;
        let  divC=document.querySelector(".divC");

        obrisiFormu(divC);

        let select = ".brKarata";
        let s;
        for (let i=0; i<odabraniDani.length;i++)
        {
            s=document.querySelector(select+odabraniDani[i].className);
            cena=cena+(parseInt(odabraniDani[i].value)*parseInt(s.value));
        }
            


            console.log(cena);
            let lCena=document.createElement("label");
            lCena.className="lCena";
            lCena.innerHTML=cena*0.75;
            divC.appendChild(lCena);
              
    }
    function odrediCenu()
    {
        //document.querySelector(".nast").disabled=false;
        let odabraniDani=document.querySelectorAll("input[type='checkbox']:checked");
        if (odabraniDani===null)
        {
            alert("Izaberite dan festivala");
            return;   
        }
        console.log(odabraniDani);
        let cena=0;
        let  divC=document.querySelector(".divC");

        obrisiFormu(divC);

        let select = ".brKarata";
        let s;
        for (let i=0; i<odabraniDani.length;i++)
        {
            s=document.querySelector(select+odabraniDani[i].className);
            cena=cena+(parseInt(odabraniDani[i].value)*parseInt(s.value));
        }
            


            console.log(cena);
            let lCena=document.createElement("label");
            lCena.className="lCena";
            lCena.innerHTML=cena;
            divC.appendChild(lCena);

            if (cena!=0)
            document.querySelector(".nast").disabled=false;
            
              
        }
    }


    
    function pocetna(host)
    {   
        let i = 1;
        let dugme;
        let GlavniDiv=document.createElement("div");
        GlavniDiv.className="GlavniDiv";
        document.body.appendChild(GlavniDiv);
        let lNaslov=document.createElement("label");
        lNaslov.className="lNaslov";
        lNaslov.innerHTML="FILMSKI FESTIVALI";
                    
        GlavniDiv.appendChild(lNaslov);
        let divDugmici=document.createElement("div");
        divDugmici.className="divDugmici";
        GlavniDiv.appendChild(divDugmici);

        listaFestivala.forEach(p=>
        {
            dugme=document.createElement("button");
            divDugmici.appendChild(dugme);
            let j=i;
            dugme.innerHTML=p.naziv;
            dugme.value=p.naziv;
            dugme.className="dugmici"+i++;   
            divDugmici.appendChild(dugme);
           dugme.onclick = (ev) => prikaziFestival(p.naziv,j);
        })
        /*console.log(document.querySelector(".lNaslov").value);*/
}


function nazadF()
{
    obrisiFormu(document.body);
    pocetna(document.body)
}

function prikaziFestival(naziv,j) {

    fetch("https://localhost:5001/Festival/Festival/"+naziv)
    .then(p=>{
            p.json().then(q=>{

                var p =new Festival(q.id, q.nazivFestivala, q.grad, q.adresa, q.pocetak, q.kraj, q.opisFestivala);
                obrisiFormu(document.body);
                let Fdiv=document.createElement("div");
                Fdiv.className="Fdiv";
                document.body.appendChild(Fdiv);

                var dNazad=document.createElement("button");
                dNazad.className="dNazad";
                dNazad.innerHTML="Nazad";
                Fdiv.appendChild(dNazad);
                dNazad.onclick=(e)=>nazadF();
                let slika1div=document.createElement("div");
                slika1div.className="slika1div";
                Fdiv.appendChild(slika1div);
                        
                    
                let slika = document.createElement("img");
                slika.className = "images"+j;
                slika.src = "../Images/" + naziv + ".jpg";//slika
                slika.alt = naziv + ".jpg";//ispis
                               
                slika1div.appendChild(slika);
                     
                            
                let div2=document.createElement("div");
                div2.className="divZaOpis"
                let opis=document.createElement("label");
                opis.innerHTML=p.opis;
                Fdiv.appendChild(div2);
                div2.appendChild(opis);
                                
                let info=document.createElement("div");
                info.className="divGrad";
                opis.appendChild(info);

                let lbl1=document.createElement("label");
                lbl1.innerHTML="Mesto održavanja: ";
                lbl1.className="lbl"+j;
                info.append(lbl1);
                    
                let  grad=document.createElement("label");
                grad.innerHTML = /*"Mesto odrzavanja: "+*/  p.grad+"  , "+ p.adresa;
                grad.value = p.grad+p.adresa;
                grad.className="lblgrad"; 
                info.appendChild(grad);

                let lbl2=document.createElement("label");
                lbl2.innerHTML="<br>" +"Održava se: ";
                lbl2.className="lbl"+j;
                info.append(lbl2);
                let datum=document.createElement("label"); 
                datum.innerHTML = /*"<br>" +"Održava se: "*/  p.pocetak + " -  " + p.kraj;
                info.appendChild(datum);


                var dugme=document.createElement("button");
                dugme.className="repertoar";
                dugme.innerHTML="REPERTOAR";
                Fdiv.appendChild(dugme);

                

                

                let fdiv = document.querySelector(".Fdiv");
                let divZaPrikazFestivala = document.createElement("div");
                divZaPrikazFestivala.className = "divZaPrikazFestivala";
                fdiv.appendChild(divZaPrikazFestivala);
                dugme.onclick = (ev) => ucitajDnevneRepertoare(p.naziv);
            })
        })
    }

    
    
    
    
    function prikaziFormular() {
        
        //obrisiFormu(document.querySelector(".divFormular"));
        let ukupnaCena=document.querySelector(".lCena");
    if (ukupnaCena.innerHTML=="0")
    {
        alert("Niste odabrali rezervaciju!")
        
    }
    else{
    let divZaPrikazFestivala = document.querySelector(".divFormular");
    
     let formular = document.querySelector(".formular");
    obrisiFormu(formular);

    divZaPrikazFestivala.appendChild(formular);
    let nizLabela = ["Ime", "Prezime", "Email"];
    let txtBox;
    let lbl;
    nizLabela.forEach(x => {
        lbl = document.createElement("label");
        lbl.innerHTML = x;
        txtBox = document.createElement("input");
        txtBox.type = "text";
        txtBox.className=x;
        formular.appendChild(lbl);
        formular.appendChild(txtBox);
    })

    let rezervisi=document.createElement("button");
    rezervisi.className="rezervisi";
    rezervisi.innerHTML="Rezervisi";
    formular.appendChild(rezervisi);

   // let divZaPrikazFestivala=document.querySelector(".divZaPrikazFestivala");
    let divPrikaziRez=document.createElement("div");
    divPrikaziRez.className="divPrikaziRez";
    divZaPrikazFestivala.appendChild(divPrikaziRez);

    rezervisi.onclick=(ev)=>napraviRezervaciju();
}
}
let rezId;
let chk=[];

function napraviRezervaciju()
{
    let Ime=document.querySelector(".Ime").value;
    let Prezime=document.querySelector(".Prezime").value;
    let email=document.querySelector(".Email").value;
    let ukupnaCena=document.querySelector(".lCena").innerHTML;
    let Email=email;

    if(Ime==null)
    alert("Unesite ime!");
    if(Prezime==null)
    alert("Unesite prezime");

    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if(Email.match(mailformat))
    {
    }
    else
    {
    alert("Format za mail nije dobar");
    }

    fetch("https://localhost:5001/Rezervacija/Rezervisi/" +Ime+"/"+Prezime+"/"+email+"/"+ukupnaCena,{
        method:"POST"
    })
    .then(p=>{
        if(p.ok)
        {
            let divZaPrikazFestivala=document.querySelector(".divFormular");

            //let formular=document.createElement("div");
            let formular=document.querySelector(".divPrikaziRez");
            divZaPrikazFestivala.appendChild(formular);
            obrisiFormu(formular);
            //obrisiFormu(document.querySelector(".formular"));
            

            let lRez=document.createElement("label");
            lRez.className="lRez";
            lRez.innerHTML="PRIKAZ REZERVACIJE";
            formular.appendChild(lRez);
            

           
    
            let nizLabela = ["IME", "PREZIME", "EMAIL","CENA"];
        let txtBox;
        let lbl;
        nizLabela.forEach(x => {
        lbl = document.createElement("label");
        lbl.innerHTML = x;
        txtBox = document.createElement("input");
        txtBox.type = "text";
        txtBox.className=x;
        txtBox.disabled=true;
        formular.appendChild(lbl);
        formular.appendChild(txtBox);
    })
    
    let Potvrdi=document.createElement("button");
    Potvrdi.className="btnPotvrdi";
    Potvrdi.innerHTML="Potvrdi";
    formular.appendChild(Potvrdi);
    Potvrdi.onclick=(e)=>PotvrdiRez();
     
    let btnObrisi=document.createElement("button");
    btnObrisi.className="btnObrisi";
    btnObrisi.innerHTML="Obrisi";
    formular.appendChild(btnObrisi);
    btnObrisi.onclick=(e)=>ObrisiRez();

    let Izmeni=document.createElement("button");
    Izmeni.className="btnIzmeni";
    Izmeni.innerHTML="Izmeni";
    formular.appendChild(Izmeni);
    Izmeni.onclick=(e)=>IzmeniRez();

    console.log(Email);
    console.log(document.querySelector(".IME"));

    fetch("https://localhost:5001/Rezervacija/PrikaziRezervaciju/"+Email).then(p=>{
                p.json().then(p=>{
                    console.log(p);
                    rezId=p.id;
                    document.querySelector(".IME").value=p.ime;
                    document.querySelector(".PREZIME").value=p.prezime;
                    document.querySelector(".EMAIL").value=p.email;
                    document.querySelector(".CENA").value=p.ukupnaCena;
                })
            })
        }
        else{
            alert("Problem pri kreiranju rezervacije");
        }
    })
}


function ObrisiRez()
{
    fetch("https://localhost:5001/Rezervacija/UkloniRezervaciju/"+rezId,
   {
       method:"DELETE"
   }).then(p=>{
        if(p.ok)
        {
            document.querySelector(".IME").value="";
            document.querySelector(".PREZIME").value="";
            document.querySelector(".EMAIL").value="";
            document.querySelector(".CENA").value="";
            alert ("Obrisali ste rezervaciju");
        }
        })
}


function IzmeniRez()
{
    let ukupnaCena=document.querySelector(".lCena").innerHTML;
    document.querySelector(".CENA").value=ukupnaCena;
    let ime=document.querySelector(".IME").value;
    let prezime=document.querySelector(".PREZIME").value;
    let email=document.querySelector(".EMAIL").value;
    fetch("https://localhost:5001/Rezervacija/PromeniRezervaciju/"+rezId+"/"+ime+"/"+prezime+"/"+email+"/"+ukupnaCena,
    {
       method:"PUT"
   }).then(p=>{
        if(p.ok)
        {
            chk=document.querySelectorAll("input[type='checkbox']:checked");
            alert ("Uspesno ste izmenili rezervaciju");
        }
   })
}

function napraviKartu(brojUlaznica, danNaziv, rezervacijaId)
{
    fetch("https://localhost:5001/Karta/DodajKartu/"+brojUlaznica+"/"+danNaziv+"/"+rezervacijaId,
    {
        method:"POST"
    }).then(p=>{
        if(p.ok)
        {
            document.querySelector(".IME").value="";
            document.querySelector(".PREZIME").value="";
            document.querySelector(".EMAIL").value="";
            document.querySelector(".CENA").value="";
        }
        else
        {
            alert("Nemoguce je kreirati kartu");
        }
    })
}

function PotvrdiRez()
{
    chk=document.querySelectorAll("input[type='checkbox']:checked");
    console.log(chk);
    let dani=".dan";
    let select = ".brKarata";
    let brUl;
    let danNaziv;
    chk.forEach(p=>{      
            danNaziv=document.querySelector(dani+p.className).innerHTML;
            brUl=document.querySelector(select+p.className).value;
            napraviKartu(brUl,danNaziv,rezId);
        });
}

function obrisiFormu(host) {
    while(host.firstChild) {
        host.removeChild(host.firstChild);
    }
}


