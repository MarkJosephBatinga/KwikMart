using KwikMart.Server.Services.UserService;
using KwikMart.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwikMart.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        List<User> Users = new List<User>();
        User user = new User();

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<List<User>>> RegisterUser(User user)
        {
            Users = await _userService.AddUser(user);
            if (Users != null)
                return Ok(Users);
            return NotFound(Users);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(LoginUser existingUser)
        {
            return user = await _userService.GetUser(existingUser);
        }

        [HttpPost("update")]
        public async Task<ActionResult<User>> UpdateUser(User existingUser)
        {
            return user = await _userService.UpdateUSer(existingUser);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            return user = await _userService.GetLogUser(username);
        }

        [HttpGet("remove/{Id:int}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int Id)
        {
            return Users = await _userService.RemoveUser(Id);
        }
    }
}
