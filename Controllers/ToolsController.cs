using Microsoft.AspNetCore.Mvc;
using pLocals.Models.DTOs;
using pLocals.Tools;
using System.Text.Json;

namespace pLocals.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolsController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly PasswordManager _passwordManager = new();
        
        public ToolsController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("generate-pwd/")]
        public IActionResult GeneratePassword([FromQuery] int length, bool withUppercase = true, bool withSpecials = true)
        {
            if (length < 1)
                return BadRequest("Cannot generate password with length of " + length);

            var output = new GeneratedPassword() { Password = _passwordManager.GeneratePassword(length, withUppercase, withSpecials) };

            return Content(JsonSerializer.Serialize(output), "application/json");
        }
    }
}
