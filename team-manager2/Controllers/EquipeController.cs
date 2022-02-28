using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using team_manager2.Data;
using team_manager2.Models;

namespace team_manager2.Controllers
{
    public class EquipeController : ApiController
    {
        public static FuncionarioContexto _context = new FuncionarioContexto();

        public List<Equipe> Get()
        {
            return _context.Equipes.ToList();
        }

        public string Post(string nome, string setor)
        {
            // Validação dos dados
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(setor))
            {
                _context.Equipes.Add(new Equipe(nome, setor));
                _context.SaveChanges();
            }
            else
            {
                return "Essa requisição exige o envio tanto do nome, quanto do setor, dessa equipe!";
            }
            return "Equipe cadastrada com sucesso!";
        }
    }
}
