using Microsoft.EntityFrameworkCore;
using Team_Manager.Models;

namespace Team_Manager.Data
{
    public class TeamManagerContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TeamManager;Data Source=ERIK");
        }

    }
}
