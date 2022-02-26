using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_manager2.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public int Equipe_id { get; set; }

        public Funcionario(int id, string nome, string cargo, int equipe_id, string email = null)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cargo = cargo;
            this.Equipe_id = equipe_id;
            this.Email = email;
        }
    }
}