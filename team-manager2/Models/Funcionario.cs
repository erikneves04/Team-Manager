using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_manager2.Models
{
    public class Funcionario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
        public string email { get; set; }
        public string equipe_id { get; set; }

        public Funcionario(int Id, string Nome, string Cargo, string Equipe_id, string Email = null)
        {
            this.id = Id;
            this.nome = Nome;
            this.cargo = cargo;
            this.equipe_id = Equipe_id;
            this.email = Email;
        }
    }
}