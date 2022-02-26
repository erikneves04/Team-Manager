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
        public string Setor { get; set; }

        public List<int> FuncionariosId = new List<int>();

        public Equipe(string nome, string setor)
        {
            this.Nome = nome;
            this.Setor = setor;
        }

        public Equipe(string nome, string setor, int[] idFuncionarios)
        {
            this.Nome = nome;
            this.Setor = setor;
            foreach (int item in idFuncionarios) this.FuncionariosId.Add(item);
        }
    }
}