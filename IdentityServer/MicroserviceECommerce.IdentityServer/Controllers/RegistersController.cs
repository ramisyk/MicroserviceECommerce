using System.Threading.Tasks;
using MicroserviceECommerce.IdentityServer.Dtos;
using MicroserviceECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var user = new ApplicationUser
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
                return Ok("Kullanıcı başarıyla eklendi");

            return BadRequest(result.Errors);

        }
    }
}
