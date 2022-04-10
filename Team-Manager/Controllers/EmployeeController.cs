using Microsoft.AspNetCore.Mvc;
using Team_Manager.Domain.Interfaces.Services;
using Team_Manager.Domain.Services;
using Team_Manager.Domain.ViewModels;

namespace Team_Manager.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeServices _services;

    public EmployeeController(IEmployeeServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<ICollection<EmployeeViewModel>> GetAll()
    {
        var content = _services.GetAll();
        if (content == null)
            return NotFound("Nenhum funcionário foi encontrado.");

        return new ActionResult<ICollection<EmployeeViewModel>>(content);
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeViewModel> Get(Guid id)
    {
        var content = _services.GetViewModel(id);       
        if(content == null)
            return NotFound("O funcionário não foi encontrado.");

        return new ActionResult<EmployeeViewModel>(content);      
    }

    [HttpPost]
    public ActionResult<EmployeeViewModel> Post([FromBody]EmployeeInsertUpdateViewModel model)
    {
        try
        {
            var content = _services.Insert(model);
            return new ActionResult<EmployeeViewModel>(content);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<EmployeeViewModel> Put([FromBody]EmployeeInsertUpdateViewModel model, Guid id)
    {
        try
        {
            var content = _services.Update(model, id);
            return new ActionResult<EmployeeViewModel>(content);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<NoContentResult> Delete(Guid id)
    {
        try
        {
            _services.Delete(id);
            return Ok();
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
