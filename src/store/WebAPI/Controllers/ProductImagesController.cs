﻿using Application.Features.ProductImages.Commands.CreateBulk;
using Application.Features.ProductImages.Commands.Delete;
using Application.Features.ProductImages.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : BaseController
{
    [HttpPost("BulkInsert")]
    public async Task<IActionResult> BulkInsert([FromBody] CreateBulkProductImageCommand createBulkProductImageCommand)
    {
        CreatedBulkProductImageResponse result = await Mediator.Send(createBulkProductImageCommand);

        return Created(string.Empty, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeleteProductImageCommand deleteProductImageCommand = new(id);

        DeletedProductImageResponse result = await Mediator.Send(deleteProductImageCommand);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductImageQuery getByIdProductImageQuery = new(id);

        GetByIdProductImageResponse result = await Mediator.Send(getByIdProductImageQuery);

        return Ok(result);
    }
}
