using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using core.Application.Responses;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryResponse result = await Mediator.Send(createCategoryCommand);

        return Created(uri: string.Empty, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        UpdatedCategoryResponse result = await Mediator.Send(updateCategoryCommand);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteCategoryCommand deleteCategoryCommand = new(id);

        DeletedCategoryResponse result = await Mediator.Send(deleteCategoryCommand);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCategoryQuery getByIdCategoryQuery = new(id);

        GetByIdCategoryResponse result = await Mediator.Send(getByIdCategoryQuery);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCategoryQuery getListCategoryQuery = new(pageRequest);

        GetListResponse<GetListCategoryListItemDto> result = await Mediator.Send(getListCategoryQuery);

        return Ok(result);
    }
}