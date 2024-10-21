using Application.Features.Sizes.Commands.Create;
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
}