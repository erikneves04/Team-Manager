using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_manager2.Models;

namespace team_manager2.Controllers
{
    public class funcionariosController : ApiController
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        public List<Funcionario> Get()
        {
            return funcionarios;
        }

        public void Post(int id, string nome, string cargo, int equipe_id, string email = null)
        {
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(cargo))
            {
                if (cargo.ToLower().Equals("gerente") && string.IsNullOrEmpty(email))
                {
                    return;
                }
                funcionarios.Add(new Funcionario(id, nome, cargo, equipe_id, email));
            }
        }

        public void Delete(string nomeAlvo)
        {
            foreach (Funcionario item in funcionarios)
            {
                if (item.Nome.Equals(nomeAlvo))
                {
                    funcionarios.Remove(item);
                    break;
                }
            }
        }
    }
}
