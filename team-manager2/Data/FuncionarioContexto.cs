using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using team_manager2.Models;

namespace team_manager2.Data
{
    public class FuncionarioContexto : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LocomotivaAppTest;Data Source=ERIK");
        }

    }
}