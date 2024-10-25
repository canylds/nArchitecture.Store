using Application.Features.ProductVariants.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductVariantsController : BaseController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductVariantQuery getByIdProductVariantQuery = new(id);

        GetByIdProductVariantResponse result = await Mediator.Send(getByIdProductVariantQuery);

        return Ok(result);
    }
}
