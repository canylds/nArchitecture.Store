using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetById;
using Core.Application.Requests;
using core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Colors.Queries.GetList;

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

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
    {
        UpdatedColorResponse result = await Mediator.Send(updateColorCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteColorCommand deleteColorCommand = new(id);

        DeletedColorResponse result = await Mediator.Send(deleteColorCommand);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdColorQuery getByIdColorQuery = new(id);

        GetByIdColorResponse result = await Mediator.Send(getByIdColorQuery);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListColorQuery getListColorQuery = new(pageRequest);

        GetListResponse<GetListColorListItemDto> result = await Mediator.Send(getListColorQuery);

        return Ok(result);
    }
}
