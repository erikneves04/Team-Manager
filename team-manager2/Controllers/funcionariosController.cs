using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using team_manager2.Data;
using team_manager2.Models;

namespace team_manager2.Controllers
{
    public class FuncionariosController : ApiController
    {
        /* Conexão com o DataBase */
        public static FuncionarioContexto _context;

        public FuncionariosController()
        {
            _context = EquipeController._context;
        }

        /// <summary>
        /// Responsável por retornar uma lista com os funcionários presentes no DataBase.
        /// </summary>
        public List<Funcionario> Get()
        {
            return _context.Funcionarios.ToList();
        }

        /// <summary>
        /// Responsável por receber a requisição e inserir um novo funcionário no DataBase.
        /// </summary>
        public string Post(string nome, string cargo, int equipe_id = -1, string email = null)
        {
            // Validação dos dados
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(cargo) && !(equipe_id == -1))
            {
                // Exigência da inclusão de email para gerente
                if (cargo.ToLower().Equals("gerente") && string.IsNullOrEmpty(email)) return "O cargo de gerente exige a inserção de um email.";
                
                _context.Funcionarios.Add(new Funcionario(nome, cargo, equipe_id,this.GetById(equipe_id), email));
                _context.SaveChanges();
            }
            else
            {
                return "Essa requisição exige o envio completos(nome,cargo,identificador da equipe) dos dados desse desse funcionário!";
            }
            return "Funcionário cadastrado com sucesso!";
        }

        /// <summary>
        /// Responsável por buscar e retornar uma equipe com base em seu identificador.
        /// Retorna null caso o alvo não seja encontrado.
        /// </summary>
        private Equipe GetById(int id)
        {
            foreach(Equipe item in _context.Equipes.ToList()) if(item.Id == id) return item;
            return null;
        }
    }
}
