using Application.Features.Sizes.Commands.Create;
using Application.Features.Sizes.Commands.Delete;
using Application.Features.Sizes.Commands.Update;
using Application.Features.Sizes.Queries.GetById;
using Core.Application.Requests;
using core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Sizes.Queries.GetList;

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

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSizeCommand updateSizeCommand)
    {
        UpdatedSizeResponse result = await Mediator.Send(updateSizeCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteSizeCommand deleteSizeCommand = new(id);

        DeletedSizeResponse result = await Mediator.Send(deleteSizeCommand);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSizeQuery getByIdSizeQuery = new(id);

        GetByIdSizeResponse result = await Mediator.Send(getByIdSizeQuery);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSizeQuery getListSizeQuery = new(pageRequest);

        GetListResponse<GetListSizeListItemDto> result = await Mediator.Send(getListSizeQuery);

        return Ok(result);
    }
}
