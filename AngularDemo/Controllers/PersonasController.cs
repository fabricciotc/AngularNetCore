using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AngularDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/personas")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PersonasController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return  await _context.Personas.ToListAsync();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id, bool incluiDirecciones=false)
        {
            Persona persona;
            if (incluiDirecciones)
            {
                persona = await _context.Personas.Include(x=>x.Direcciones).Where(x=>x.ID==id).FirstOrDefaultAsync();
            }
            else
            {
                persona = await _context.Personas.FindAsync(id);
            }
            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }


        private async Task CrearOEditarDirecciones(List<Direccione> direcciones)
        {
            List<Direccione> direccionesACrear = direcciones.Where(x => x.id == 0).ToList();
            List<Direccione> direccionesAEditar = direcciones.Where(x => x.id != 0).ToList();

            if (direccionesACrear.Any())
            {
                await _context.AddRangeAsync(direccionesACrear);
            }

            if (direccionesAEditar.Any())
            {
                _context.UpdateRange(direccionesAEditar);
            }

        }


        // PUT: api/Personas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona([FromRoute]int id,[FromBody] Persona persona)
        {
            if (id != persona.ID)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await CrearOEditarDirecciones(persona.Direcciones);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.ID }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persona>> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.ID == id);
        }
    }
}
