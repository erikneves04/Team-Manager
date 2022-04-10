using Team_Manager.Domain.Models;
using Team_Manager.Domain.ViewModels;

namespace Team_Manager.Domain.Interfaces.Services;

public interface IEmployeeServices
{
    EmployeeViewModel Insert(EmployeeInsertUpdateViewModel model);
    EmployeeViewModel Update(EmployeeInsertUpdateViewModel model, Guid id);
    void Delete(Guid id);
    ICollection<EmployeeViewModel> GetAll();
    EmployeeViewModel GetViewModel(Guid id);
    ICollection<Employee> GetEmployesByTeamId(Guid id);
}
