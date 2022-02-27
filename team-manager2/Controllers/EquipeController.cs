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

        public void Post(string nome, string setor)
        {
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(setor))
            {     
                equipes.Add(new Equipe(nome, setor));
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

        public static Equipe GetById(int id)
        {
            foreach (Equipe item in equipes)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
