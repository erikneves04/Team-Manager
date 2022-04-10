using Team_Manager.Domain.ViewModels;

namespace Team_Manager.Domain.Interfaces.Services;

public interface ITeamServices
{
    TeamViewModel Insert(TeamInsertUpdateViewModel model);
    TeamViewModel Update(TeamInsertUpdateViewModel model, Guid id);
    void Delete(Guid id);
    ICollection<TeamViewModel> GetAll();
    bool Exist(Guid id);
    TeamViewModel GetViewModel(Guid id);
}
