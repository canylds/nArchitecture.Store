using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Queries.GetList;
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteCategoryCommand deleteCategoryCommand = new(id);

        DeletedCategoryResponse result = await Mediator.Send(deleteCategoryCommand);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        GetListCategoryQuery getListCategoryQuery = new();

        IList<GetListCategoryListItemDto> result = await Mediator.Send(getListCategoryQuery);

        return Ok(result);
    }
}
