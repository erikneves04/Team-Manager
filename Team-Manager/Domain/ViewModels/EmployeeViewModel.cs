using Team_Manager.Domain.Models;

namespace Team_Manager.Domain.ViewModels;

public abstract class EmployeeBaseViewModel
{
    public string Name { get; set; }
    public string Function { get; set; }
    public string Email { get; set; }
    public Guid TeamId { get; set; }
}

public class EmployeeViewModel : EmployeeBaseViewModel
{
    public EmployeeViewModel() { }
    public EmployeeViewModel(Guid id, string name, string function, string email, TeamViewModel team)
    {
        Id = id;
        Name = name;
        Function = function;
        Email = email;
        
        if(team != null)
        {
            TeamId = team.Id;
            Team = team;
        }
    }

    public EmployeeViewModel(Employee employee)
    {
        Id = employee.Id;
        Name = employee.Name;
        Function = employee.Function;
        Email = employee.Email;

        if (employee.Team != null)
        {
            TeamId = employee.Team.Id;
            Team = new TeamViewModel(employee.Team);
        }
    }

    public Guid Id { get; set; }
    public TeamViewModel Team { get; set; }
}

public class EmployeeInsertUpdateViewModel : EmployeeBaseViewModel
{
    public EmployeeInsertUpdateViewModel() { }
    public EmployeeInsertUpdateViewModel(string name, string function, string email, Guid teamId)
    {
        Name = name;
        Function = function;
        Email = email;
        TeamId = teamId;
    }
}
