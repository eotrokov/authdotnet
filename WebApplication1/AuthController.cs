using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;

namespace WebApplication1
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Login(User user)
        {
            var u = new UserRepository().GetUser(user.Username);
            if (u == null)
                return NotFound("The user was not found.");
            var credentials = u.Password.Equals(user.Password);
            if (!credentials) 
                return  Forbid("The username/password combination was wrong.");
            return Ok(TokenManager.GenerateToken(user.Username));
        }
        
        [HttpGet]
        public IActionResult Validate(string token, string username)
        {
            bool exists = new UserRepository().GetUser(username) != null;
            if (!exists) return NotFound("The user was not found.");
            string tokenUsername = TokenManager.ValidateToken(token);
            if (username.Equals(tokenUsername))
                return Ok();
            return BadRequest();
        }
    }
}