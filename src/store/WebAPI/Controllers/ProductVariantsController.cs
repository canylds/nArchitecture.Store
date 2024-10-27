using Application.Features.ProductVariants.Commands.Create;
using Application.Features.ProductVariants.Commands.CreateBulk;
using Application.Features.ProductVariants.Commands.Update;
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

    [HttpPost("BulkInsert")]
    public async Task<IActionResult> BulkInsert([FromBody] CreateBulkProductVariantCommand createBulkProductVariantCommand)
    {
        CreatedBulkProductVariantResponse result = await Mediator.Send(createBulkProductVariantCommand);

        return Created(uri: string.Empty, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductVariantCommand updateProductVariantCommand)
    {
        UpdatedProductVariantResponse result = await Mediator.Send(updateProductVariantCommand);

        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductVariantQuery getByIdProductVariantQuery = new(id);

        GetByIdProductVariantResponse result = await Mediator.Send(getByIdProductVariantQuery);

        return Ok(result);
    }
}
