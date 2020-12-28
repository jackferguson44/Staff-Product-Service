using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffProductNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            // read userId or user name from access token (if present)
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var name = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var displayName = name ?? userId;

            var rand = new Random().Next();
            var value = new GetValueDto
            {
                Number = rand,
                Message = string.IsNullOrEmpty(displayName) ? $"Your result is {rand}" : $"{displayName}, your personalised result is {rand}" 
            };
            return Ok(value);

        }
    }
}
