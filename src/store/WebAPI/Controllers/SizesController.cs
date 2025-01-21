using Application.Features.Sizes.Commands.Create;
using Application.Features.Sizes.Commands.Delete;
using Application.Features.Sizes.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SizesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSizeCommand createSizeCommand)
    {
        CreatedSizeResponse result = await Mediator.Send(createSizeCommand);

        return Created(uri: string.Empty, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteSizeCommand deleteSizeCommand = new(id);

        DeletedSizeResponse result = await Mediator.Send(deleteSizeCommand);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        GetListSizeQuery getListSizeQuery = new();

        IList<GetListSizeListItemDto> result = await Mediator.Send(getListSizeQuery);

        return Ok(result);
    }
}
