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
    public class FestivalController : ControllerBase
    {
        public FilmskiFestivaliContext Context { get; set; }

        public FestivalController(FilmskiFestivaliContext context)
        {
            Context = context;
        }

        [Route("Festivali")]
        [HttpGet]
        public async Task<ActionResult> VratiFestivale()
        {
            try
            {
                var festival = await Context.Festivali.ToListAsync();
                return Ok(festival);      
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
         [Route("Festival/{naziv}")]
        [HttpGet]
        public async Task<ActionResult> VratiFestival(string naziv)
        {
         if (string.IsNullOrEmpty(naziv))
            return BadRequest("Neispravan naziv festivala!");
            try {
        var festival = await Context.Festivali.Where(p=>p.NazivFestivala==naziv)
		.Select(p => new {
			p.ID, 
			p.NazivFestivala,
			p.Adresa,
			p.Grad,
			p.OpisFestivala,
			Pocetak = p.Pocetak.ToShortDateString(),
			Kraj = p.Kraj.ToShortDateString()

		}).FirstOrDefaultAsync();
		
        return Ok(festival);
    }   
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
        }

    }
}