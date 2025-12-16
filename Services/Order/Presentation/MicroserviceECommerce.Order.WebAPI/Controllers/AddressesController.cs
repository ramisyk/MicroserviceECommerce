using MicroserviceECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MicroserviceECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler,
            GetAddressByIdQueryHandler getAddressByIdQueryHandler,
            CreateAddressCommandHandler createAddressCommandHandler,
            UpdateAddressCommandHandler updateAddressCommandHandler,
            DeleteAddressCommandHandler deleteAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var result = await _getAddressQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var result = await _getAddressByIdQueryHandler.Handle(new(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
        {
            var result = await _createAddressCommandHandler.Handle(command);
            return CreatedAtAction(nameof(GetAddressById), new { id = result }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _deleteAddressCommandHandler.Handle(new(id));
            return NoContent();
        }
    }
}
