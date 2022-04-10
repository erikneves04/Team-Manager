namespace Team_Manager.Domain.Models;

public class Team : BaseModel
{
    public Team(string name, string sector, string description)
    {
        Name = name;
        Sector = sector;
        Description = description;
    }

    public string Name { get; set; }
    public string Sector { get; set; }
    public string Description { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
