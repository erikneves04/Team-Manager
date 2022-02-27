using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using team_manager2.Controllers;

namespace team_manager2.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public Equipe Equipe { get; set; }

        public Funcionario(string nome, string cargo, Equipe equipe, string email = null)
        {
            this.Nome = nome;
            this.Cargo = cargo;
            this.Equipe = equipe;
            this.Email = email;
        }

        public Funcionario(string nome, string cargo, Equipe equipe, string email = null, int id = -1)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cargo = cargo;
            this.Equipe = equipe;
            this.Email = email;
        }
    }
}