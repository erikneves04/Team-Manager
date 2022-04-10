using Microsoft.EntityFrameworkCore;
using Team_Manager.Domain.Models;

namespace Team_Manager.Data
{
    public class TeamManagerContext : DbContext
    {
        public TeamManagerContext(DbContextOptions<TeamManagerContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
