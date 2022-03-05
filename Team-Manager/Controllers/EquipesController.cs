using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Manager.Data;
using Team_Manager.Models;

namespace Team_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly TeamManagerContext _context;

        public EquipesController()
        {
            _context = new TeamManagerContext();
        }

        // GET: api/Equipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipe>>> GetEquipes()
        {
            return await _context.Equipes.ToListAsync();
        }

        // GET: api/Equipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return equipe;
        }

        // PUT: api/Equipes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipe(int id, Equipe equipe)
        {
            if (id != equipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExists(id))
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

        // POST: api/Equipes
        [HttpPost]
        public async Task<ActionResult<Equipe>> PostEquipe(string nome, string setor)
        {
            if(!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(setor))
            {
                Equipe equipe = new Equipe(nome, setor);

                _context.Equipes.Add(equipe);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEquipe", new { id = equipe.Id }, equipe);
            }
            else
            {
                return BadRequest("Insira os parâmetros corretamente...nome e setor");
            }
            
        }

        // DELETE: api/Equipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipe(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipeExists(int id)
        {
            return _context.Equipes.Any(e => e.Id == id);
        }
    }
}
