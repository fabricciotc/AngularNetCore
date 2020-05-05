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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetPersonas()
        {
            return  await _context.Users.ToListAsync();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetPersona(int id, bool incluiDirecciones=false)
        {
            User persona;
            if (incluiDirecciones)
            {
                persona = await _context.Users.Include(x=>x.address).Where(x=>x.AddressId==id).FirstOrDefaultAsync();
            }
            else
            {
                persona = await _context.Users.FindAsync(id);
            }
            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }


        private async Task CrearOEditarDirecciones(Address direcciones)
        {

            var result = await _context.Addresses.SingleOrDefaultAsync(b => b.AddressId == direcciones.AddressId);
            if (result != null)
            {
                result= direcciones;
                await _context.SaveChangesAsync();
            }

        }


        // PUT: api/Personas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona([FromRoute]string id,[FromBody] User persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await CrearOEditarDirecciones(persona.address);
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
        public async Task<ActionResult<User>> PostPersona(User persona)
        {
            _context.Users.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeletePersona(string id)
        {
            var persona = await _context.Users.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Users.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        private bool PersonaExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
