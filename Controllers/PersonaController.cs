using capaCensys2.Data;
using capaCensys2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace capaCensys2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PersonaController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var personas = await _context.Personas.ToListAsync();
            return Ok(personas);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x=> x.Id == id );
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Post (Persona persona)
        {
           
                await _context.Personas.AddAsync(persona);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Get", persona.Id, persona); 
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync( x => x.Id == id);

            if (persona == null)
            {
                return BadRequest("no se borro al usuario");
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch( int id, string name)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null)
                return BadRequest("No existe el usuario");

            persona.Name = name;

            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
