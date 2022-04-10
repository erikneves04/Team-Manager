using Microsoft.AspNetCore.Mvc;
using Team_Manager.Domain.Interfaces.Services;
using Team_Manager.Domain.Services;
using Team_Manager.Domain.ViewModels;

namespace Team_Manager.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamServices _services;

    public TeamController(ITeamServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<ICollection<TeamViewModel>> GetAll()
    {
        var content = _services.GetAll();
        if (content == null)
            return NotFound("Nenhum time foi encontrado.");

        return new ActionResult<ICollection<TeamViewModel>>(content);
    }

    [HttpGet("{id}")]
    public ActionResult<TeamViewModel> Get(Guid id)
    {
        var content = _services.GetViewModel(id);
        if (content == null)
            return NotFound("O time não foi encontrado.");

        return new ActionResult<TeamViewModel>(content);
    }

    [HttpPost]
    public ActionResult<TeamViewModel> Post([FromBody]TeamInsertUpdateViewModel model)
    {
        try
        {
            var content = _services.Insert(model);
            return new ActionResult<TeamViewModel>(content);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<TeamViewModel> Put([FromBody]TeamInsertUpdateViewModel model, Guid id)
    {
        try
        {
            var content = _services.Update(model, id);
            return new ActionResult<TeamViewModel>(content);
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
