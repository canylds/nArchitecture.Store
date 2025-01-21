using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.UpdateFromAuth;
using Application.Features.Customers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        CreatedCustomerResponse result = await Mediator.Send(createCustomerCommand);

        return Created(uri: string.Empty, result);
    }

    [HttpPut("FromAuth")]
    public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateCustomerFromAuthCommand updateCustomerFromAuthCommand)
    {
        updateCustomerFromAuthCommand.UserId = GetUserIdFromRequest();

        UpdatedCustomerFromAuthResponse result = await Mediator.Send(updateCustomerFromAuthCommand);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        GetListCustomerQuery getListCustomerQuery = new();

        IList<GetListCustomerListItemDto> result = await Mediator.Send(getListCustomerQuery);

        return Ok(result);
    }
}