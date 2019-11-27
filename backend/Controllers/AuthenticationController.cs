
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using fullstackApp.Models;
using fullstackApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fullstackApp.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {

        private readonly IAuth _authService;
        
        public AuthenticationController(IAuth authService) {
            _authService = authService;
        }


        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserRegistrationRequest req) {
            var authResponse = await _authService.RegisterAsync(req.Email, req.Password);
            
            return Ok();
        }


        [AllowAnonymous]
        [HttpPost, Route("request")]
        public ActionResult RequestToken([FromBody] TokenRequest req) {
            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            string token;
            if (_authService.IsAuthenticated(req, out token)) {
                return Ok(token);
            }
            return BadRequest("Invalid Request!");
        }

    }

    public class TokenRequest 
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

    }
}