using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
    {
        CreatedColorResponse result = await Mediator.Send(createColorCommand);

        return Created(uri: string.Empty, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteColorCommand deleteColorCommand = new(id);

        DeletedColorResponse result = await Mediator.Send(deleteColorCommand);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        GetListColorQuery getListColorQuery = new();

        IList<GetListColorListItemDto> result = await Mediator.Send(getListColorQuery);

        return Ok(result);
    }
}
