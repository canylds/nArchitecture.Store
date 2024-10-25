using Application.Features.ProductVariants.Commands.Create;
using Application.Features.ProductVariants.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductVariantsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductVariantCommand createProductVariantCommand)
    {
        CreatedProductVariantResponse result = await Mediator.Send(createProductVariantCommand);

        return Created(uri: string.Empty, result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductVariantQuery getByIdProductVariantQuery = new(id);

        GetByIdProductVariantResponse result = await Mediator.Send(getByIdProductVariantQuery);

        return Ok(result);
    }
}
