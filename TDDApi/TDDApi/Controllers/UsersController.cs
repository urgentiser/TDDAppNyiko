using Microsoft.AspNetCore.Mvc;
using TDDApi.Services;

namespace TDDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
           
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult> Get()
        {
            var users = await userService.GetAllUsers();
            if (users.Any())
            {
                return Ok(users);
            }
            return NotFound();
           
        }

    }
}