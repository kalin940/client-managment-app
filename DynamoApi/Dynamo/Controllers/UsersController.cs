using System;
using System.Text.Json;
using Dynamo.Common.DTOs;
using Dynamo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace Dynamo.Controllers
{
    [ApiController]
    [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _userService;

        public UsersController(ILogger<UsersController> logger, IUsersService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost("Edit")]
        public IActionResult Edit([FromBody]UserDTO user)
        {
            _userService.Edit(user);
            return Ok();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]UserDTO user)
        {
            _userService.Create(user);
            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody]int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
