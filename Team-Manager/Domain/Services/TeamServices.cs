using Microsoft.EntityFrameworkCore;
using Team_Manager.Data;
using Team_Manager.Domain.Interfaces.Services;
using Team_Manager.Domain.Models;
using Team_Manager.Domain.ViewModels;

namespace Team_Manager.Domain.Services;

public class TeamServices : ITeamServices
{
    private readonly TeamManagerContext _context;

    public TeamServices(TeamManagerContext context)
    {
        _context = context;
    }

    public TeamViewModel Insert(TeamInsertUpdateViewModel model)
    {
        if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.Sector))
            throw new InvalidDataException("Todos os campos são necessários para cadastrar um time.");

        if(GetByNameAndSector(model.Name,model.Sector) != null)
            throw new InvalidDataException("Já existe um time cadastrado com esse nome & setor.");

        var entity = ConvertToEntity(model);

        _context.Teams.Add(entity);
        _context.SaveChanges();

        return ConvertToViewModel(entity);
    }

    public TeamViewModel Update(TeamInsertUpdateViewModel model, Guid id)
    {
        if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.Sector))
            throw new InvalidDataException("Todos os campos são necessários para atualizar um time.");

        if (id == Guid.Empty)
            throw new InvalidDataException("O identificador é inválido.");

        var entity = Get(id);
        if (entity == null)
            throw new InvalidDataException("Nenhum time com esse identificador foi encontrado.");

        if(id != entity.Id)
            throw new InvalidDataException("Não é possível alterar o identificador de um time.");

        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.Sector = model.Sector;

        _context.Teams.Update(entity);
        _context.SaveChanges();

        return ConvertToViewModel(entity);
    }

    public void Delete(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidDataException("O identificador é inválido.");

        var entity = Get(id);
        if(entity == null)
            throw new InvalidDataException("Nenhum time com esse identificador foi encontrado.");

         if(entity.Employees.Any())
              throw new InvalidDataException("Há funcionários cadastrados nesse time e, por isso, não foi possível remove-lo..");

        _context.Teams.Remove(entity);
        _context.SaveChanges();
    }

    public ICollection<TeamViewModel> GetAll()
    {
        return _context.Teams
            .AsNoTracking()
            ?.Include(e => e.Employees)
            ?.Select(e => new TeamViewModel(e))
            ?.ToList();
    }

    public bool Exist(Guid id)
    {
        return (Get(id) != null);
    }

    public TeamViewModel GetViewModel(Guid id)
    {
        return ConvertToViewModel(Get(id));
    }

    private Team Get(Guid id)
    {
        return _context.Teams.FirstOrDefault(e => e.Id == id);
    }

    private Team GetByNameAndSector(string name, string sector)
    {
        return _context.Teams.FirstOrDefault(e => e.Name == name && e.Sector == sector);
    }

    private static Team ConvertToEntity(TeamInsertUpdateViewModel model)
    {
        return new Team(model.Name, model.Sector, model.Description);
    }

    private static TeamViewModel ConvertToViewModel(Team model)
    {
        return new TeamViewModel(model);
    }
}
