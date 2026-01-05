using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Order.WebAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController(
    GetAddressQueryHandler getAddressQueryHandler,
    GetAddressByIdQueryHandler getAddressByIdQueryHandler,
    CreateAddressCommandHandler createAddressCommandHandler,
    UpdateAddressCommandHandler updateAddressCommandHandler,
    DeleteAddressCommandHandler deleteAddressCommandHandler)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAddresses()
    {
        var result = await getAddressQueryHandler.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var result = await getAddressByIdQueryHandler.Handle(new(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
    {
        var result = await createAddressCommandHandler.Handle(command);
        return CreatedAtAction(nameof(GetAddressById), new { id = result }, result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
    {
        await updateAddressCommandHandler.Handle(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        await deleteAddressCommandHandler.Handle(new(id));
        return NoContent();
    }
}