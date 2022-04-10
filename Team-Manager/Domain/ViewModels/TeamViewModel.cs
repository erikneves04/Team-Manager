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
    public TeamViewModel(Guid id, string name, string sector, string description, ICollection<EmployeeInsertUpdateViewModel> employees = null)
    {
        Id = id;
        Name = name;
        Sector = sector;
        Description = description;
        Employees = employees;
    }

    public TeamViewModel(Team team)
    {
        Id = team.Id;
        Name = team.Name;
        Sector = team.Sector;
        Description = team.Description;
        Employees = team.Employees?.Select(e => new EmployeeInsertUpdateViewModel(e.Name,e.Function,e.Email,e.TeamId))?.ToList();
    }

    public Guid Id { get; set; }
    public ICollection<EmployeeInsertUpdateViewModel> Employees { get; set; }
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
