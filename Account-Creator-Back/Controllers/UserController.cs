using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account_Creator_Back.Services;

namespace Account_Creator_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            return Ok(await _userService.AddUser(user));
        }
    }
}
