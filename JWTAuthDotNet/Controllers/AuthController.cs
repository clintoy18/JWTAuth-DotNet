using JWTAuthDotNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWTAuthDotNet.Models;
using Microsoft.AspNetCore.Identity;

namespace JWTAuthDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly AppDbContext _context;

        //public AuthController(AppDbContext context)
        //{
        //    _context = context;
        //}

        public static User user = new User();

        [HttpPost("register")] 
        public ActionResult<User> Register(UserDto request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

           user.Username = request.Username;
           user.PasswordHash = hashedPassword;

           return Ok(user);

        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            if(user.Username != request.Username)
            {
               
                return BadRequest("User not found");
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
                == PasswordVerificationResult.Failed)
             {
                return BadRequest("Wrong password");
             }

            string token = "success";
            return Ok(token);
        }


    }
}
