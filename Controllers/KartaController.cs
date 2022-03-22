using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KartaController : ControllerBase
    {
        public FilmskiFestivaliContext Context { get; set; }
        public KartaController(FilmskiFestivaliContext context)
        {
            Context = context;
        }
        [Route("PreuzmiKartu/{id}")]
        [HttpGet]
        [EnableCors("CORS")]
        public async Task<ActionResult> PreuzmiKartu(int id)
        {
             if(id < 0)
                return BadRequest("Nevalidan ID !");
            try{
             var karte =await Context.Karte
             .Include(p =>p. Dan)
             .ThenInclude(p=>p.Festival)
             .Where(p => p.Dan.Festival.ID==id).ToListAsync();             
            return Ok(karte);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    [Route("Karte")]
    [HttpGet]
    public async Task<ActionResult> VratiKarte()
    {
    try 
        {
            var karte = Context.Karte;
            var karta = await karte.ToListAsync();
            return Ok(karta);
        }   
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [Route("DodajKartu/{brojUlaznica}/{danNaziv}/{rezervacijaId}")]
    [HttpPost]
    public async Task<ActionResult> DodajKartu(int brojUlaznica, string danNaziv, int rezervacijaId)
    {
        if (brojUlaznica>5 || rezervacijaId<0 || string.IsNullOrEmpty(danNaziv))
        {
            return BadRequest("Nevalidni podaci");
            
        }
            try{

                var dan=await Context.DnevniRepertoari.Where(p=>p.Dan==danNaziv).FirstOrDefaultAsync();
                if(dan==null)
                {
                    return BadRequest("Nema dana sa zadatim id-em");
                }

                var rezervacija=await Context.Rezervacije.Where(p=>p.ID==rezervacijaId).FirstOrDefaultAsync();
                if(rezervacija==null)
                {
                    return BadRequest("Nema rezervacije sa zadatim id-em");
                }         
                Karta k=new Karta();
                k.BrojUlaznica=brojUlaznica;
                k.Dan=dan;
                k.Rezervacija=rezervacija;

                Context.Karte.Add(k);
                await Context.SaveChangesAsync();
                 return Ok("Uspesno dodata karta!");

            }

            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

    }  
}
}

    
