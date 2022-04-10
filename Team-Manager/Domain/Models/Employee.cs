namespace Team_Manager.Domain.Models;

public class Employee : BaseModel
{
    public Employee() { }

    public Employee(string name, string function, Guid teamId, string email = null)
    {
        Name = name;
        Function = function;
        Email = email;
        TeamId = teamId;
    }

    public string Name { get; set; }
    public string Function { get; set; }
    public string Email { get; set; }
    public Guid TeamId { get; set; }
    public Team Team { get; set; }
}
