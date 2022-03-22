using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DnevniRepertoarController : ControllerBase
    {
        public FilmskiFestivaliContext Context { get; set; }

        public DnevniRepertoarController(FilmskiFestivaliContext context)
        {
            Context = context;
        }



        [Route("PreuzmiRepertoare/{naziv}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiRepertoare(string naziv)
        {
            if (string.IsNullOrEmpty(naziv))
            return BadRequest("Neispravan dan repertoara!");
            try{
            
            var repertoari = await Context.DnevniRepertoari
            .Include(p=>p.Filmovi)
            .Where(p=>p.Festival.NazivFestivala==naziv)

            .Select( p=> new
            {
                ID=p.ID,
                 Datum = p.Datum,
                 Dan = p.Dan,
                 Cena = p.Cena,
                 Filmovi=p.Filmovi
             })
             .ToListAsync();
             return Ok(repertoari);
            }
              catch (Exception e)
              {
                return BadRequest(e.Message);
              }
        }




        [Route("PreuzmiCenu/{naziv}/{dan}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiCenu(string naziv,string dan)
        {
            if (string.IsNullOrWhiteSpace(naziv) || string.IsNullOrWhiteSpace(dan))
            return BadRequest("Neispravan unos!");
            try{
            
             var cena = await Context.DnevniRepertoari
             .Where(p=>p.Festival.NazivFestivala==naziv)

             .Select( p=> new {
                 Cena=p.Cena

             }).FirstOrDefaultAsync();
             return Ok(cena);
              }
              catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        }



     }
