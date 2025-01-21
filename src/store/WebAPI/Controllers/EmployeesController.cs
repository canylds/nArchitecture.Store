using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEmployeeCommand createEmployeeCommand)
    {
        CreatedEmployeeResponse result = await Mediator.Send(createEmployeeCommand);

        return Created(uri: string.Empty, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        GetListEmployeeQuery getListEmployeeQuery = new();

        IList<GetListEmployeeListItemDto> result = await Mediator.Send(getListEmployeeQuery);

        return Ok(result);
    }
}
