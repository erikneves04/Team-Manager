using Team_Manager.Domain.Models;

namespace Team_Manager.Domain.ViewModels;

public abstract class TeamBaseViewModel
{
    public string Name;
    public string Sector;
    public string Description;
}

public class TeamViewModel : TeamBaseViewModel
{
    public TeamViewModel() { }
    public TeamViewModel(Guid id, string name, string sector, string description, ICollection<Employee> employees = null)
    {
        Id = id;
        Name = name;
        Sector = sector;
        Description = description;
        Employees = employees;
    }

    public Guid Id { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

public class TeamInsertUpdateViewModel : TeamBaseViewModel
{
    public TeamInsertUpdateViewModel() { }
    public TeamInsertUpdateViewModel(string name, string sector, string description)
    {
        Name = name;
        Sector = sector;
        Description = description;
    }
}
