using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using team_manager2.Data;
using team_manager2.Models;
using Microsoft.EntityFrameworkCore;

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
                Equipe aux = new Equipe(nome, setor);
                equipes.Add(aux);
                /*if(FuncionarioContexto.Contexto == null)
                {
                    equipes.Add(new Equipe("01", "01"));
                }else if (FuncionarioContexto.Contexto.Equipes == null)
                {
                    equipes.Add(new Equipe("02", "02"));
                }*/
                //FuncionarioContexto.Contexto.Equipes.Add(aux);

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
