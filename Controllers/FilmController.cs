/*using System;
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
    public class FilmController : ControllerBase
    {
        public FilmskiFestivaliContext Context { get; set; }

        public FilmController(FilmskiFestivaliContext context)
        {
            Context = context;
        }

       
        [HttpGet("PreuzmiFilm/{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await Context.Filmovi.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }
       
        /*[HttpPut("Izmeni/{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.ID)
            {
                return BadRequest();
            }

            Context.Entry(film).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        [EnableCors("CORS")]
        [Route("DodajFilm/{Naziv}/{Reditelj}/{Vreme}/{Trajanje}/{Dan}")]
        public async Task<ActionResult> DodajFilm(string Naziv, string Reditelj, DateTime Vreme, int Trajanje, string Dan)
        {
            if (string.IsNullOrWhiteSpace(Naziv) || Naziv.Length > 50)
                return BadRequest($"Parametar 'Ime filma' : {Naziv} nije moguc!");

            if (string.IsNullOrWhiteSpace(Reditelj) || Reditelj.Length > 50)
                return BadRequest($"Parametar 'Ime reditelja' : {Reditelj} nije moguc!");

           
            try
            {
                 var dan = await Context.DnevniRepertoari
                    .Where(d => d.Dan == Dan)
                    .FirstOrDefaultAsync();
                if (dan == null)
                {
                    return BadRequest();
                }

               /* Film f = new Film();
                f.NazivFilma = Naziv;
                f.ImeReditelja = Reditelj;
                f.Vreme = Vreme;
                f.Trajanje=Trajanje;
                f.Dan=dan;
                Context.Filmovi.Add(f);
                await Context.SaveChangesAsync();

                var f = new Film
                {
                    NazivFilma = Naziv,
                    ImeReditelja = Reditelj,
                    Vreme = Vreme,
                    Trajanje=Trajanje,
                    Dan=dan

                };
                Context.Filmovi.Add(f);
                await Context.SaveChangesAsync();

                return Ok($"Uspesno dodat film {Naziv}");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

         [HttpDelete("ObrisiFilm/{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await Context.Filmovi.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            Context.Filmovi.Remove(film);
            await Context.SaveChangesAsync();
            return NoContent();

        }
        private bool FilmExists(int id)
        {
            return Context.Filmovi.Any(e => e.ID == id);
        }
    }
}*/
    
