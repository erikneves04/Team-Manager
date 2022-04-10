namespace Team_Manager.Domain.Models;

public class Team : BaseModel
{
    public string Name { get; set; }
    public string Sector { get; set; }
    public ICollection<Employee> Employees { get; set; }

    public Team(string name, string sector)
    {
        Name = name;
        Sector = sector;
    }
}
