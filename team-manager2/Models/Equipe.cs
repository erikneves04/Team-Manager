using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team_manager2.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<int> FuncionariosId = new List<int>();

        public Equipe(string nome)
        {
            this.Nome = nome;
        }

        public Equipe(string nome, int[] idFuncionarios)
        {
            this.Nome = nome;
            foreach (int item in idFuncionarios) this.FuncionariosId.Add(item);
        }
    }
}