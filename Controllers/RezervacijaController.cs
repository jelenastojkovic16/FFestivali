 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RezervacijaController : ControllerBase
    {
        public FilmskiFestivaliContext Context { get; set; }

        public RezervacijaController(FilmskiFestivaliContext context)
        {
            Context = context;
        }
 
        [Route("Rezervisi/{Ime}/{Prezime}/{email}/{ukupnaCena}")]
        [HttpPost]
        public async Task<ActionResult> Rezervisi(int kartaID,string Ime,string Prezime,string email,int ukupnaCena){
            if(kartaID<0 || string.IsNullOrWhiteSpace(Ime) || string.IsNullOrWhiteSpace(Prezime)|| string.IsNullOrWhiteSpace(email)  || ukupnaCena<=0)
                {
                       return BadRequest("Nije validno");
                }
            try{
                
                 Rezervacija rez = new Rezervacija();
                 rez.Ime = Ime;
                 rez.Prezime = Prezime;
                 rez.Email=email;
                 rez.UkupnaCena=ukupnaCena;
            

//rez.Karte = Context.Karte.Find(kartaID);
                Context.Rezervacije.Add(rez);
                await Context.SaveChangesAsync();
                return Ok("Uspesna rezervacija!");
            }
            catch(Exception e)
            {
             return BadRequest(e.Message);
           }
            
        }

        [Route("PrikaziRezervaciju/{email}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziRezervaciju(string email){
            if(string.IsNullOrWhiteSpace(email))
               {
                      return BadRequest("Nije validno");
               }
           try{

               var rezervacija=await Context.Rezervacije
               .Where(p=>p.Email==email)
               .Include(p=>p.Karte)
               .Select( p=> new{
                   p.ID,
                   p.Ime,
                   p.Prezime,
                p.Email,
                   p.UkupnaCena
               }).FirstOrDefaultAsync();
            
              return Ok(rezervacija);
           }
           catch(Exception e)
           {
             return BadRequest(e.Message);
           }
        }

                   
        [Route("PromeniRezervaciju/{ID}/{ime}/{prezime}/{email}/{ukupnacena}")]
        [HttpPut]
       public async Task<ActionResult> Promeni(int ID,string email,string ime,string prezime,int ukupnacena)
        {
            if(ID < 0)
                return BadRequest("Nevalidan ID !");
            var data =await Context.Rezervacije.FindAsync(ID);
            if(data == null)
                return NotFound("Ne postoji podatak sa ovim ID-jem");
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) || ukupnacena<=0)
                {
                    return BadRequest("Nevalidni podaci!");
                }


            try
            {
            data.Email = email;
            data.Ime=ime;
            data.Prezime=prezime;
            data.UkupnaCena=ukupnacena;
            await Context.SaveChangesAsync();
            return Ok("Uspesno azurirani podaci !");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("UkloniRezervaciju/{Id}")]
        [HttpDelete]      

        public async Task<ActionResult> UkloniRezervaciju(int Id)
                {

                    if (Id<0)
                    {
                        return BadRequest("Nevalidan ID! ");
                    }
                var data = Context.Rezervacije.Where(p => p.ID == Id).FirstOrDefault();
                if(data!=null){
                    Context.Rezervacije.Remove(data);
                    await Context.SaveChangesAsync();
                    return Ok("Rezervacija je obrisana !");
                }
                else
                {
                    return NotFound("Ne postoji rezervacija sa unetim podacima !");
                }
            }

            
    }

}
 