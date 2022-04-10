using Microsoft.EntityFrameworkCore;
using Team_Manager.Data;
using Team_Manager.Domain.Interfaces.Services;
using Team_Manager.Domain.Models;
using Team_Manager.Domain.ViewModels;

namespace Team_Manager.Domain.Services;

public class EmployeeServices : IEmployeeServices
{
    private readonly TeamManagerContext _context;
    private readonly ITeamServices _teamServices;

    public EmployeeServices(TeamManagerContext context, ITeamServices teamServices)
    {
        _context = context;
        _teamServices = teamServices;
    }

    public EmployeeViewModel Insert(EmployeeInsertUpdateViewModel model)
    {
        if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Function) || model.TeamId == Guid.Empty)
            throw new InvalidDataException("Os campos Name, Function e TeamId são necessários para cadastrar um funcionário.");

        if (!_teamServices.Exist(model.TeamId))
            throw new InvalidDataException("O identificador da equipe é inválido.");

        var entity = ConvertToEntity(model);

        _context.Employees.Add(entity);
        _context.SaveChanges();

        return ConvertToViewModel(entity);
    }

    public EmployeeViewModel Update(EmployeeInsertUpdateViewModel model, Guid id)
    {
        if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Function) || model.TeamId == Guid.Empty)
            throw new InvalidDataException("Os campos Name, Function e TeamId são necessários para cadastrar um funcionário.");

        if (id == Guid.Empty)
            throw new InvalidDataException("O identificador é inválido.");

        if (!_teamServices.Exist(model.TeamId))
            throw new InvalidDataException("O identificador da equipe é inválido.");

        var entity = Get(id);
        if (entity == null)
            throw new InvalidDataException("Nenhum funcionário com esse identificador foi encontrado.");

        if (id != entity.Id)
            throw new InvalidDataException("Não é possível alterar o identificador de um funcionário.");


        entity.Email = model.Email;
        entity.Name = model.Name;
        entity.Function = model.Function;
        entity.TeamId = model.TeamId;

        _context.Employees.Update(entity);
        _context.SaveChanges();

        return ConvertToViewModel(entity);
    }

    public void Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidDataException("O identificador é inválido.");

        var entity = Get(id);
        if (entity == null)
            throw new InvalidDataException("Nenhum funcionário com esse identificador foi encontrado.");

        _context.Employees.Remove(entity);
        _context.SaveChanges();
    }

    public ICollection<EmployeeViewModel> GetAll()
    {
        return _context.Employees
            .AsNoTracking()
            ?.Include(e => e.Team)
            ?.Select(e => new EmployeeViewModel(e))
            ?.ToList();
    }

    public EmployeeViewModel GetViewModel(Guid id)
    {
        return ConvertToViewModel(Get(id));
    }

    private Employee Get(Guid id)
    {
        return _context.Employees.FirstOrDefault(e => e.Id == id);
    }

    private Employee GetByName(string name)
    {
        return _context.Employees.FirstOrDefault(e => e.Name == name);
    }

    public ICollection<Employee> GetEmployesByTeamId(Guid id)
    {
        return _context.Employees.Where(e => e.TeamId == id).ToList();
    }

    private static Employee ConvertToEntity(EmployeeInsertUpdateViewModel model)
    {
        return new Employee(model.Name, model.Function, model.TeamId, model.Email);
    }

    private static EmployeeViewModel ConvertToViewModel(Employee model)
    {
        return new EmployeeViewModel(model);
    }
}
