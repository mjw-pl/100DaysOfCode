using Day001.Authentications;
using Day001.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Day001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IConfiguration config;

        public Auth(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost]
        public ActionResult<DtoAuthenticationResponse> Login(DtoUserCredentialsRequest credentials)
        {

            if (String.Equals(credentials.username, "Mario", StringComparison.OrdinalIgnoreCase) && 
                String.Equals(credentials.password, "p@ss", StringComparison.OrdinalIgnoreCase))
            {
                var response = new DtoAuthenticationResponse();
                response.username = credentials.username;
                response.token = JwtTools.CreateToken(
                    name: "Mariusz",
                    email: "hello@gmail.com",
                    new List<string>
                    {
                        "admin", "supervisor" // roles
                    },
                    24,
                    jwtKey: config["JwtSettings:Key"],
                    jwtAudience: config["JwtSettings:Audience"],
                    jwtIssuer: config["JwtSettings:Issuer"]
                    );

                return response;
            }

            return Unauthorized();
        }
    }
}
