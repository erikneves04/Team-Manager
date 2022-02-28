using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_manager2.Data;
using team_manager2.Models;

namespace team_manager2.Controllers
{
    public class FuncionariosController : ApiController
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        public List<Funcionario> Get()
        {
            return funcionarios;
        }

        public void Post(string nome, string cargo, int equipe_id, string email = null)
        {
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(cargo))
            {
                if (cargo.ToLower().Equals("gerente") && string.IsNullOrEmpty(email)) return;

                funcionarios.Add(new Funcionario(nome, cargo, equipe_id,EquipeController.GetById(equipe_id), email));
            }
            
        }

        public void Delete(string nome)
        {
            foreach (Funcionario item in funcionarios)
            {
                if (item.Nome.Equals(nome))
                {
                    funcionarios.Remove(item);
                    break;
                }
            }
        }
    }
}
