using Microsoft.EntityFrameworkCore;
using Team_Manager.Domain.Models;

namespace Team_Manager.Data
{
    public class TeamManagerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TeamManager;Data Source=ERIK");
        }

    }
}
