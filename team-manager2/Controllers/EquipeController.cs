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

        //private static List<Equipe> equipes = new List<Equipe>();
        public static FuncionarioContexto _context = new FuncionarioContexto();

        public List<Equipe> Get()
        {
            return _context.Equipes.ToList();
        }

        public void Post(string nome, string setor)
        {
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(setor))
            {
                _context.Equipes.Add(new Equipe(nome, setor));
                _context.SaveChanges();
            }
        }
    }
}
