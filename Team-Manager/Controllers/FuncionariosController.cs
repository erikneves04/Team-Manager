using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Manager.Models;
using Team_Manager.Data;

namespace Team_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly TeamManagerContext _context;

        public FuncionariosController()
        {
            _context = new TeamManagerContext();
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(string nome,string cargo,int Id_da_equipe, string email=null)
        {
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(cargo))
            {
                if (cargo.ToLower().Equals("gerente") && !string.IsNullOrEmpty(email)) return BadRequest("O cargo de gerente exige a inclusão de um email!");
                
                Funcionario funcionario = new Funcionario(nome, cargo, Id_da_equipe, _context.Equipes.FindAsync(Id_da_equipe).Result, email);
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFuncionario", new { id = funcionario.Id }, funcionario);
            }
            else
            {
                return BadRequest("Insira os parâmetros corretamente...nome,cargo,Id_da_equipe e email");
            }
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
