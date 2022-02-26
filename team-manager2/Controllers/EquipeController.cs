using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_manager2.Models;

namespace team_manager2.Controllers
{
    public class EquipeController : ApiController
    {

        private static List<Equipe> equipes = new List<Equipe>();

        public List<Equipe> Get()
        {
            return equipes;
        }

        public void Post(string nome, string setor, int[] idFuncionarios = null)
        {
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(setor))
            {
                if(idFuncionarios == null)
                {
                    equipes.Add(new Equipe(nome, setor));
                }
                else
                {
                    equipes.Add(new Equipe(nome, setor, idFuncionarios));
                }
                
            }
        }

        public void Delete(string nome)
        {
            foreach (Equipe item in equipes)
            {
                if (item.Nome.Equals(nome))
                {
                    equipes.Remove(item);
                    break;
                }
            }
        }

    }
}
